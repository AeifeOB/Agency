using System;
using System.Collections.Generic;

namespace Agency
{
    class Retire : Action
    {
        public Retire()
        {
            Inputs = new List<Asset>();
            Outputs = new List<Asset>();
        }

        public override void Execute(List<Asset> assets)
        {
            Console.WriteLine("You've retired...");
        }
    }
}
