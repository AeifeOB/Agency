using System.Collections.Generic;
using System.Linq;

namespace Agency
{
    /// <summary>
    /// The Actor class used to represent an agent in the Agency framework.
    /// </summary>
    public class Actor
    {
        public List<Action> AvailableActions { get; set; }
        public List<Asset> AvailableAssets { get; set; }
        public List<Trait> Traits { get; set; }
        public List<Action> Goals { get; set; }
        public Plan CurrentPlan { get; set; }

        /// <summary>
        /// The constructor for the Actor class.
        /// </summary>
        public Actor()
        {
            AvailableActions = new List<Action>();
            AvailableAssets = new List<Asset>();
            Traits = new List<Trait>();
            Goals = new List<Action>();
            CurrentPlan = new Plan();
        }

        /// <summary>
        /// Method for an Actor to create a plan based on the first goal in their Goals variable.
        /// </summary>
        public void Think()
        {
            if (this.CurrentPlan.Actions.Count == 0)
            {
                this.CurrentPlan.Actions.Add(this.Goals.First());
            }
            int count = this.AvailableActions.Count * 2;
            bool ableToCarryOutPlan = false;
            while (!ableToCarryOutPlan && count > 0)
            {
                count -= 1;
                List<Asset> requiredAssets = this.FindRequiredAssets(this.CurrentPlan.Actions.Last());
                List<Trait> requiredTraits = this.FindRequiredTraits(this.CurrentPlan.Actions.Last());
                if (requiredAssets.Count == 0 && requiredTraits.Count == 0)
                {
                    ableToCarryOutPlan = true;
                }
                else
                {
                    foreach (Asset asset in requiredAssets)
                    {
                        foreach (Action action in this.AvailableActions)
                        {
                            if (action.OutputAssets.Any(x => (x.GetType() == asset.GetType())))
                            {
                                CurrentPlan.Actions.Add(action);
                            }
                        }
                    }
                    foreach (Trait trait in requiredTraits)
                    {
                        foreach (Action action in this.AvailableActions)
                        {
                            if (action.OutputTraits.Any(x => (x.GetType() == trait.GetType())))
                            {
                                CurrentPlan.Actions.Add(action);
                            }
                        }
                    }
                    this.CurrentPlan.Actions = this.CurrentPlan.Actions.Distinct().ToList();
                }
            }
        }

        /// <summary>
        /// A private method to find all assets required by an action that are not already present in the Actor's available assets.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public List<Asset> FindRequiredAssets(Action action)
        {
            List<Asset> requiredAssets = new();
            foreach (Asset asset in action.InputAssets)
            {
                if (!this.AvailableAssets.Contains(asset))
                {
                    requiredAssets.Add(asset);
                }
            }
            return requiredAssets;
        }

        /// <summary>
        /// A private method to find all traits required by an action that are not already present in the Actor's traits.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public List<Trait> FindRequiredTraits(Action action)
        {
            List<Trait> requiredTraits = new();
            foreach (Trait trait in action.InputTraits)
            {
                if (!this.Traits.Contains(trait))
                {
                    requiredTraits.Add(trait);
                }
            }
            return requiredTraits;
        }
    }
}
