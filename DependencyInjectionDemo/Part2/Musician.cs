/*
 * Notice the use of "using" statement,
 * yes it's like the use of "import" statement as with Java :-)
 *
 * so we need to use using (import) the classes from Part1 folder (package in Java)
 *
 * - In C#:
 *      > using DependencyInjectionDemo.Part1;
 * - Think as with Java:
 *      > import dependency_injection_demo.part1;
 *
 * IMPORTANT NOTE:
 * ***************
 * In C#, "using" does NOT import files, it imports namespaces.
 * So it gives access to types inside that namespace.
 * 
 * In this file,
 * we do need to "using DependencyInjectionDemo.Part1;"
 * to give us access to the public classes that created in "/Part1":
 * - Guitar.cs
 * - Amplifier.cs
 * - Mic.cs
 * 
 * missing this statement will generate an error":
 * The type or namespace name 'ClassName' could not be found 
 * (are you missing a using directive or an assembly reference?)
 */

using DependencyInjectionDemo.Part1; // To access the public classes: Guitar, Amplifier, and Mic
// Unused namespaces:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Part2
{
    /*
     * Musician NO longer creates dependencies, dependencies are passed in the Constructor
     */
    public class Musician
    {
        // the musician needs to use the guitar:
        private readonly Guitar _guitar; // By convention, private class members start with "_"

        // the musician needs to use the amplifier:
        private readonly Amplifier _amp;

        // And if he wants to sing, yes he needs to use the mic
        private readonly Mic _mic;

        // Adding the constructor:
        // PART 2: Constructor Dependency Injection (Manual for now)
        // **********************************************************
        /*
         * Now the Musician no longer creates dependencies.
         * Instead, dependencies are passed from outside.
         *
         * This reduces:
         * - tight coupling
         * - hidden dependencies
         * - testing difficulty
         *
         * This is the first step toward real Dependency Injection.
         *
         * So Dependency Injection (DI) is used to implement or achieve
         * the concept of "Inversion of Control (IoC)" between classes and their dependencies.
         *
         * Instead of letting the class (in our example "Musician") create its own dependencies,
         * they are provided from the outside (as written in our main file Program.cs part2)
         *
         * In our example:
         * the instrument tools will be provided to the musician,
         * so he can just focus on playing and singing!
         *
         * Yes, many guitarists prefer to bring their own guitars :-)
         *
         * IMPORTANT CONCEPT:
         * - "Musician" is the consumer (depends on tools)
         * - Tools are the dependencies
         * - Outside code is responsible for wiring everything together
         */

        /*
         * IMPORTANT ISSUE (To be fixed/improved later in Part 3 or Part 4):
         *
         * This constructor assumes all dependencies are NOT null.
         * In real applications, we must ensure dependencies are valid
         * before using them so null checks or DI container validation is needed!
         */
        public Musician(Guitar guitar, Amplifier amp, Mic mic)
        {
            /*
             * Instead of letting the consumer class "Musician"
             * be responsible for creating its dependency "Guitar":
             *  > _guitar = new Guitar();
             *
             * We can inject the Guitar and the other two dependencies:
             *  > _guitar = guitar;
             *
             * and so on for the rest of dependencies
             *
             * The Musician does NOT care HOW the tools are created or where they come from :-)
             * 
             * This is called "Constructor Injection"
             */

            // Injecting the Guitar, Amplifier, and Mic as dependencies:
            /*
             * IMPORTANT EXTRA STEP/CAUTION:
             * *****************************
             * In real DI (and Microsoft best practice), 
             * we should protect against null dependencies!
             * 
             * So instead of immediately and just directly assign the values:
             * _guitar = guitar;
             * _amp = amp;
             * _mic = mic;
             * 
             * we can check if the field is null =>  if (guitar == null) 
             * then throw a new exception with the field name => throw new ArgumentNullException(nameof(guitar));
             * 
             * We can adapt using the following professional code:
             */
            if (guitar == null) throw new ArgumentNullException(nameof(guitar));
            if (amp == null) throw new ArgumentNullException(nameof(amp));
            if (mic == null) throw new ArgumentNullException(nameof(mic));

            /*
             * So injecting the 3 dependencies as constructor parameters,
             * we completely removed the idea of having the consumer class "Musician"
             * responsible for creating its dependencies:
             *  > new Guitar()
             *  > new Amplifier()
             *  > new Mic()
             *
             * Because Part 2 is about:
             * Musician does NOT create dependencies anymore
             *
             * This makes the code:
             * - more flexible
             * - easier to test
             * - easier to replace implementations later
             */
        } // Musician()

        // Adding a method for using the instruments (dependencies)
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