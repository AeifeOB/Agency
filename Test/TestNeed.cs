using Agency;
using System.Collections.Generic;

namespace Test
{
    /// <summary>
    /// Class to provide an Need for testing.
    /// </summary>
    class TestNeed : Need
    {
        public int Id { get; set; }

        /// <summary>
        /// Constructor for TestNeed class.
        /// </summary>
        /// <param name="level"></param>
        public TestNeed(double level) : base(level)
        {
            Level = level;
            PositiveTraits = new List<Trait>();
            NegativeTraits = new List<Trait>();
        }
    }
}
