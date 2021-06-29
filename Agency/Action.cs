using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency
{
    abstract class Action
    {
        public List<Asset> Inputs { get; set; }
        public List<Asset> Outputs { get; set; }

        public virtual void Execute(List<Asset> assets)
        {
            foreach(Asset asset in this.Inputs)
            {
                assets.Remove(asset);
            }
            foreach(Asset asset in this.Outputs)
            {
                assets.Add(asset);
            }
        }

    }
}
