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
     *  > "Whenever someone asks for IMusicService, provide an instance of MusicService."
     *  
     * And this happens in "Program.cs", in this code line:
     *  > builder.Services.AddTransient<IMusicService, MusicService>();
     */

    /*
     * To Review: 
     * **********
     * The ":" symbol means that MusicService implements IMusicService.
     * This means MusicService agrees to follow the contract defined by the interface.
     */
    public class MusicService : IMusicService
    {
        /*
         * Because MusicService implements IMusicService,
         * it must provide implementations for the required members defined by the interface:
         * 
         *  > GetMessage()
         */

        public string GetMessage()
        {
            return "Our Music service is working! Wow!";
        }

    } // MusicService
} // namespace