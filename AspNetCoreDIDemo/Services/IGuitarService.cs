namespace AspNetCoreDIDemo.Services
{
    /*
     * Interface "IGuitarService":
     * **************************
     * This interface defines the contract for a guitar-related service.
     *
     * Similar to IMusicService:
     *
     * IGuitarService:
     *      > Defines WHAT the service can do
     *
     * GuitarService:
     *       > Provides the actual implementation of the contract defined by IGuitarService
     *
     * In Dependency Injection:
     * ************************
     * The consumer (Controller) depends on this abstraction,
     * not the concrete implementation.
     *
     * Relationship:
     * *************
     * > IGuitarService (contract)
     *      >> implemented by
     *              > GuitarService (implementation)
     */
    public interface IGuitarService
    {
        /*
         * Let's add (declare) one simple method,
         * Remember that our repo started with these simple methods:
         * - Guitar.Paly()
         * - Amplifier.TurnOn()
         * - Mic.Sing()
         * 
         * so let's name it Play()?
         * 
         * - By C# convention, public methods' names are PascalCase
         * - Interfaces can ONLY have method declaration (no body - no implementation)
         */ 
        string Play();
        /*
         * Notice:
         * We don't write "public" here:
         *
         *      public string Play();
         *
         * because interface members are public by default.
         */
    } // interface
} // namespace