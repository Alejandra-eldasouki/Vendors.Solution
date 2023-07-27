using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Vendors
{
  public class Startup
  {
    public Startup(IWebHostEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseRouting();



    // Other middleware configurations

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "vendors",
            pattern: "/vendors/{action}/{id?}", // Make sure {id} is optional with ?
            defaults: new { controller = "Vendors", action = "Index" });

        endpoints.MapControllerRoute(
            name: "orders",
            pattern: "/orders/{action}/{id?}", // Make sure {id} is optional with ?
            defaults: new { controller = "Orders", action = "Index" });

        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}

  }
}
