﻿using System.Collections.Generic;

namespace Agency
{
    /// <summary>
    /// An abstract class to represent actions that can be done by an Actor in framework.
    /// </summary>
    public abstract class Action
    {
        public List<Asset> InputAssets { get; set; }
        public List<Asset> OutputAssets { get; set; }
        public List<Trait> InputTraits { get; set; }
        public List<Trait> OutputTraits { get; set; }

        /// <summary>
        /// Default constructor for the Action abstract class. Initialises empty Inputs/Outputs lists.
        /// </summary>
        public Action()
        {
            InputAssets = new List<Asset>();
            OutputAssets = new List<Asset>();
            InputTraits = new List<Trait>();
            OutputTraits = new List<Trait>();
        }

        /// <summary>
        /// The default implementation of the Execute method. This method allows an action to be executed. 
        /// The default implementation removes each asset required by the action (Inputs) from the list of 
        /// assets provided, and then adds each asset in the Outputs  variable to the provided list of assets.
        /// </summary>
        /// <param name="assets"></param>
        public virtual void Execute(Actor actor)
        {
            foreach (Asset asset in this.InputAssets)
            {
                actor.AvailableAssets.Remove(asset);
            }
            foreach (Asset asset in this.OutputAssets)
            {
                actor.AvailableAssets.Add(asset);
            }
            foreach (Trait trait in this.OutputTraits)
            {
                actor.Traits.Add(trait);
            }
        }

    }
}
