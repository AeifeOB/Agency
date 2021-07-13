using Agency;
using System.Collections.Generic;

namespace Example.Needs
{
    /// <summary>
    /// A class representing an Actor's need to rest.
    /// </summary>
    class Rest : Need
    {
        /// <summary>
        /// Constructor for the Rest need class.
        /// </summary>
        /// <param name="level"></param>
        public Rest(double level) : base(level)
        {
            Level = level;
            PositiveTraits = new List<Trait>();
            NegativeTraits = new List<Trait>();
        }
    }
}
