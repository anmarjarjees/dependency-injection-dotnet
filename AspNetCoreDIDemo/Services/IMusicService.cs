/*
 * This Interface file represents the transition from:
 *
 *      > Understanding DI manually with C# classes
 *
 * to:
 *
 *      > Preparing services to be managed by the ASP.NET Core
 *      built-in Dependency Injection container
 */
namespace AspNetCoreDIDemo.Services
{
    /*
     * Interface "IMusicService":
     * **************************
     * As we learnt in Java and C# courses/repos when we covered "Interfaces":
     *  - An "interface" defines a contract
     *  - It describes WHAT a service can do, but it does not provide HOW the work is done.
     *  
     * For Interfaces reviewing, below are links to my JAVA/C# repos:
     * - https://github.com/anmarjarjees/csharp-essentials/tree/main/Topic5OOP
     * - https://github.com/anmarjarjees/dotnet-csharp-intro/tree/fd5892f325dbc2a797da1f8529fef4d9bfc99326/Part04ObjectOrientedBasics
     * - https://github.com/anmarjarjees/java-oop-uml
     * - https://github.com/anmarjarjees/java2-code/tree/355176b9e3405ea68cced57ebfb647d67df72755/week10/src/interfaces_intro
     * - https://github.com/anmarjarjees/design-patterns/tree/fcac7111bfac57660a5286ca03d0a5dea58babae/src/structural_patterns/composite_pattern
     *  
     * So here we are defining contract for a music-related service.
     * 
     * In Dependency Injection:
     * The application will depend on this abstraction (interface)
     * instead of depending directly on a concrete class.
     *
     * Benefits:
     * - reduces tight coupling
     * - makes testing easier
     * - allows replacing the implementation later
     * 
     * Example:
     *  > IMusicService  ==> contract
     *  > MusicService   ==> implementation
     *
     * 
     * Notice we used singular name "IMusicService" not "IMusicServices":
     *  > IMusicService = one service contract (singular)
     *  > IMusicServices = sounds like a collection of multiple services
     *  
     *  Examples of Microsoft interface naming:
     *  - ILogger => Logger implementation
     *  - IConfiguration => EmailService implementation
     *  - IProductService => ProductService implementation
     */
    public interface IMusicService
    {
        // Method declaration only (adding one simple custom method declaration):
        /*
         * Notice:
         * - No method body {}
         * - No implementation code
         *
         * Any class that implements this interface
         * must provide the actual implementation
         * of this method.
         */
        string GetMessage();
        /*
         * GetMessage() is only a simple demonstration method
         * that allows us to see the service being called through DI.
         * 
         * In a real-world example, this simple code (demo) can look like:
         * 
         * IProductService
         *      GetProducts()
         *      
         * IEmailService
         *     SendEmail()
         *     
         * IUserService
         *     GetUserById()
         */
    } // interface
} // namespace
