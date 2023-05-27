using CargoMissions.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoMissions.Carriers
{
    //accept visitor
    public interface ICarrier
    {
        string Name { get; }
        Planet Location { get; }


        //visitor methods
        public abstract void VisitContested(ContestedMission mission);
        public abstract void VisitExpress(ExpressMission mission);

        public abstract void VisitSmuggling(SmugglingMission mission);
    }
}
