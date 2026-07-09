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
    // Dependency #3: The "Mic" (Microphone)
    // *************************************
    // A musician might need another tool for example: "Mic (Microphone)"
    // Represents another dependency required by the Musician
    public class Mic
    {
        // Simulates singing through the microphone:
        public void Sing()
        {
            Console.WriteLine("Mic is ON");
        }
    } // Mic
} // namespace
