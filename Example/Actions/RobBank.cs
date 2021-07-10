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
            InputAssets = new List<Asset>();
            OutputAssets = new List<Asset>();
        }

        /// <summary>
        /// Overriden implementation of the Execute method required by the Action abstract class.
        /// </summary>
        /// <param name="assets"></param>
        public override void Execute(Actor actor)
        {
            foreach (Asset requiredAsset in this.InputAssets)
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
            foreach (Asset aquiredAsset in this.OutputAssets)
            {
                actor.AvailableAssets.Add(aquiredAsset);
            }
        }
    }
}
