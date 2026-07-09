/*
 * NOTE:
 * use => using DependencyInjectionDemo.Part1;
 * to access the 3 classes from Part1
 */
using DependencyInjectionDemo.Part1;
// Unused namespaces:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PART 3: Property (Setter) Dependency Injection
// **********************************************
namespace DependencyInjectionDemo.Part3
{
    // changing "internal" to "public":
    public class Musician
    {
        // Using Setters DI instead of Constructor DI
        // Creating 3 properties for the 3 dependencies:
        /*
         * Notice that we need to call these 3 classes "Guitar", "Amplifier", and "Mic"
         * from /Part1 where they were created!
         * 
         * Two different ways:
         * 1) public Part1.Guitar Guitar { get; set; }
         * OR:
         * 2) using DependencyInjectionDemo.Part1;
         *    THEN: public Guitar Guitar { get; set; }
         */
        public Guitar Guitar { get; set; } // notice the PascalCase for the public properties
        public Amplifier Amplifier { get; set; }
        public Mic Mic { get; set; }
        /*
         * These dependency properties are NOT assigned when the object is created.
         * They will be assigned later from Program.cs using property (setter) injection.
         */

        // Removing the passed parameters (dependencies) from the constructor:
        /*
         * Since we added the public property for each dependency,
         * we don't need to create a constructor, we can just use the default constructor
         */

        // Adding a method for using the instruments (dependencies)
        // A method for using the Amplifier, the Guitar, and the Mic
        // The musician is starting his performance using his tools:
        public void Perform()
        {
            // Using the amplifier: Turning it on

            // Using the mic: Singing with the mic

            // Using the guitar: Playing Chords :-)  

            Console.WriteLine("Performance and Music Started");
        } // Perform()

    } // Musician
} // namespace
