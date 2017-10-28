using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Inshapardaz.Data.EmptyWeb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddEntityFrameworkSqlite()
                .AddDbContext<DictionaryDatabase>(
                    options => options.UseSqlite("Data Source=dictionary.dat"));

            services.AddTransient<IDictionaryDatabase, DictionaryDatabase>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
