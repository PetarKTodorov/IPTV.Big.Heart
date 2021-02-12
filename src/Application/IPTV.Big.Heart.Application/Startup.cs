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
using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
using IPTV.Big.Heart.Common;
using IPTV.Big.Heart.Application.Infrastructures.Middlewares;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

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

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // Register database repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            // Register application services
            this.RegisterDatabseServices(services);

            // Register Api Result
            services.AddTransient<IApiResult, ApiResult>();

            // configure strongly typed settings object
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "IPTV.Big.Heart API",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "NAMES",
                        Email = "EMAIL",
                    },
                });
            });

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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IPTV.Big.Heart API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<ExceptionMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

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
