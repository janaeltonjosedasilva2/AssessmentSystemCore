using AssessmentSystemCore.Data.Persistence.Contexts;
using AssessmentSystemCore.Data.Persistence.Repositories;
using AssessmentSystemCore.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Data.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("localSqlServer");

            services.AddDbContext<AssessmentSystemCoreContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IWriteRepository, WriteRopository>();
            services.AddScoped<IReadRepository, ReadRepository>();

            return services;
        }
    }
}
