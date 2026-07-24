using AspNetCoreDIDemo.Services;
using Microsoft.Win32;

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
             * The "Services" property => has the type "IServiceCollection"
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
             *      > Registration A (IMusicService => MusicService)
             *      > Registration B (ILogger => Logger)
             *      > Registration C (Database service => Database implementation)
             *      >  and so on...
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


            // Dependency Injection line in ASP.NET Core => Register our services:
            builder.Services.AddTransient<IMusicService, MusicService>();
            /*
             * Service Registration:
             * *********************
             * In our application, "Services" folder, we have:
             * 
             *  > class MusicService == implements ==> Interface IMusicService 
             *      
             * So we need to tell ASP.NET Core:
             * > Whenever a class requests the interface (contract) "IMusicService",
             * > provide an instance of class "MusicService".
             *
             * This process is called "Service Registration"
             * 
             * Why Service Registration?
             * *************************
             * In case if a controller needs to use "IMusicService",
             * ASP.NET Core will ask: Which class should I instantiate?
             * 
             * So, without a registration, ASP.NET will not have an answer!
             * 
             * ASP.NET Core doesn't know:
             *  - Which implementation should it instantiate?
             *  - Should it create MusicService?
             *  - Should it create another implementation of IMusicService?
             *  
             * For this reason, we register a mapping between:
             *      > IMusicService <==> MusicService
             * which is exactly what DI registration is :-)    
             * 
             * To simplify the concept:
             * *************************
             * Reading this registration code line:
             *      > builder.Services.AddTransient<IMusicService, MusicService>();
             *  
             * As: 
             *      "Register the service (contract) "IMusicService" interface,
             *          so that ASP.NET Core will provide a MusicService instance." :-)
             *  
             * "AddTransient" method:
             * **********************
             *  This one of the three registration methods in DI. 
             *  
             *  Microsoft provides three different methods for registering our services:
             *  - AddTransient()
             *  - AddScoped()
             *  - AddSingleton()
             *
             * 
             * Why AddTransient()?
             * *******************
             *
             * "Transient" means:
             *      > A NEW object (instance) is created every time the service is requested.
             *
             * Example:
             *
             * - Controller A
             *      > requests "IMusicService" => New "MusicService" object
             *
             * - Controller B
             *      > requests "IMusicService" => Another New "MusicService" object
             * 
             * - And so on...
             * 
             * In other words: "No object is shared between requests"
             *
             * This works well for lightweight, stateless services.
             * 
             * "Stateless" means the service does NOT remember information between different uses.
             * 
             * Each new instance starts with a fresh state.
             * 
             * In our example:
             * Our class "MusicService" is stateless.
             * Because MusicService simply returns a message
             * It does not store user data, counters, or any other information.
             * 
             * Therefore, creating a new MusicService object each time is simple and inexpensive
             * 
             * Or simply in programming concept:
             * "Stateless" means the object does not keep information from previous operations.
             * Every new object starts fresh.
             * 
             * so AddTransient() => create a new instance when requested.
             * 
             * The other two Microsoft provided methods:
             * *****************************************
             * - AddScoped() => reuse one instance within the same request/scope.
             *      > One instance per HTTP request
             *
             * - AddSingleton() => reuse one instance for the application's lifetime.
             *      > One instance for the application's lifetime
             *
             * The idea of  "lifetimes" and all its detail will be covered in another part
             * 
             * Try to temporary use the other 2 methods for learning and demonstrating only
             *
             * Link:
             * https://learn.microsoft.com/aspnet/core/fundamentals/dependency-injection
             */

            // Add second service and register multiple DI services:
            builder.Services.AddTransient<IGuitarService, GuitarService>();
            /*
             * Registering multiple services:
             * ******************************
             * The DI container can manage many service registrations.
             *
             * In our example:
             *      > IMusicService  => MusicService
             *      > IGuitarService => GuitarService
             *
             * then a controller requests:
             *
             * public MusicController(
             *      IMusicService musicService,
             *      IGuitarService guitarService)
             *
             * ASP.NET Core will:
             * 1) Look for IMusicService registration
             * 2) Create MusicService
             * 3) Look for IGuitarService registration
             * 4) Create GuitarService
             * 5) Pass both objects into the controller constructor
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

            // The default code => Default MVC route:
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            /*
             * - {controller} => controller name without the Controller suffix
             * - {action} => action (method) name
             * - {id?} => optional parameter
             * 
             * Microsoft calls this conventional routing.
             * 
             * In the controller file:
             * public class MusicController : Controller
             *      {    
             *          public IActionResult Index()
             * 
             * ASP.NET Core matches the URL endpoint /Music as:
             * - controller = Music
             * - action = Index
             * 
             * NOTE:
             * *****
             * We can change the controller value to "Music":
             *      > {controller=Music}
             * Instead of the default template value:
             *      > {controller=Home}
             * so no need to explicitly add /Music:
             *      . https://localhost:xxxx/Msuic
             * 
             * Link: https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?
             */

            app.Run();
        } // Main()
    } // class
} // namespace
