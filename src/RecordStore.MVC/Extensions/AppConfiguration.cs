using RecordStore.Core.Interfaces;
using RecordStore.Infrastructure.Repositories;
using RecordStore.Service.Interfaces;
using RecordStore.Service.Services;

namespace RecordStore.MVC.Extensions
{
    public static class AppConfiguration
    {
        public static IServiceCollection ConfigureDependecyInjections(this IServiceCollection services)
        {
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IRecordServices, RecordServices>();
            services.AddScoped<IGenreServices, GenreServices>();
            services.AddScoped<IStyleServices, StyleServices>();
            services.AddScoped<IConditionServices, ConditionServices>();
            services.AddScoped<IFormatServices, FormatServices>();
            services.AddScoped<IReleaseServices, ReleaseServices>();
            services.AddScoped<IPhotoServices, PhotoServices>();

            return services;
        }
    }
}
