using CargoMissions.Carriers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoMissions.Missions
{
    public class SmugglingMission : IMission
    {
        public string Name { get; }

        public Planet Starting { get; }

        public Planet Destination { get; }

        public double Reward { get; }

        public bool IsCompleted { get; set; } = false;

        public double Risk { get; }

        public SmugglingMission(string name, Planet starting, Planet destination,
            double reward, double risk)
        {
            Name = name;
            Starting = starting;
            Destination = destination;
            Reward = reward;
            Risk = risk;
        }
        
        public override string ToString()
        {
            return $"(Smuggling Mission {Name}, Start: {Starting}, " +
                   $"Destination: {Destination}, Reward: {Reward}, Risk: {Risk})";
        }

        public void Accept(ICarrier carrier)
        {
            carrier.VisitSmuggling(this);
        }
    }
}
