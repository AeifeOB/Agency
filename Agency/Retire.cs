using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency
{
    class Retire : Action
    { 
        public Retire()
        {
            Inputs = new List<Asset>();
            Outputs = new List<Asset>();
        }

        public override void execute(List<Asset> assets)
        {
            Console.WriteLine("You've retired...");
        }
    }
}
