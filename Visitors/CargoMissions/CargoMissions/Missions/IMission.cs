using CargoMissions.Carriers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoMissions.Missions
{

    //IVisitor
    public interface IMission
    {
        string Name { get; }
        Planet Starting { get; }
        Planet Destination { get; }
        double Reward { get; }
        bool IsCompleted { get; set; }


        //accept visitor methods
        void Accept(ICarrier carrier);

    }
}
