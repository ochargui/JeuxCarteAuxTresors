using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carte_Aux_Tresors
{
   public class Adventurer
    {
        public string Name { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Orientation { get; set; }
        public string Actions { get; }
        public int TreasureCount { get; private set; }

        public Adventurer(string name, int x, int y, string orientation, string actions)
        {
            Name = name;
            X = x;
            Y = y;
            Orientation = orientation;
            Actions = actions;
            TreasureCount = 0;
        }

        public void CollectTreasure(int count)
        {
            TreasureCount += count;
        }

        public void TurnLeft()
        {
            Orientation = Orientation switch
            {
                "N" => "W",
                "W" => "S",
                "S" => "E",
                "E" => "N",
                _ => throw new InvalidOperationException("Invalid orientation"),
            };
        }

        public void TurnRight()
        {
            Orientation = Orientation switch
            {
                "N" => "E",
                "E" => "S",
                "S" => "W",
                "W" => "N",
                _ => throw new InvalidOperationException("Invalid orientation"),
            };
        }
    }
}
