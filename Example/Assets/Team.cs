using Agency;

namespace Example
{
    /// <summary>
    /// A class representing a team of Actors asset in the framework. Inherits in Asset abstract class.
    /// </summary>
    class Team : Asset
    {
        public int Members { get; set; }

        /// <summary>
        /// Constructor for the Team asset class.
        /// </summary>
        /// <param name="members"></param>
        public Team(int members)
        {
            this.Members = members;
        }
    }
}
