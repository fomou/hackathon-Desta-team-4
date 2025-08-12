# syntax=docker/dockerfile:1.4

# -----------------------------
# Base runtime image
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Expose application ports
EXPOSE 8080 8081

# -----------------------------
# Install system dependencies (SQLite, MSSQL tools, MailHog, Loki plugin)
# -----------------------------
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
        sqlite3 libsqlite3-dev curl apt-transport-https gnupg && \
    \
    # Add Microsoft package feed for MSSQL tooling
    curl -sSL https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl -sSL https://packages.microsoft.com/config/debian/12/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y --no-install-recommends \
        msodbcsql18 \
        mssql-tools18 \
        unixodbc-dev && \
    \
    # Install MailHog CLI
    curl -sSL https://github.com/mailhog/MailHog/releases/download/v1.0.1/MailHog_linux_amd64 -o /usr/local/bin/mailhog && \
    chmod +x /usr/local/bin/mailhog && \
    \
    # Install Grafana Loki Docker log driver
    curl -sSL https://raw.githubusercontent.com/grafana/loki/main/clients/cmd/docker-driver/install.sh | bash && \
    \
    # Cleanup to reduce image size
    apt-get clean && rm -rf /var/lib/apt/lists/*

# -----------------------------
# Application-wide environment variables
# -----------------------------
ENV \
    MSSQL_SERVER="mssql" \
    MSSQL_PORT="1433" \
    MSSQL_USER="sa" \
    MSSQL_PASSWORD="NetsenDevUser2023@;" \
    SQLITE_DB_PATH="/app/data/Ivsd.db" \
    SMTP_HOST="mailhog" \
    SMTP_PORT="1025" \
    SMS_PROVIDER="mock" \
    FIREBASE_PROJECT_ID="ivsd-2025" \
    FIREBASE_CREDENTIALS_PATH="/app/secrets/ivsd-2025-firebase-adminsdk-fbsvc-5fc2a132bb.json" \
    ASPNETCORE_ENVIRONMENT="Development" \
    ApplicationUrl_IVSD="http://localhost:8080" \
    IvsdDatabase="Data Source=/app/data/Ivsd.db" \
    DB_PROVIDER="sqlserver" \
    HttpClient_developer_ivsd_api="http://localhost:8080" \
    IdpServerv4_Netsen="http://localhost:5000" \
    Authentication_Google_ClientId="ivsd-google-client-id" \
    Authentication_Google_ClientSecret="ivsd-google-client-secret" \
    Authentication_Facebook_ClientId="ivsd-facebook-client-id" \
    Authentication_Facebook_ClientSecret="ivsd-facebook-client-secret" \
    Authentication_Microsoft_ClientId="ivsd-microsoft-client-id" \
    Authentication_Microsoft_ClientSecret="ivsd-microsoft-client-secret" \
    Email_SmtpHost="mailhog" \
    Email_SmtpPort="1025" \
    Email_UserName="dev@ivsd.local" \
    Email_Password="password" \
    Email_FromAddress="dev@ivsd.local" \
    Twilio_AccountSid="ivsd-twilio-account-sid" \
    Twilio_AuthToken="ivsd-twilio-auth-token" \
    Twilio_FromNumber="+1234567890" \
    ApplicationLogging_IVSD_LoggingPath="/app/logs"

# -----------------------------
# Build stage – use full SDK image
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files first (enables layer-level caching)
COPY ["Ivsd.Api/Ivsd.Api.csproj", "Ivsd.Api/"]
COPY ["Ivsd.Authorization/Ivsd.Authorization.csproj", "Ivsd.Authorization/"]
COPY ["Ivsd.BusinessAccessLayer/Ivsd.BusinessAccessLayer.csproj", "Ivsd.BusinessAccessLayer/"]
COPY ["Ivsd.Core/Ivsd.Core.csproj", "Ivsd.Core/"]
COPY ["Ivsd.DataAccessLayer/Ivsd.DataAccessLayer.csproj", "Ivsd.DataAccessLayer/"]
COPY ["Ivsd.Model.Extensions/Ivsd.Model.Extensions.csproj", "Ivsd.Model.Extensions/"]
COPY ["Ivsd.Services/Ivsd.Services.csproj", "Ivsd.Services/"]

# Restore NuGet packages
RUN dotnet restore "Ivsd.Api/Ivsd.Api.csproj"

# Copy the remaining source code and build
COPY . .
WORKDIR /src/Ivsd.Api
RUN dotnet build "Ivsd.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# -----------------------------
# Publish stage – produce self-contained binaries
# -----------------------------
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ivsd.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# -----------------------------
# Final runtime image
# -----------------------------
FROM base AS final
WORKDIR /app

# Create directories required at runtime
RUN mkdir -p /app/data /app/build /app/publish

# Copy published assets
COPY --from=publish /app/publish .

# Default entry-point
ENTRYPOINT ["dotnet", "Ivsd.Api.dll"]