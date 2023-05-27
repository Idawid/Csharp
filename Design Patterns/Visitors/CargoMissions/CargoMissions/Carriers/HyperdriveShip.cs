using CargoMissions.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoMissions.Carriers
{
    public class HyperdriveShip : ICarrier
    {
        public string Name { get; }

        public Planet Location { get; private set; }

        public double HyperdriveSpeed { get; }

        public HyperdriveShip(string name, Planet location, double hyperdriveSpeed)
        {
            Name = name;
            Location = location;
            HyperdriveSpeed = hyperdriveSpeed;
        }

        public void VisitContested(ContestedMission mission)
        {
            mission.IsCompleted = false;
        }

        public void VisitExpress(ExpressMission mission)
        {
            if (PlanetExtensions.DistanceTo(mission.Starting, mission.Destination) / HyperdriveSpeed < mission.MaximumTime)
            {
                Location = mission.Destination;
                mission.IsCompleted = true;
            }
        }

        public void VisitSmuggling(SmugglingMission mission)
        {
            if (mission.Risk < HyperdriveSpeed)
            {
                Location = mission.Destination;
                mission.IsCompleted = true;
            }
        }
    }
}
