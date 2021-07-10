using Agency;
using Example.Assets;
using Example.Traits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.Actions
{
    /// <summary>
    /// An example action where an Actor 'retires'. Used as a goal in the example. Inherits from the Action abstract class.
    /// </summary>
    class Retire : Agency.Action
    {
        public Location RetirementLocation { get; set; }
        /// <summary>
        /// Constructor for the Retire action.
        /// </summary>
        public Retire(Location retirementLocation)
        {
            Inputs = new List<Asset>();
            Outputs = new List<Asset>();
            RetirementLocation = retirementLocation;
        }

        /// <summary>
        /// Overriden implementation of the Execute method required by the Action abstract class. Changes Actor's location to the retirement location and adds the 'Retired' trait.
        /// </summary>
        /// <param name="assets"></param>
        public override void Execute(Actor actor)
        {
            foreach(Asset requiredAsset in this.Inputs)
            {
                var potentialAsset = actor.AvailableAssets.Where(requiredAsset => true);
                if (potentialAsset == null)
                {
                    throw new Exception(String.Format("Unable to retire - missing {0}", requiredAsset.GetType()));
                }
            }
            Console.WriteLine("You've retired to {0}", RetirementLocation.Name);
            var locations = actor.Traits.SingleOrDefault(r => r is Location);
            if (locations != null)
                actor.Traits.Remove(locations);
            actor.Traits.Add(RetirementLocation);
            actor.Traits.Add(new Retired());
        }
    }
}
