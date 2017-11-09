using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HtmlPageStartUp
{
   public class Startup
   {
      // This method gets called by the runtime. Use this method to add services to the container.
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         // Look for default files in wwwroot like index.html, default.html etc
         app.UseDefaultFiles();
         // Lets application to use static files such as css, images, js etc
         app.UseStaticFiles();

         // add this to your Startup file
         app.UseMvc(routes =>
         {
            routes.MapRoute(
                      name: "default",
                      template: "{controller=Home}/{action=Index}/{id?}");
         });

         app.Run(async (context) =>
         {
            await context.Response.WriteAsync("Hello World!");
         });
      }
   }
}
