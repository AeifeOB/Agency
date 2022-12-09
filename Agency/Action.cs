using System.Collections.Generic;

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
        /// <param name="actor"></param>
        public virtual void Execute(Actor actor)
        {
            if (this.CanExecute(actor)) {
                // Use required asset and acquire output assets
                foreach (Asset requiredAsset in this.InputAssets)
                {
                    actor.use(requiredAsset);
                }
                foreach (Asset asset in this.OutputAssets)
                {
                    actor.acquire(asset);
                }

                // Update needs.
                foreach (Trait effect in this.OutputTraits)
                {
                    var need = actor.Needs.Find(n => n.GetType() == effect.need.GetType());
                    need.Level += effect.need.Level;
                }
            }
        }

        /// <summary>
        /// Default check to see if an actor can execute an action. This method checks if the actor has the required assets and traits.
        /// </summary>
        /// <param name="actor"></param>
        public virtual bool CanExecute(Actor actor)
        {
             // Check if the actor has the required traits
            foreach (Trait trait in InputTraits)
            {
                if ((trait.need is not null)){
                    foreach (Need need in actor.Needs) {
                        if (trait.need.GetType() == need.GetType()) {
                            if (trait.need.Level > need.Level) {
                                return false;
                            }
                        }
                    }
                } else {
                    if (!actor.Traits.Contains(trait))
                    {
                        return false;
                    }
                }
            }
            foreach (Asset requiredAsset in this.InputAssets)
            {
                // Check if the actor has the required assets
                Asset asset = actor.AvailableAssets.Find(asset => asset.GetType() == requiredAsset.GetType());
                if (asset == null || asset.quantity < requiredAsset.quantity) {
                    return false;
                }
            }
            return true;
        }
    }
}
