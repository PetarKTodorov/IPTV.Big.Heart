using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using AutoMapper;

using IPTV.Big.Heart.Database;
using IPTV.Big.Heart.Database.Repositories;
using IPTV.Big.Heart.Database.Repositories.Interfaces;
using IPTV.Big.Heart.Database.Seed;
using IPTV.Big.Heart.Services.Database.Location;
using IPTV.Big.Heart.Services.Database.Location.Interfaces;
using IPTV.Big.Heart.Services.Database.User;
using IPTV.Big.Heart.Services.Database.User.Interfaces;
using IPTV.Big.Heart.Services.Mapper;
using IPTV.Big.Heart.Services.Database.Television.Interfaces;
using IPTV.Big.Heart.Services.Database.Television;
using Microsoft.EntityFrameworkCore;
using IPTV.Big.Heart.Application.Infrastructures;

namespace IPTV.Big.Heart.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IPTVBigHeartContext>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddControllers();

            // Register database repositories
            services.AddScoped(typeof(IRepositary<>), typeof(BaseRepositary<>));

            // Register application services
            this.RegisterDatabseServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.MigrateDatabaseAsync().GetAwaiter().GetResult();

                app.SeedDatabaseAsync().GetAwaiter().GetResult();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterDatabseServices(IServiceCollection services)
        {
            // Add location services
            services.AddTransient<ICountryService, CountryService>();

            // Add user services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserRoleMappingService, UserRoleMappingService>();

            // Add television services
            services.AddTransient<ITelevisionService, TelevisionService>();
            services.AddTransient<IStreamService, StreamService>();
            services.AddTransient<ITelevisionCategoryService, TelevisionCategoryService>();
            services.AddTransient<ITelevisionCategoryMappingService, TelevisionCategoryMappingService>();
            services.AddTransient<ITelevisionCountryMappingService, TelevisionCountryMappingService>();
            services.AddTransient<ITelevisionStreamMappingService, TelevisionStreamMappingService>();
        }
    }
}
