using System;
using System.Collections.Generic;
using CargoMissions.Carriers;
using CargoMissions.Missions;

namespace CargoMissions
{
    class Program
    {
        static void Main()
        {
            var missions = new List<IMission>()
            {
                new ExpressMission("Water delivery", Planet.Earth, Planet.Tatooin, 506, 25),
                new ExpressMission("Medical supplies", Planet.SagittariusC, Planet.Hoth, 230, 13),
                new ContestedMission("Rescue mission", Planet.Mars, Planet.Dune, 420, 100.52),
                new ContestedMission("Space blockade", Planet.Dune, Planet.Mars, 2420, 201.47),
                new SmugglingMission("Art smuggling", Planet.Hoth, Planet.Earth, 1032, 7.4),
                new SmugglingMission("Illegal race", Planet.Tatooin, Planet.Dune, 7421, 9.9),
                new SmugglingMission("Smalled illegal race", Planet.Dune, Planet.Mars, 601, 5.2)
            };

            var carriers = new List<ICarrier>()
            {
                new Smuggler("Thalmor", Planet.Earth, 8.2, 802),
                new HyperdriveShip("Fastest and Furious", Planet.Earth, 6),
                new Flotilla("IO", Planet.Mars, 155.23),
            };

            foreach (var mission in missions)
            {
                Console.WriteLine($"Attempting to carry out mission: {mission}");
                foreach (var carrier in carriers)
                {
                    if (CarryOutMission(carrier, mission))
                    {
                        Console.WriteLine($"Carrier {carrier.Name} finished mission");
                        break;
                    }
                }
                Console.WriteLine($"Mission: {mission}, mission finished: {mission.IsCompleted}");
            }
        }

        static bool CarryOutMission(ICarrier carrier, IMission mission)
        {
            mission.Accept(carrier);
            return mission.IsCompleted;
        }
    }
}