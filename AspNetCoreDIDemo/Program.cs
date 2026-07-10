namespace AspNetCoreDIDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateBuilder() creates and returns a WebApplicationBuilder object:
            var builder = WebApplication.CreateBuilder(args);
            /*
             * Notice that if you hover over the method "CreateBuilder"
             * Visual Studio will show "WebApplicationBuilder" definition :-)
             * 
             * WebApplication.CreateBuilder(args): 
             *      > creates and returns a WebApplicationBuilder object
             *
             * The WebApplicationBuilder:
             *      > is used to configure an ASP.NET Core application
             *      > before the application is built and executed
             *
             * It provides access to:
             * - Configuration
             * - Logging
             * - Dependency Injection services
             *
             * Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.webapplicationbuilder
             */

            // Add services to the container.
            // Register MVC framework services with the built-in Dependency Injection (DI) container.
            builder.Services.AddControllersWithViews();
            /*
             * Notice again, when hovering over "Services",
             * Visual Studio will show IServiceCollection WebApplicationBuilder.Services definition
             * 
             * The "Services" property => is of type "IServiceCollection"
             * "IServiceCollection" => represents a collection of service registrations
             * 
             * In other words, "IServiceCollection" is a collection 
             * used to register application services and framework services 
             * with ASP.NET Core's built-in Dependency Injection container:
             * - Framework services
             * - Application services
             * - Third-party services
             * 
             * IServiceCollection:
             *  > Service Registration A
             *  > Service Registration B
             *  > Service Registration C
             *  and so on...
             *  
             *  In this collection, we register services 
             *  that ASP.NET Core will create and provide when required
             *  
             *  The Dependency Injection container uses these registrations
             *  to create and provide service instances according to their configured lifetime
             *
             *  NOTE:
             *  *****
             *  - We are NOT creating service objects here
             *  - We are only registering instructions 
             *  that tell the Dependency Injection (DI) container how to create them later
             *  So, Services registered here can later be injected into classes 
             *  through constructor injection
             *  
             *  Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection
             *  Link :https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.mvcservicecollectionextensions.addcontrollerswithviews
             *  
             * "AddControllersWithViews()" method:
             * This method registers the services required for using the ASP.NET Core MVC framework:
             * - Controllers
             * - Views
             * - Model binding
             * - Validation
             * - Other MVC features
             * 
             *  In other words, it tells ASP.NET Core:
             *      > This application uses the MVC framework
             *      > Please register all the required MVC services in the DI container
             *      
             *  Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.mvcservicecollectionextensions.addcontrollerswithviews?view=aspnetcore-11.0
             */

            /*
             * Build the WebApplication object.
             *
             * At this point:
             * - The application configuration is prepared
             * - Registered services are available through the DI container
             * - The application pipeline can now be configured
             */
            var app = builder.Build();

            /*
             * The app workflow:
             * Start: CreateBuilder()
             *             => Register Services
             *                 => Build Application
             *                      => Configure Middleware
             *                          => Run Application
             *  
             */

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        } // Main()
    } // class
} // namespace
