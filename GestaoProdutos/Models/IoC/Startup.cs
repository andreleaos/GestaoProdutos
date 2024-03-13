using GestaoProdutos.Models.Domain.Interfaces;
using GestaoProdutos.Models.Infrastructure.Repositories;
using GestaoProdutos.Models.Services;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace GestaoProdutos.Models.IoC
{
    public static class Startup
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services)
        {
            string connStr = configuration.GetConnectionString("filmeDb");

            services.AddScoped<IDbConnection>(provider => new MySqlConnection(connStr));
            services.AddTransient<IFilmeRepository, FilmeRepository>();
            services.AddTransient<IFilmeService, FilmeService>();
        }
    }
}
