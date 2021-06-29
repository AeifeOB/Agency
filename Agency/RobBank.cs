using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
