using GroupByIssue.Data;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GroupByIssue
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            services.AddMvc()
                //.AddNewtonsoftJson()
                .AddMvcOptions(options => { options.EnableEndpointRouting = false; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddOData();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProductDbContext productDbContext)
        {
            productDbContext.Products.Add(new Product { Id = 1, Category = "Test Category", Name = "Test Name" });
            productDbContext.SaveChanges();
            
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
