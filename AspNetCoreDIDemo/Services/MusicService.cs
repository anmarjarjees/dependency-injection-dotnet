namespace AspNetCoreDIDemo.Services
{
    /*
     * Class "MusicService":
     * *********************
     * This class provides the actual implementation of the "IMusicService" interface
     *
     * Remember:
     * *********
     * - IMusicService:
     *      > Defines WHAT the service can do (contract)
     *
     * - MusicService:
     *      > Defines HOW the service does it (implementation)
     *
     * Relationship:
     * *************
     * "IMusicService" Interface == implemented by ==> "MusicService" class
     * 
     * NOTE:
     * *****
     * MusicService implements the IMusicService contract (but it's not DI yet),
     * we only created the abstraction "IMusicService",
     * plus the concrete implementation "MusicService"
     * 
     * So,the DI part comes in the next step when we tell ASP.NET Core:
     *      - Whenever a class requests IMusicService:
     *          > ASP.NET Core knows that it should provide MusicService as the implementation
     *  
     *      - And this happens in "Program.cs", in this code line:
     *          > builder.Services.AddTransient<IMusicService, MusicService>();
     *  
     * DI lifetimes:
     * *************
     * - AddTransient => creates a new instance when requested
     * - AddScoped => creates/reuses within a scope
     * - AddSingleton => creates one instance for application lifetime
     * 
     * Notice that our class "MusicService" is "stateless".
     * 
     * Why "stateless"?
     * Because tt has:
     *  - no fields storing changing information
     *  - no properties storing user/application state
     *  - no counters
     *  - no stored data
     *  
     *  It simply performs an operation and returns a result.
     *  Each instance starts with the same state,
     *  and previous calls do not affect future calls.
     *  
     *  This is the definition of a stateless service.
     */

    /*
     * To Review: 
     * **********
     * The ":" symbol here, means that MusicService implements IMusicService.
     * This means MusicService agrees to follow the contract defined by the interface.
     */
    public class MusicService : IMusicService
    {
        /*
         * Because MusicService implements IMusicService,
         * it must provide implementations for the required members defined by the interface:
         * 
         *  > GetMusicMessage()
         *  
         * The method name itself is only for demonstration.
         *  
         * In real applications, services usually expose business operations such as:
         *  - IProductService.GetProducts()
         *  - IEmailService.SendEmail()
         *  - IUserService.GetUserById()
         */

        public string GetMusicMessage()
        {
            return "Our Music service is working! Wow!";
        }



    } // class MusicService
} // namespace