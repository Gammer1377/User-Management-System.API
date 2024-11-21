
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User_Management_System.Data.Context;
using User_Management_System.Data.Contracts;
using User_Management_System.Data.Repositories;
using User_Management_System.Entities.DTOs.User;
using User_Management_System.Entities.Validators;

namespace User_Management_System.Data
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection service, IConfiguration configuration)
        {
            #region Context

            service.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            });

            #endregion

            #region Dependency

            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IRoleRepository, RoleRepository>();
            service.AddScoped<IValidator<CreateUpdateUserDTO>, CreateUpdateUserDTOValidation>();
            service.AddScoped<IValidator<CreateUpdateRoleDTO>, CreateUpdateRoleDTOValidation>();

            #endregion

            return service;

        }
    }
}
