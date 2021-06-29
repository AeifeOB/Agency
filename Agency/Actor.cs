using System;
using System.Collections.Generic;
using System.Linq;

namespace Agency
{
    class Actor
    {
        public List<Action> availableActions { get; set; }
        public List<Asset> availableAssets { get; set; }
        public List<Action> goals { get; set; }
        public Plan currentPlan { get; set; }

        public Actor()
        {
            availableActions = new List<Action>();
            availableAssets = new List<Asset>();
            goals = new List<Action>();
            currentPlan = new Plan();
        }

        public void Think()
        {
            if(this.currentPlan.actions.Count == 0)
            {
                this.currentPlan.actions.Add(this.goals.First());
            }
            int count = this.availableActions.Count * 2;
            bool ableToCarryOutPlan = false;
            while (!ableToCarryOutPlan && count > 0){
                count -= 1;
                List<Asset> requiredAssets = this.findRequiredAssets(this.currentPlan.actions.Last());
                if (requiredAssets.Count == 0)
                {
                    ableToCarryOutPlan = true;
                }
                else
                {
                    foreach (Asset asset in requiredAssets)
                    {
                        Console.WriteLine("Trying to find {0}", asset.GetType());
                        foreach (Action action in this.availableActions)
                        {
                            if (action.Outputs.Any(x => (x.GetType() == asset.GetType())))
                            {
                                currentPlan.actions.Add(action);
                            }
                        }
                    }
                    this.currentPlan.actions = this.currentPlan.actions.Distinct().ToList();
                }
            }
        }

        private List<Asset> findRequiredAssets(Action action)
        {
            List<Asset> requiredAssets = new List<Asset>();
            foreach (Asset asset in action.Inputs)
            {
                if (!this.availableAssets.Contains(asset)){
                    requiredAssets.Add(asset);
                }
            }
            return requiredAssets;
        }
    }
}
