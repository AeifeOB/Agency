using Agency;
using System;
using System.Collections.Generic;

namespace Example
{
    /// <summary>
    /// An example action where an Actor 'retires'. Used as a goal in the example. Inherits from the Action abstract class.
    /// </summary>
    class Retire : Agency.Action
    {
        /// <summary>
        /// Constructor for the Retire action.
        /// </summary>
        public Retire()
        {
            Inputs = new List<Asset>();
            Outputs = new List<Asset>();
        }

        /// <summary>
        /// Overriden implementation of the Execute method required by the Action abstract class. Simply reports that an Actor has 'retired'.
        /// </summary>
        /// <param name="assets"></param>
        public override void Execute(List<Asset> assets)
        {
            Console.WriteLine("You've retired...");
        }
    }
}
