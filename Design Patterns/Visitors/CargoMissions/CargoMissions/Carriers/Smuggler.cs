using CargoMissions.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoMissions.Carriers
{
    public class Smuggler : ICarrier
    {
        public string Name { get; }

        public Planet Location { get; private set; }

        public double Expertise { get; }

        public double MinimalFee { get; }

        public Smuggler(string name, Planet location,
            double expertise, double minimalFee)
        {
            Name = name;
            Location = location;
            Expertise = expertise;
            MinimalFee = minimalFee;
        }

        public void VisitContested(ContestedMission mission)
        {
            mission.IsCompleted = false;
        }

        public void VisitExpress(ExpressMission mission)
        {
            if(mission.Reward > MinimalFee * 0.5 && mission.Starting == Location &&
                PlanetExtensions.DistanceTo(mission.Starting, mission.Destination) < mission.MaximumTime)
            {
                Location = mission.Destination;
                mission.IsCompleted = true;
            }
        }

        public void VisitSmuggling(SmugglingMission mission)
        {
            if(Expertise > mission.Risk && mission.Reward > MinimalFee)
            {
                Location = mission.Destination;
                mission.IsCompleted = true;
            }
        }
    }
}
