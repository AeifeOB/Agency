using System.Collections.Generic;

namespace Agency
{
    class Plan
    {
        public List<Action> Actions { get; set; }

        public Plan()
        {
            this.Actions = new List<Action>();
        }

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
