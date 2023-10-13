using Carte_Aux_Tresors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "C:\\Users\\Oumaima\\source\\repos\\Carte_Aux_Tresors\\Carte_Aux_Tresors\\bin\\Debug\\net6.0\\input.txt";
        string outputFile = "C:\\Users\\Oumaima\\source\\repos\\Carte_Aux_Tresors\\Carte_Aux_Tresors\\bin\\Debug\\net6.0\\output.txt";
        
      
  
        Map map = ReadInput(inputFile);

        string inputContent = File.ReadAllText(inputFile);
        Console.WriteLine("Contenu du fichier d'entrer:");
        Console.WriteLine(inputContent);

        SimulateAdventurers(map);

        WriteOutput(outputFile, map);
        string outputContent = File.ReadAllText(outputFile);
        Console.WriteLine("Contenu du fichier de sortie :");
        Console.WriteLine(outputContent);


    }

    static Map ReadInput(string inputFile)
    {
        var map = new Map();
        string[] lines = File.ReadAllLines(inputFile);

        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');

            if (parts.Length == 0)
                continue;

            string code = parts[0];
            int parsedValue;

            if (code == "C" && int.TryParse(code, out parsedValue))
            {
                 map.SetDimensions(int.Parse(parts[2]), int.Parse(parts[3]));
          
            }
            else if (code == "M" && int.TryParse(code, out parsedValue))
            {
                map.AddMountain(int.Parse(parts[2]), int.Parse(parts[3]));
            }
            else if (code == "T" && int.TryParse(code, out parsedValue))
            {
                map.AddTreasure(int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]));
            }
            else if (code == "A" && int.TryParse(code, out parsedValue))
            {
                map.AddAdventurer(parts[1], int.Parse(parts[2]), int.Parse(parts[3]), parts[4], parts[5]);
            }
        }

        return map;
    }

    static void SimulateAdventurers(Map map)
    {
        foreach (var adventurer in map.Adventurers)
        {
            foreach (char action in adventurer.Actions)
            {
                if (action == 'A')
                {
                    int newX = adventurer.X;
                    int newY = adventurer.Y;
                    if (adventurer.Orientation == "N") newY--;
                    else if (adventurer.Orientation == "S") newY++;
                    else if (adventurer.Orientation == "E") newX++;
                    else if (adventurer.Orientation == "W") newX--;

                    if (!map.IsMountain(newX, newY))
                    {
                        adventurer.X = newX;
                        adventurer.Y = newY;
                        if (map.HasTreasure(newX, newY))
                        {
                            int treasureCount = map.CollectTreasure(newX, newY);
                            adventurer.CollectTreasure(treasureCount);
                        }
                    }
                }
                else if (action == 'G')
                {
                    adventurer.TurnLeft();
                }
                else if (action == 'D')
                {
                    adventurer.TurnRight();
                }
            }
        }
    }

    static void WriteOutput(string outputFile, Map map)
    {
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            
               writer.WriteLine($"C - {map.Width} - {map.Height}");

            foreach (var Mountain in map.Mountains)
            {
                writer.WriteLine($"M - {Mountain.X} - {Mountain.Y}");
            }

            foreach (var Treasure in map.Treasures)
            {
                writer.WriteLine($"T - {Treasure.X} - {Treasure.Y} - {Treasure.Count}");
            }

            foreach (var Adventurer in map.Adventurers)
            {
                writer.WriteLine($"A - {Adventurer.Name} - {Adventurer.X} - {Adventurer.Y} - {Adventurer.Orientation[0]} - {Adventurer.TreasureCount}");
            }
        }
       
    }
   
}



