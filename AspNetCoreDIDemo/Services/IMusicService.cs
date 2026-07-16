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
     *  - ILogger<T>  => Logging implementation (Logging Contract)
     *  - IConfiguration => Configuration implementation (Configuration Contract)
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
        string GetMusicMessage();
        /*
         * GetMusicMessage() is only a simple demonstration method
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

        /*
         * Interface members access modifiers:
         * ***********************************
         * Notice that we declared our method as:
         *  > string GetMusicMessage();
         * 
         * Not as we do in a class:
         *  > public string GetMusicMessage();
         *  
         * Historically, interface members were always public.
         * Modern C# allows additional interface members (such as private helper methods),
         * but the normal interface contract used for DI consists of public members.
         * 
         * Remember that an interface represents a contract 
         * that other classes must be able to see and implement.
         * 
         * So => string GetMusicMessage();
         * means => Any class that implements IMusicService 
         *          must provide a public method called GetMusicMessage().
         * 
         * The compiler already knows this method is public.
         * So adding/writing "public" explicitly is accepted (no problems),
         * But Microsoft's examples usually omit it.
         * 
         * In normal C# interfaces:
         * ************************
         * - Public methods are the standard approach
         * - Interface methods without an access modifier are public by default
         * 
         * NOTE:
         * *****
         * Modern C# also allows private interface members,
         * but they are helper methods inside the interface
         * and are not part of the contract implemented by classes.
         * 
         * Protected interface members are not allowed.
         * 
         * For Dependency Injection:
         * *************************
         * We usually keep interfaces simple and expose only the public contract needed by consumers.
         * 
         * To summarize:
         * *************
         * - Class members:
         *      > If no access modifier is specified, class members are private by default
         * - Interface members:
         *      > Public contract members are normally declared without an access modifier
         *      > Modern C# also supports private interface members for internal helper logic.
         *      
         * Link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface
         */
    } // interface
} // namespace
