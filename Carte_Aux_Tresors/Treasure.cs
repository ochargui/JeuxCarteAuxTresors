using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Carte_Aux_Tresors
{
    class Treasure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Count { get; set; }

        public Treasure(int x, int y, int count)
        {
            X = x;
            Y = y;
            Count = count;
        }
    }
}
