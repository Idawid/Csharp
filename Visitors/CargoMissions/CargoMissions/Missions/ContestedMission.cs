using CargoMissions.Carriers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoMissions.Missions
{
    public class ContestedMission : IMission
    {
        public string Name { get; }

        public Planet Starting { get; }

        public Planet Destination { get; }

        public double Reward { get; }

        public bool IsCompleted { get; set; } = false;

        public double EnemyStrength { get; }

        public ContestedMission(string name, Planet starting, Planet destination,
            double reward, double enemyStrength)
        {
            Name = name;
            Starting = starting;
            Destination = destination;
            Reward = reward;
            EnemyStrength = enemyStrength;
        }
        
        public override string ToString()
        {
            return $"(Contested Mission {Name}, Start: {Starting}, " +
                   $"Destination: {Destination}, Reward: {Reward}, Enemy strength: {EnemyStrength})";
        }

        public void Accept(ICarrier carrier)
        {
            carrier.VisitContested(this);
        }
    }
}
