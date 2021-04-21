using GroupByIssue.Data;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GroupByIssue
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                // .AddNewtonsoftJson()
                .AddMvcOptions(options => { options.EnableEndpointRouting = false; });

            services.AddOData();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Filter();

                var builder = new ODataConventionModelBuilder();
                builder.EntitySet<Product>("Products");

                var model = builder.GetEdmModel();
                routeBuilder.MapODataServiceRoute("odata", "odata", model);
            });
        }
    }
}
