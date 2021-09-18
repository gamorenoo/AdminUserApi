using AdminUserApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUserApi.Models.Repositories.IRepositories;
using AdminUserApi.Models.Repositories;
using AdminUserApi.Automapper;
using AdminUserApi.Domain.Services;
using AdminUserApi.Application;

namespace AdminUserApi.DI
{
    public class DependencyInjectionProfile
    {
        private readonly IConfiguration Configuration;
        public DependencyInjectionProfile(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void InjectDependencies(IServiceCollection services)
        {
            services.AddDbContext<AdminUserDBcontext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddAutoMapper(typeof(GlobalMapperProfile));

            #region Repositorios
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion
            #region Servicios de dominio
            services.AddTransient<PermissionRoleDomainService>();
            services.AddTransient<UserDomainService>();
            #endregion

            #region Servicios de aplicacion
            services.AddTransient<PermissionRoleAppService>();
            services.AddTransient<UserAppService>();

            #endregion
        }


    }
}
