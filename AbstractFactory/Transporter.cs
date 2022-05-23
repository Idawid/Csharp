using System;
using System.Collections.Generic;
using System.Text;

namespace Construction
{
    public abstract class Transporter
    {
        protected double wheelLoad = 2;

        public abstract int Wheels { get; }

        public abstract int LoadPercentage(Material material);

        public abstract string GetName();
    }

    public class BudimexTransporter : Transporter
    {
        public override int Wheels => 4;

        public override string GetName()
        {
            return "Max the Mixer";
        }

        public override int LoadPercentage(Material material)
        {
            return (int)(material.Amount / (Wheels * wheelLoad));
        }
    }
    public class StrabagTransporter : Transporter
    {
        public override int Wheels => 12;

        public override string GetName()
        {
            return "Clara the Cistern";
        }

        public override int LoadPercentage(Material material)
        {
            return (int)(material.Amount / ((Wheels - 2) * wheelLoad));
        }
    }
    public class TorpolTransporter : Transporter
    {
        public override int Wheels => 8;

        public override string GetName()
        {
            return "Thomas the Truck";
        }

        public override int LoadPercentage(Material material)
        {
            return (int)((material.Amount + 3) / (Wheels * wheelLoad));
        }
    }
}
