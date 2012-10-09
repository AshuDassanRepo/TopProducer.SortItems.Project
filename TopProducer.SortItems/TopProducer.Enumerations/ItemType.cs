using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopProducer.Enumerations
{
    /// <summary>
    /// Enum to define the type of Item it will be.
    /// </summary>
    public enum ItemType : long
    {
        /*
         *  - unnamed without dependencies
            - unnamed with dependencies
            - named without dependencies
            - named with dependencies
         */
        UnNamedWithoutDependency = 1,
        UnNamedWithDependecy = 2,
        NamedWithoutDependency = 3,
        NamedWithDependencies = 4
    }
}
