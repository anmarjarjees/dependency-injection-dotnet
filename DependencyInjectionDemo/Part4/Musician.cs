/*
 * Comparison:
 *
 * Part 2:
 * Dependencies are injected through the constructor.
 *
 * Part 3:
 * Dependencies are injected through public properties.
 *
 * Part 4:
 * Dependencies are injected through interface methods.
 */
using DependencyInjectionDemo.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * IMPORTNATN NOTE:
 * ****************
 * Interface Injection is much less common than Constructor Injection
 * in modern .NET applications, but it is useful for understanding
 * how Dependency Injection can be implemented in different ways.
 */
namespace DependencyInjectionDemo.Part4
{
    /*
     * PART 4: Interface Dependency Injection
     * **************************************
     *
     * The Musician implements the IMusicToolUser interface.
     * Instead of receiving dependencies through the constructor,
     * they are provided through interface methods.
     *
     * The interface defines a contract that specifies
     * how external code can inject the required dependencies.
     */

    /*
     * The Musician requires these three dependencies to perform.
     *
     * Unlike Constructor Injection,
     * they are assigned after object creation
     * through the interface methods.
     */
    public class Musician : IMusicToolUser
    {
        /*
         * These dependencies are required for the Musician to perform.
         * Unlike Constructor Injection (Part 2), they are assigned
         * after object creation through the interface methods.
         */

        // Private dependency fields (not readonly in this example):
        /*
         * Nullable Reference Types (C# 8+) Warning:
         * *****************************************
         * Notice below, these 3 fields are intentionally initialized 
         * with what's called "the null-forgiving operator" using the symbol (!).
         *
         * Reason:
         * *******
         * Interface Injection assigns the dependencies AFTER the object is created,
         * not in the constructor. 
         * Therefore, the compiler cannot verify that these on-nullable fields 
         * will always be initialized before use.
         *
         * The null-forgiving operator tells the compiler:
         * "These fields will be assigned before they are accessed."
         *
         * This removes warning CS8618 while keeping the fields non-nullable.
         *
         * Link: https://learn.microsoft.com/dotnet/csharp/nullable-references
         * Link: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/null-safety/nullable-reference-types
         */

        // Private dependency fields (not readonly in this example)
        // private Guitar _guitar; => generates CS8618 warning
        // To Avoid warning => Initialize them with null :-)
        private Guitar _guitar = null!;
        private Amplifier _amp = null!;
        private Mic _mic = null!;

        /*
         * Other Alternative Solutions (Not recommended):
         * 1) Declare the fields nullable (?)
         *      > private Guitar? _guitar;
         *    We tell the compiler the field is allowed to be null!
         *    Not recommended as the Musician requires his tool
         *    
         * 2) Disable nullable reference types
         *      > in the XML file => <Nullable>disable</Nullable>
         *      
         * For more details about C# Programming Essentials and Nullable issues,
         * check my repos Links:
         * - https://github.com/anmarjarjees/csharp-intro
         * - https://github.com/anmarjarjees/dotnet-csharp-intro
         * - https://github.com/anmarjarjees/csharp-essentials
         */

        /*
         * Note:
         * *****
         * We cannot use "readonly" here 
         * because these dependencies are assigned after object construction
         * through the interface methods.
         */

        /*
         * Injecting (assigning) the Guitar dependency:
         *  > The Musician does not create the Guitar
         *  > It is provided by external code (the caller)
         */
        public void SetGuitar(Guitar guitar)
        {
            _guitar = guitar;
        }

        /*
        * Injecting (assigning) the Amplifier dependency:
        *  > The Musician does not create the Amplifier
        *  > It is provided by external code
        */
        public void SetAmplifier(Amplifier amplifier)
        {
            // Notice that we removed the generated exceptions code line:
            // throw new NotImplementedException();

            // We added our custom code:
            _amp = amplifier;
        }

        /*
        * Injecting (assigning) the Microphone dependency:
        *  > The Musician does not create the Mic
        *  > It is provided by external code
        */
        public void SetMic(Mic mic)
        {
            // throw new NotImplementedException();
            _mic = mic;
        }

        /*
         * WARNING:
         * If these interface methods are never called,
         * the dependencies remain null.
         *
         * Calling Perform() before setting the dependencies
         * would cause a "NullReferenceException"
         *
         * This is one reason Constructor Injection is the preferred approach
         * for required dependencies in modern .NET applications :-)
         */
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