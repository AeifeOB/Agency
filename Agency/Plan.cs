using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency
{
    class Plan
    {
        public List<Action> actions { get; set; }

        public Plan()
        {
            this.actions = new List<Action>();
        }

        public void Execute(List<Asset> assets)
        {
            this.actions.Reverse();
            foreach (Action action in this.actions)
            {
                action.execute(assets);
            }
        }
    }
}
