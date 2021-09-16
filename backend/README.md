
Add-Migration InitialeCreate -Context DestaContext -Project DestaBackend -StartupProject DestaBackend --output-dir DataAccessLayer/Migrations -Verbose
dotnet ef migrations add InitialeCreate -Context DestaContext -Project DestaBackend -StartupProject DestaBackend --output-dir DataAccessLayer/Migrations -Verbose