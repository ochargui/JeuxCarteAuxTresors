using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carte_Aux_Tresors
{
   class Map
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<Mountain> Mountains { get; } = new List<Mountain>();
    public List<Treasure> Treasures { get; } = new List<Treasure>();
    public List<Adventurer> Adventurers { get; } = new List<Adventurer>();

    public void SetDimensions(int width, int height)
    {
        Width = width;
        Height = height;
    }


    public void AddMountain(int x, int y)
    {
        Mountains.Add(new Mountain(x, y));
    }

    public void AddTreasure(int x, int y, int count)
    {
        Treasures.Add(new Treasure(x, y, count));
    }

    public void AddAdventurer(string name, int x, int y, string orientation, string actions)
    {
        Adventurers.Add(new Adventurer(name, x, y, orientation, actions));
    }

    public bool IsMountain(int x, int y)
    {
        return Mountains.Any(mountain => mountain.X == x && mountain.Y == y);
    }

    public bool HasTreasure(int x, int y)
    {
        return Treasures.Any(treasure => treasure.X == x && treasure.Y == y && treasure.Count > 0);
    }

    public int CollectTreasure(int x, int y)
    {
        var treasure = Treasures.First(t => t.X == x && t.Y == y);
        treasure.Count--;
        return 1;
    }
}
    }
