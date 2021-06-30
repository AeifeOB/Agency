using Agency;
using System.Collections.Generic;

namespace Example
{
    /// <summary>
    /// An example action where an Actor robs a bank. Inherits from the Action abstract class.
    /// </summary>
    class RobBank : Action
    {
        /// <summary>
        /// Constructor for the RobBank action.
        /// </summary>
        public RobBank()
        {
            Inputs = new List<Asset>();
            Outputs = new List<Asset>();
        }
    }
}
