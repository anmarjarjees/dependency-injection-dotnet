// Access the service interface and implementation:
using AspNetCoreDIDemo.Services; // using "Services" to access the music services/contract
using Microsoft.AspNetCore.Mvc;
/*
 * Controller:
 * ***********
 * 1) receives HTTP requests
 * 2) performs the required work (often by calling services)
 * 3) and returns an HTTP response
 *
 * In ASP.NET Core MVC:
 *  > Controllers typically depend on services rather than creating them directly
 *
 * This is where Constructor Dependency Injection is commonly used.
 */
namespace AspNetCoreDIDemo.Controllers
{
    public class MusicController : Controller
    {
        /*
         * Injecting "IMusicService" through the constructor:
         * **************************************************
         * 
         * This controller "MusicController" depends on the contract "IMusicService".
         * 
         * Notice that we use the interface "IMusicService",
         * rather than the concrete class "MusicService",
         * because we depend on the abstraction (contract), not the implementation.
                
         * So we need to inject "IMusicService" through the constructor:
         * - First: Declaring a private field of type "IMusicService"
         * - Second: Injecting (passing) this field into the constructor
         */

        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        /*
         * Constructor Dependency Injection Explanation:
         * *********************************************
         *
         * ASP.NET Core automatically calls the constructor:
         *      > Controller(IMusicService musicService)
         *  
         * when creating the controller.
         *
         * The "IMusicService" parameter is NOT created here.
         *
         * Instead, the built-in Dependency Injection container
         * sees that this controller requires IMusicService,
         * looks for its registration in Program.cs,
         * creates a MusicService object,
         * and passes it to this constructor.
         *
         * We never write:
         *
         *      > new MusicService();
         *
         * inside this controller.
         *
         * Notice that this follows the same Constructor Injection principle
         * introduced in Part 2 of this repository.
         * 
         * The difference is that, in ASP.NET Core,
         * the built-in Dependency Injection container 
         * automatically creates and injects the required dependency.
         */

        // Default Generated Method "Index()":
        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        /*
         * Using the injected service:
         * ***************************
         * Remember that "MusicService" class has:
         *      > GetMessage() method => returns a simple text message.
         * 
         * We need to call this method in the current controller class.
         * Notice that I commented the default index() method for learning purposes,
         * but we can modify it directly or creating a new one:
         */
        public IActionResult Index()
        {
            /*
             * The actual use of the injected service:
             * - We call GetMessage() through the interface reference "_musicService"
             * - The controller depends only on the IMusicService contract
             * - It doesn't need to know which concrete implementation
             * (such as MusicService) the DI container provides.
             */

            var message = _musicService.GetMessage();

            // Returns plain text (HTTP response body) as a ContentResult,
            // which implements IActionResult:
            return Content(message);
            /*
             * Normally an MVC controller returns a View() as shown in the default index() method
             *
             * For this simple Dependency Injection demonstration,
             * we return plain text using Content()
             * so we can clearly verify that the injected service is working.
             *
             * Later, we'll return a View again.
             * 
             * Content() method: 
             * - inherited from the ASP.NET Core Controller base class.
             * - returns plain text (or other text content) as the HTTP response,
             * instead of returning a View.
             * - it's used here just to prove that our DI is working before introducing Views,
             * so we can easily verify that the injected service is working correctly
             * - will convert the plain text into an object that implements IActionResult
             * - If not used => will not compile because string is not an IActionResult.
             *      => Error: Cannot implicitly convert type 'string' to...
             * 
             * In other words:
             * - message is a string
             * - Content(message) creates a ContentResult object
             * - ContentResult object implements IActionResult
             * 
             * Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.contentresult.content?
             * 
             * Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult?
             * 
             * "return" examples in ASP.NET Core:
             * **********************************
             * - return View(); // HTML page
             * - return Content("Hi"); // Plain text
             * - return Json(data); // JSON
             * - return Redirect("/"); // Redirect
             * - return NotFound(); // 404
             * - return BadRequest(); // 400
             */
        } // Index()

        /*
         * URL Convention in ASP.NET Core MVC:
         * ***********************************
         * 
         * Running in the browser:
         * https://localhost:xxxx/Music
         * 
         * A note to review:
         * *****************
         * - Controller class: MusicController
         * - Default route: /Music
         * 
         * By MVC convention, ASP.NET Core automatically removes the "Controller" suffix
         * from the class name when matching the URL.
         * The remaining name becomes the controller route value.
         * 
         * Examples:
         * - HomeController => URL Endpoint: /Home
         * - SchoolController => URL Endpoint: /School
         * 
         * ASP.NET Core will do the following automatically:
         * > HTTP Request
         *      > MusicController needed
         *          > Controller requires IMusicService
         *              > DI Container checks registration
         *                  > DI finds: IMusicService => MusicService
         *                      > Creates MusicService
         *                          > Calls MusicController(IMusicService...)
         *                              > _musicService.GetMessage()
         *                                  > Returns the string to the browser
         */

    } // class
} // namespace
