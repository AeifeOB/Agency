using Agency;
using Example.Traits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.Actions
{
    /// <summary>
    /// An example action where an Actor goes to a new locaton. Inherits from the Action abstract class.
    /// </summary>
    class GoTo : Agency.Action
    {
        public Location Destination { get; set; }
        /// <summary>
        /// Constructor for the GoTo action.
        /// </summary>
        public GoTo(Location destination)
        {
            InputAssets = new List<Asset>();
            OutputAssets = new List<Asset>();
            Destination = destination;
        }

        /// <summary>
        /// Overriden implementation of the Execute method required by the Action abstract class.
        /// </summary>
        /// <param name="assets"></param>
        public override void Execute(Actor actor)
        {
            var locations = actor.Traits.SingleOrDefault(r => r is Location);
            if (locations != null)
                actor.Traits.Remove(locations);
            actor.Traits.Add(Destination);
            Console.WriteLine("Actor has gone to {0}", Destination.Name);
        }
    }
}


