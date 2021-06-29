using System.Collections.Generic;

namespace Agency
{
    class RobBank : Action
    {
        public RobBank()
        {
            Inputs = new List<Asset>();
            Outputs = new List<Asset>();
        }
    }
}
