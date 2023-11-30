﻿
using BackEndMonografia.Configuration.Interfaces;
using BackEndMonografia.Repositories;
using BackEndMonografia.Services;
using BackEndMonografia.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace BackEndMonografia
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IDbConector, DbConector>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<ITypeRepository, TypeRepository>();
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<IDemandRepository, DemandRepository>();
            services.AddTransient<IDemandService, DemandService>();
            services.AddTransient<ITaxonomyRepository, TaxonomyRepository>();
            services.AddTransient<ITaxonomyService, TaxonomyService>();
            services.Configure<AppSettings>(Configuration);
            services.AddSingleton<IAppSettings>(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //if (env.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
