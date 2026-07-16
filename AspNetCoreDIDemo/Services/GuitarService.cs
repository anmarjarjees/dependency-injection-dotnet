namespace AspNetCoreDIDemo.Services
{
    /*
     * Class "GuitarService":
     * **********************
     * This class provides the actual implementation of the "IGuitarService" interface
     *
     * Remember:
     * *********
     * IGuitarService:
     *      > Defines WHAT the service can do (contract)
     *
     * GuitarService:
     *      > Provides the actual implementation of that contract
     *
     * Relationship:
     * *************
     * > IGuitarService (Interface)
     *      >> implemented by
     *          > GuitarService (Class)
     *
     * At this stage:
     * **************
     * We have:
     * 1) Created the abstraction (IGuitarService)
     * 2) Created the implementation (GuitarService)
     *
     * However, this is not Dependency Injection yet.
     *
     * The DI step happens when we register this mapping inside Program.cs:
     *
     *      > builder.Services.AddTransient<IGuitarService, GuitarService>();
     *
     * Then ASP.NET Core knows:
     *      > Whenever a class requests IGuitarService,
     *      > provide GuitarService as the implementation."
     */
    public class GuitarService : IGuitarService
    {
        /*
         * Because "GuitarService" implements "IGuitarService",
         * it must provide the implementation of:         
         *      > string Play();
         */

        public string Play()
        {
            return "Strumming Guitar Chords!";
        }
    } // class GuitarService
} // namespace