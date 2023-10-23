using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RA.Infrastructure.Database;

namespace RA.Config
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            string connString = configuration.GetConnectionString("RAConnection");

            services.AddDbContext<RAContext>(options =>
            {
                options.UseSqlServer(connString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
            });
        }
    }
}
