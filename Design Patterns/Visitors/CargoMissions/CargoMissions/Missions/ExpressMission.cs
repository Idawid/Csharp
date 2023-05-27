using CargoMissions.Carriers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoMissions.Missions
{
    public class ExpressMission : IMission
    {
        public string Name { get; }

        public Planet Starting { get; }

        public Planet Destination { get; }

        public double Reward { get; }

        public bool IsCompleted { get; set; } = false;

        public double MaximumTime { get; }

        public ExpressMission(string name, Planet starting, Planet destination,
            double reward, double maximumTime)
        {
            Name = name;
            Starting = starting;
            Destination = destination;
            Reward = reward;
            MaximumTime = maximumTime;
        }
        
        public override string ToString()
        {
            return $"(Express Mission {Name}, Start: {Starting}, " +
                   $"Destination: {Destination}, Reward: {Reward}, Maximum time: {MaximumTime})";
        }

        public void Accept(ICarrier carrier)
        {
            carrier.VisitExpress(this);
        }
    }
}
