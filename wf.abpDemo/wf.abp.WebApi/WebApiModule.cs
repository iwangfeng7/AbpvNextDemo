using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using wf.abp.Application;
using wf.abp.Domain;
using wf.abp.Domain.Shared;
using wf.abp.EntityFrameworkCore;

namespace wf.abp.WebApi
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(DomainModule),
        typeof(AbpAutoMapperModule),
        typeof(DomainShareModule),
        typeof(EntityFrameworkCoreModule),
        typeof(ApplicationModule)
        )]
    public class WebApiModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureAutoMapper();
            ConfigureSwaggerServices(context.Services);
            context.Services.AddAutoMapperObjectMapper<WebApiModule>();

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options
                .ConventionalControllers
                .Create(typeof(ApplicationModule).Assembly);
            });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<WebApiModule>();
            });
        }
        private void ConfigureSwaggerServices(IServiceCollection services)
        {           
            var configuration = services.GetConfiguration();
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Products API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                });
        }
    }
}