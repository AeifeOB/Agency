using System.Collections.Generic;

namespace Agency
{
    /// <summary>
    /// A class to hold plans that can be used by an actor. These are made up of a series of Actions that can be executed.
    /// </summary>
    public class Plan
    {
        public List<Action> Actions { get; set; }

        /// <summary>
        /// Constructor for the Plan class
        /// </summary>
        public Plan()
        {
            this.Actions = new List<Action>();
        }

        /// <summary>
        /// Method to execute each action in Plan, starting from the last plan entered and working back to the first.
        /// </summary>
        /// <param name="assets"></param>
        public void Execute(List<Asset> assets)
        {
            this.Actions.Reverse();
            foreach (Action action in this.Actions)
            {
                action.Execute(assets);
            }
        }
    }
}
