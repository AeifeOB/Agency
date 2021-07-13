using Agency;
using System.Collections.Generic;

namespace Example.Needs
{
    /// <summary>
    /// A class representing an Actor's need for power.
    /// </summary>
    class Power : Need
    {
        /// <summary>
        /// Constructor for the Power need class.
        /// </summary>
        /// <param name="level"></param>
        public Power(double level) : base(level)
        {
            Level = level;
            PositiveTraits = new List<Trait>();
            NegativeTraits = new List<Trait>();
        }
    }
}
