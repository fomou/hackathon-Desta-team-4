using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaBackend.DataAccessLayer
{
    public static class MigrationBuilder
    {

        private static readonly ILog Logger = LogManager.GetLogger(typeof(MigrationBuilder));

        public static void ApplyMigration<DbContextType>(this IApplicationBuilder application)
        {
            // Migrate and seed the database during startup. Must be synchronous.
            try
            {
                using (var serviceScope = application.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var dbContext = (DbContext)serviceScope.ServiceProvider.GetRequiredService(typeof(DbContextType));
                    dbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // I'm using Serilog here, but use the logging solution of your choice.
                Logger.Error("Failed to migrate or seed database", ex);
            }
        }
    }
}
