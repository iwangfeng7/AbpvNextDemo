using System;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace wf.abp.EntityFrameworkCore
{
    public class EntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();
            });
        }
    }
}