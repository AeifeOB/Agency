using System.Collections.Generic;

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
