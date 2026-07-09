/*
 * Either use "using DependencyInjectionDemo.Part1;"
 * so we can simply just: var objectName = new Musician()
 * Or:
 * ignore/comment/remove this line "using DependencyInjectionDemo.Part1;"
 * so we have to specify: var objectName = new Part1.Musician()
 * 
 * To avoid confusion about which Musician class we are calling,
 * we will remove this line: using DependencyInjectionDemo.Part1;
 * Then we can specify through the code which Musician class of which class we are calling:
 * Examples:
 * var object1 = new Part1.Musician();
 * var object2 = new Part2.Musician();
 * var object3 = new Part3.Musician();
 * and so on...
 */
//using DependencyInjectionDemo.Part1;

namespace DependencyInjectionDemo
{
    // PART 1: WHAT IS A DEPENDENCY:
    // *****************************
    /*
     * A dependency is an object that another class needs in order to work
     *
     * In this example:
     * - Musician depends on Guitar, Amplifier, and Mic
     *
     * WITHOUT Dependency Injection:
     * - Musician creates its own dependencies (bad design for now)
     */

    // Dependency #1: The "Guitar" => refer to Part1/Guitar.cs
    // *******************************************************

    // Dependency #2: The "Amplifier" => refer to Part1/Amplifier.cs
    // *************************************************************
    // A musician might need another tool for example: "Amplifier"


    // Dependency #3: The "Mic" (Microphone)  => refer to Part1/Mic.cs
    // ***************************************************************
    // A musician might need another tool for example: "Mic (Microphone)"

    // The consumer class "Musician" => refer to Part1/Musician.cs
    // ***********************************************************
    /*
    * In this example, the Musician depends on:
    * - Guitar
    * - Amplifier
    * - Mic
    * Which is an example of "Dependencies"
    * So the "Guitar", "Amplifier", and "Mic" are dependencies of the "Musician"
    */

    // The main class "Program" that contains the "Main" method:
    // Main() => the entry point to our application
    internal class Program
    {
        static void Main(string[] args)
        {
            // **************************************
            // Part#1: No use of DEPENDENCY INJECTION
            // **************************************
            Console.WriteLine("DEPENDENCY INJECTION ISSUE - PART 1");

            /*
             * Using "var" vs explicit type (Musician):
             *
             * - var uses type inference (compiler already knows it is Musician)
             * - Musician is explicit typing (more readable for beginners and developers from other languages)
             * - Both represent the same type at runtime
             *
             * Recommended usage:
             * - use var when the type is obvious from the right side
             * - use explicit type when clarity is more important than brevity
             *
             * Link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/declarations
             */

            // var musician = new Musician(); // (Part1 moved into its own namespace)
            var musician1 = new Part1.Musician();
            musician1.Perform();
            /*
            * So we have the guitar, the amp, and the mic as dependencies of the musician.
            * These dependencies are CREATED inside the Musician class (Part 1 problem).
            */

            // ********************************************
            // Part#2: DEPENDENCY INJECTION: Constructor DI
            // ********************************************
            /*
             * NOTE:
             * *****
             * This is NOT yet using Microsoft DI container (IServiceCollection).
             * We are still manually doing dependency injection.
             * Real ASP.NET Core DI comes later.
             */
            Console.WriteLine("\nDEPENDENCY INJECTION - PART 2");

            // Creating the 3 required objects outside the consumer class "Musician"
            /*
             * Calling the classes from Part1:
             */
            var guitar = new Part1.Guitar();
            var amp = new Part1.Amplifier();
            var mic = new Part1.Mic();

            /*
             * REVIEW: var vs Explicit Type in C#
             * ***********************************
             *
             * Example:
             * var guitar = new Guitar();
             * Guitar guitar = new Guitar();
             *
             * Both are EXACTLY the same at runtime:
             * - "var" tells the compiler to infer the type automatically
             * - The type is already known from the right side (new Guitar())
             *
             * So we use "var":
             * - When the type is obvious from the right side
             * - To make code cleaner and less repetitive
             *
             * But we use explicit type:
             * - When we want to make the type very clear for beginners
             * - When the return type is not obvious
             *
             * Important NOTE:
             * - var does NOT mean "dynamic".
             * - The type is still strongly typed (fixed at compile time).
             *
             * Link:
             * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var
             */

            // Passing the guitar, amp, and mic to the musician2
            var musician2 = new Part2.Musician(guitar, amp, mic);
            musician2.Perform();

            Console.WriteLine("*************");


            // ****************************************
            // Part#3: DEPENDENCY INJECTION: Setters DI
            // ****************************************
            Console.WriteLine("\nDEPENDENCY INJECTION - PART 3");

            // Using the default constructor (no dependencies yet):
            var musician3 = new Part3.Musician();
            /*
             * The Musician object is created first.
             * At this point, all dependency properties are still null
             *
             * The dependencies are injected afterward
             * through the public setter properties
             */

            // now preparing the dependencies "instruments/tools" to be used by the consumer "Musician":
            // Injecting the 3 dependencies via setters:
            musician3.Guitar = guitar;
            musician3.Mic = mic;
            musician3.Amplifier = amp;

            musician3.Perform();


            // **********************************************
            // Part#4: DEPENDENCY INJECTION: Interface DI
            // **********************************************
            Console.WriteLine("\nDEPENDENCY INJECTION - PART 4");

            // Creating the consumer object:
            var musician4 = new Part4.Musician();

            /*
             * The "Musician" implements the "IMusicToolUser" interface.
             *
             * Instead of using constructor parameters or public properties,
             * the dependencies are injected through interface methods
             * defined by the interface contract.
             */

            // Injecting the dependencies through interface methods:
            musician4.SetGuitar(guitar);
            musician4.SetAmplifier(amp);
            musician4.SetMic(mic);

            // The Musician is now ready to perform
            musician4.Perform();

        } // Main()
    } // Program
} // namespace