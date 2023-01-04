using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Core.Resources;
using RecordStore.Core.Settings;
using RecordStore.Infrastructure.Repositories;
using RecordStore.Service.Interfaces;
using RecordStore.Service.Services;
using System.Globalization;
using System.Reflection;

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
            services.AddScoped<IPhotoServices, PhotoServices>(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var ftpSettings = configuration.GetSection(nameof(FtpSettings)).Get<FtpSettings>();

                return new PhotoServices(
                    serviceProvider.GetRequiredService<IRepository<Photo>>(),
                    ftpSettings
                    );
            });

            return services;
        }

        public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
        {
            services.AddLocalization(o => { o.ResourcesPath = "Resources"; });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo> {
                    new CultureInfo("en-US"),
                    new CultureInfo("ro-RO"),
                    new CultureInfo("ru-RU")
                };
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
                options.FallBackToParentUICultures = true;
                options.RequestCultureProviders.Clear();
                //options.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider());
                //options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
                options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
                //options.RequestCultureProviders.Insert(3, new AcceptLanguageHeaderRequestCultureProvider());
            });
            return services;
        }

        public static IMvcBuilder ConfigureViewLocalization(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(UILabels).GetTypeInfo().Assembly.FullName);
                        return factory.Create(nameof(UILabels), assemblyName.Name);
                    };
                });
            return mvcBuilder;
        }
    }
}
