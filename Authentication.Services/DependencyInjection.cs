using Authentication.DataVo.Converters;
using Authentication.Repository.Repositories;
using Authentication.Services.Interfaces;
using Authentication.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Services
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Adiciona a injeção de dependência entre os repositorios e suas interfaces.
        /// </summary>
        /// <param name="services"></param>
        public static void InjecaoDependenciaServicos(ref IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUsersService, UsersService>();            
            services.AddScoped<IGroupsService, GroupsService>();
            services.AddScoped<IGroupUsersService, GroupUsersService>();
        }

        /// <summary>
        /// Adiciona a injeção de dependência entre os serviços e suas interfaces.
        /// </summary>
        /// <param name="services"></param>
        public static void InjecaoDependenciaRepositorios(ref IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IGroupsRepository, GroupsRepository>();
            services.AddScoped<IGroupUsersRepository, GroupUsersRepository>();
        }

        /// <summary>
        /// Adiciona a injeção de dependência entre os converters
        /// </summary>
        /// <param name="services"></param>
        public static void InjecaoDependenciaConverters(ref IServiceCollection services)
        {
            services.AddScoped<CompanyConverter, CompanyConverter>();
            services.AddScoped<UsersConverter, UsersConverter>();            
            services.AddScoped<GroupsConverter, GroupsConverter>();
            services.AddScoped<GroupUsersConverter, GroupUsersConverter>();
        }
    }
}
