using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency
{
    class HireTeam : Action
    {
        public HireTeam()
        {
            Inputs = new List<Asset>();
            Outputs = new List<Asset>();
        }
    }
}
