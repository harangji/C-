using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Simulation.Resource
{
    class Patch
    {
        Patch(Champion c) //챔피언리스트에서 뽑은 챔피언. 클릭으로...
        {
            c.Atk -= 10;
        }
    }


}
