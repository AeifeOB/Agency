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
        public List<Asset> Assets { get; set; }


        /// <summary>
        /// The constructor for the Needs class. 
        /// Level - level that the needs is satisfied to.
        /// PositiveTraits - List of traits that will be added to the actor if the need is satisfied.
        /// NegativeTraits - List of traits that will be removed from the actor if the need is satisfied.
        /// </summary>
        public Need(double level)
        {
            Level = level;
            PositiveTraits = new List<Trait>();
            NegativeTraits = new List<Trait>();
            Assets = new List<Asset>();
        }

        /// <summary>
        /// Alternate constructor for the Needs class.
        /// </summary>
        public Need(double level, List<Trait> positiveTraits, List<Trait> negativeTraits)
        {
            Level = level;
            PositiveTraits = positiveTraits;
            NegativeTraits = negativeTraits;
            Assets = new List<Asset>();
        }

        /// <summary>
        /// Alternate constructor for the Needs class.
        /// </summary>
        public Need(double level, List<Asset> assets)
        {
            Level = level;
            PositiveTraits = new List<Trait>();
            NegativeTraits = new List<Trait>();
            Assets = assets;
        }
    }
}
