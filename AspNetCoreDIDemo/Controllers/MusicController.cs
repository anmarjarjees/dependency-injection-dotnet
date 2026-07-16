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

        /*
         * After adding a second service for guitars,
         * we need to add another private field as we did with the "Music" service:
         * 
         * The field will be also private and readonly "_guitarService"
         */
        private readonly IGuitarService _guitarService;

        /*
         * A controller can depend on one service, two services, or many services.
         *
         * The ASP.NET Core DI container resolves every constructor parameter independently.
         */

        // The original constructor with one service "IMusicService":
        /*
        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }
        */

        // The newer constructor with more than one service:
        // If the controller needs multiple services, list them all as constructor parameters.
        public MusicController(IMusicService musicService, IGuitarService guitarService)
        {
            _musicService = musicService;
            _guitarService = guitarService;
        }

        /*
         * Constructor Dependency Injection Explanation:
         * *********************************************
         *
         * ASP.NET Core automatically calls the controller constructor
         * when it needs to create a MusicController object.
         *
         * In our example, the constructor requires two services:
         *
         *      > IMusicService
         *      > IGuitarService
         *      > etc... if we add in the future
         *
         * The controller does NOT create these objects itself.
         *
         * Instead, the built-in Dependency Injection (DI) container:
         *
         * 1. Sees that MusicController requires:
         *      - IMusicService
         *      - IGuitarService
         *
         * 2. Looks for both registrations in Program.cs
         *
         * 3. Creates:
         *      - MusicService
         *      - GuitarService
         *
         * 4. Passes both objects to the constructor automatically.
         *
         * We never write for example:
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
         *      > GetMusicMessage() method => returns a simple text message.
         * 
         * We need to call this method in the current controller class.
         * Notice that I commented the default index() method for learning purposes,
         * but we can modify it directly or creating a new one:
         */
        public IActionResult Index()
        {
            /*
             * The controller can call methods on any injected service.
             * 
             * Notice that each service has a different responsibility:
             *      - IMusicService provides music-related functionality
             *      - IGuitarService provides guitar-related functionality
             *     
             * The controller coordinates the work by calling both services 
             * and combining their results.
             *
             * The actual use of the injected service:
             * ***************************************
             * - We call GetMusicMessage() through the interface reference "_musicService"
             * - The controller depends only on the IMusicService contract
             * - It doesn't need to know which concrete implementation
             * (such as MusicService) the DI container provides.
             */

            var musicMessage = _musicService.GetMusicMessage();

            // After adding the Guitar service, using its method:
            var guitarMessage = _guitarService.Play();

            /*
             * NOTE:
             * *****
             * After having more than one variable to retrieve a service message,
             * We need to combine them into one to be returned later:
             * 
             * Since both services return strings, we can combine them into one response.
             *
             * we can use string interpolation "$"
             * with newline "\n"
             * 
             * The '\n' escape sequence inserts a new line,
             * so each message appears on a separate line.
             *
             * Output:
             *      Our Music service is working! Wow!
             *      Strumming Guitar Chords!
             */
            var output = $"{musicMessage} \n {guitarMessage}";

            // Returns plain text (HTTP response body) as a ContentResult,
            // which implements IActionResult:

            // Original return for one message:
            // return Content(musicMessage);
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
             * - musicMessage is a string
             * - Content(musicMessage) creates a ContentResult object
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

            return Content(output);
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
         *                              > _musicService.GetMusicMessage()
         *                                  > Returns the string to the browser
         */

    } // class
} // namespace
