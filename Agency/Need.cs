using System.Collections.Generic;

namespace Agency
{
    /// <summary>
    /// An abstract class for all Needs to inherit from.
    /// </summary>
    public class Need
    {
        public double Level { get; set; }
        public List<Trait> PositiveTraits { get; set; }
        public List<Trait> NegativeTraits { get; set; }

        /// <summary>
        /// The constructor for the Actor class.
        /// </summary>
        public Need(double level)
        {
            Level = level;
            PositiveTraits = new List<Trait>();
            NegativeTraits = new List<Trait>();
        }

        /// <summary>
        /// Alternate constructor for the Actor class.
        /// </summary>
        public Need(double level, List<Trait> positiveTraits, List<Trait> negativeTraits)
        {
            Level = level;
            PositiveTraits = positiveTraits;
            NegativeTraits = negativeTraits;
        }
    }
}
