using System;

namespace Pirates
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;
    class Pirates
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> townsPoppulation = new Dictionary<string, int>();
            Dictionary<string, int> townsGold = new Dictionary<string, int>();
            
            string commandSail = string.Empty;
            while ((commandSail = Console.ReadLine()) != "Sail")
            {
                string[] inputParameters = commandSail.Split("||");
                string town = inputParameters[0];
                int poppulation = int.Parse(inputParameters[1]);
                int goldInKg = int.Parse(inputParameters[2]);

                if (!townsPoppulation.ContainsKey(town))
                {
                    townsPoppulation.Add(town, poppulation);
                    townsGold.Add(town, goldInKg);
                }
                else
                {
                    townsPoppulation[town] += poppulation;
                    townsGold[town] += goldInKg;
                }

            }

            string commandEnd = string.Empty;
            while ((commandEnd = Console.ReadLine()) != "End")
            {
                string[] inputParameters = commandEnd.Split("=>");
                string commandType = inputParameters[0];
                string town = inputParameters[1];

                if (commandType == "Plunder")
                {
                    int poppulation = int.Parse(inputParameters[2]);
                    int goldInKg = int.Parse(inputParameters[3]);
                    townsPoppulation[town] -= poppulation;
                    townsGold[town] -= goldInKg;
                    Console.WriteLine($"{town} plundered! {goldInKg} gold stolen, {poppulation} citizens killed.");

                    if(townsPoppulation[town] <= 0 || townsGold[town] <= 0)
                    {

                        townsPoppulation.Remove(town);
                        townsGold.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                    
                }
                else if(commandType == "Prosper")
                {
                    int goldInKg = int.Parse(inputParameters[2]);

                    if (goldInKg < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    townsGold[town] += goldInKg;
                    Console.WriteLine($"{goldInKg} gold added to the city treasury. {town} now has {townsGold[town]} gold.");
                }
            }

            if (townsGold.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {townsGold.Count} wealthy settlements to go to:");

                foreach (var (town, gold) in townsGold)
                {
                    Console.WriteLine($"{town} -> Population: {townsPoppulation[town]} citizens, Gold: {gold} kg");
                }
            }
        }
    }
}
