// Required: gives access to the dependency classes from Part1
using DependencyInjectionDemo.Part1;

// Unused using statements:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Part4
{
    // internal => public
    /*
     * Creating the Interface:
     *  - Interface is not a music tool
     *  - Interface represents something that can receive music tools (dependencies)
     *  Therefore, a meaningful name for this interface is "IMusicToolUser"
     *  
     *  The Interface name "IMusicToolUser":
     *   - Describes exactly what the interface represents
     *   - Any class implementing this interface can receive music tool dependencies from external code
     *
     * C# Interface Naming Convention:
     * *******************************
     * By convention, interface names begin with the capital letter "I".
     *
     * Examples:
     * - IDisposable
     * - IEnumerable
     * - ILogger
     * - IMusicToolUser (our example)
     *
     * The "I" prefix immediately tells developers 
     * that this type defines a contract rather than an implementation
     *
     * Link:
     * https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces
     */
    public interface IMusicToolUser
    {
        /*
         * This interface defines a contract.
         * It specifies WHAT dependencies can be provided,
         * but not HOW they are created.
         */
        // Setter methods: "Set" means provide (inject) a dependency
        void SetGuitar(Guitar guitar);
        void SetAmplifier(Amplifier amplifier);
        void SetMic(Mic mic);
    } // Interface
} // namespace
