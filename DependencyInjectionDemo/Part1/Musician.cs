/*
 * NOTE:
 * *****
 * Some using statements are automatically added when creating a new C# file
 * or project from Visual Studio templates
 * 
 * Not all of them are needed in this example
 */
// Unused namespaces:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * ABOUT "Implicit Usings":
 * ************************
 * In older .NET projects (before Implicit Usings):
 *
 * System.Console.WriteLine("...");
 *
 * Modern .NET projects enable "Implicit Usings" by default,
 * so common namespaces (such as "System") are automatically available.
 * That's why many "using" statements are no longer required.
 *
 * If Implicit Usings are disabled, we would need:
 *
 * using System;
 *
 * Link:
 * https://learn.microsoft.com/dotnet/core/project-sdk/msbuild-props#implicitusings
 */

namespace DependencyInjectionDemo.Part1
{
    // The consumer class "Musician"
    // *****************************
    /*
    * In this example, the Musician depends on:
    * - Guitar
    * - Amplifier
    * - Mic
    * Which is an example of "Dependencies"
    * So the "Guitar", "Amplifier", and "Mic" are dependencies of the "Musician"
    * 
    * Musician creates its own dependencies:
    * - new Guitar()
    * - new Amplifier()
    * - new Mic()
    */

    /*
     * ACCESS MODIFIERS IN C# IMPORTANT REVIEW:
     * ****************************************
     * 
     * By default, C# use "internal" access modifier
     * "internal" => accessible only inside the same project (assembly)
     * 
     * Unlike "Java" where we have 3 access modifiers, C# has 6 main access levels:
     *  > public => Accessible from anywhere in the application
     *  > private => Accessible only inside the same class
     *  > protected => Accessible inside the class and derived classes
     *  > internal (DEFAULT for classes) =>  Accessible only within the same project (assembly)
     *  > protected internal => Accessible from derived classes OR same project
     *  >  private protected => Accessible only in derived classes within the same project
     * 
     * Link: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
     * 
     * NOTE:
     * *****
     * Program class is usually internal because it is only used as the application entry point.
     * In this tutorial, we may use public for learning clarity.
     */
    public class Musician
    {

        /*
         * ABOUT "Immutable":
         * ******************
         * These 3 dependencies are required for the Musician to function
         * and are assigned once during construction (in the constructor)
         * After construction, they cannot be changed (immutable references).
         * 
         * Immutable = cannot be changed after creation 
         */

        // the musician needs to use the guitar:
        private readonly Guitar _guitar; // By C# conventions, using _ with private fields

        // the musician needs to use the amplifier:
        private readonly Amplifier _amp;

        // and if he wants to sing, yes he needs to use the mic
        private readonly Mic _mic;

        /*
         * C# "readonly" NOTE:
         * *******************
         * Notice that all the above 3 fields "Guitar", "Amplifier", and "Mic"
         * are assigned only once in the constructor and never changed afterward, 
         * Microsoft would typically recommend making them "readonly"
         * 
         * That's why removing the "readonly", will show a warning:
         * "IDE0044: Make field readonly"
         * 
         * "readonly":
         *  > These references are assigned once during construction
         *  > and cannot be reassigned later
         * 
         * 
         * Link: https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0044
         * Link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly
         */

        // Adding the constructor:
        public Musician()
        {
            /*
             * PROBLEM (we will fix in Part 2):
             * The Musician is responsible for creating its dependencies.
             * In other words, he is responsible for bringing his tools.
             *
             * In some real-world scenarios, a musician does not provide his own instruments.
             * They are usually provided by an external source.
             * For example, a pianist does not bring an acoustic piano to every performance.
             * Yes, except for guitarists and other easy-to-carry or stage instruments :-)
             *
             * This means:
             * - tight coupling
             * - hard to test
             * - hard to replace implementations
             * - difficult to scale in real applications
             * - violates Dependency Inversion Principle (DIP)
             */

            // Musician creates its own dependencies:
            _guitar = new Guitar();
            _amp = new Amplifier();
            _mic = new Mic();
            /*
             * NOW: After constructing (new...) the the 3 instruments: _guitar, _amp, _mic
             * _guitar is fixed
             * _amp is fixed
             * _mic is fixed
             * 
             * We cannot reassign them later
             */
        } // Musician()

        // A method that uses the musician's dependencies (instruments)
        // A method for using the Amplifier, the Guitar, and the Mic
        // The musician is starting his performance using his tools:
        public void Perform()
        {
            // Using the amplifier:
            _amp.TurnOn();

            // Using the mic:
            _mic.Sing();

            // Using the guitar:
            _guitar.Play();

            Console.WriteLine("Performance and Music Started");
        } // Perform()
    } // Musician
} // namespace
