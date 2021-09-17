
Add-Migration InitialeCreate -Context DestaNationConnectContext -Project DestaBackend -StartupProject DestaBackend --output-dir DataAccessLayer/Migrations -Verbose
EntityFrameworkCore\Add-Migration InitialeCreate -Context DestaNationConnectContext -Project DestaBackend -StartupProject DestaBackend -o DataAccessLayer/Migrations -Verbose


EntityFrameworkCore\Add-Migration InitialeCreate -Context DestaNationConnectContext -Project DestaNationConnect -StartupProject DestaNationConnect -o DataAccessLayer/Migrations -Verbose

dotnet ef migrations add InitialeCreate -Context DestaNationConnectContext -Project DestaBackend -StartupProject DestaBackend --output-dir DataAccessLayer/Migrations -Verbose