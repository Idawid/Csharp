using CargoMissions.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoMissions.Carriers
{
    public class Flotilla : ICarrier
    {
        public string Name { get; }

        public Planet Location { get; private set; }

        public double Strength { get; }

        public Flotilla(string name, Planet location, double strength)
        {
            Name = name;
            Location = location;
            Strength = strength;
        }

        public void VisitContested(ContestedMission mission)
        {
            if(Strength > 1.5 * (double)mission.EnemyStrength && mission.Starting == mission.Destination)
            {
                Location = mission.Destination;
                mission.IsCompleted = true;
            }
        }

        public void VisitExpress(ExpressMission mission)
        {
            mission.IsCompleted = false;
        }

        public void VisitSmuggling(SmugglingMission mission)
        {
            mission.IsCompleted = false;
        }
    }
}
