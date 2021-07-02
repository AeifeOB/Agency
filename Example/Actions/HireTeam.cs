using Agency;
using System.Collections.Generic;

namespace Example
{
    /// <summary>
    /// An example action where an Actor hires a Team. Inherits from the Action abstract class.
    /// </summary>
    class HireTeam : Action
    {
        /// <summary>
        /// Constructor for the HireTeam action.
        /// </summary>
        public HireTeam()
        {
            Inputs = new List<Asset>();
            Outputs = new List<Asset>();
        }
    }
}
