using System;
using System.Collections.Generic;
using System.Linq;

namespace Agency
{
    class Actor
    {
        public List<Action> AvailableActions { get; set; }
        public List<Asset> AvailableAssets { get; set; }
        public List<Action> Goals { get; set; }
        public Plan CurrentPlan { get; set; }

        public Actor()
        {
            AvailableActions = new List<Action>();
            AvailableAssets = new List<Asset>();
            Goals = new List<Action>();
            CurrentPlan = new Plan();
        }

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
                if (requiredAssets.Count == 0)
                {
                    ableToCarryOutPlan = true;
                }
                else
                {
                    foreach (Asset asset in requiredAssets)
                    {
                        Console.WriteLine("Trying to find {0}", asset.GetType());
                        foreach (Action action in this.AvailableActions)
                        {
                            if (action.Outputs.Any(x => (x.GetType() == asset.GetType())))
                            {
                                CurrentPlan.Actions.Add(action);
                            }
                        }
                    }
                    this.CurrentPlan.Actions = this.CurrentPlan.Actions.Distinct().ToList();
                }
            }
        }

        private List<Asset> FindRequiredAssets(Action action)
        {
            List<Asset> requiredAssets = new();
            foreach (Asset asset in action.Inputs)
            {
                if (!this.AvailableAssets.Contains(asset))
                {
                    requiredAssets.Add(asset);
                }
            }
            return requiredAssets;
        }
    }
}
