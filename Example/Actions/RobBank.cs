using Agency;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.Actions
{
    /// <summary>
    /// An example action where an Actor robs a bank. Inherits from the Action abstract class.
    /// </summary>
    class RobBank : Agency.Action
    {
        /// <summary>
        /// Constructor for the RobBank action.
        /// </summary>
        public RobBank()
        {
            Inputs = new List<Asset>();
            Outputs = new List<Asset>();
        }

        /// <summary>
        /// Overriden implementation of the Execute method required by the Action abstract class.
        /// </summary>
        /// <param name="assets"></param>
        public override void Execute(Actor actor)
        {
            foreach (Asset requiredAsset in this.Inputs)
            {
                var potentialAsset = actor.AvailableAssets.Where(requiredAsset => true);
                if (potentialAsset == null)
                {
                    throw new Exception(String.Format("Unable to rob bank - missing {0}", requiredAsset.GetType()));
                }
                else
                {
                    actor.AvailableAssets.Remove(potentialAsset.First());
                }
            }
            foreach (Asset aquiredAsset in this.Outputs)
            {
                actor.AvailableAssets.Add(aquiredAsset);
            }
        }
    }
}
