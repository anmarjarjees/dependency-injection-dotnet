// Unused "using" auto-generated statements:
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/


namespace DependencyInjectionDemo.Part1
{
    // Dependency #2: The "Amplifier"
    // ******************************
    // A musician might need another tool for example: "Amplifier"
    // Represents another dependency required by the Musician
    public class Amplifier
    {
        // Simulates turning on the amplifier:
        public void TurnOn()
        {
            Console.WriteLine("Amplifier ON!");
        }
    } // Amplifier
} // namespace