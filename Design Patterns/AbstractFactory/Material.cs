using Construction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Construction
{
    public enum MaterialType{
        Sand,
        Concrete,
        Asphalt
    }
    public abstract class Material
    {
        protected double amount;
        public double Amount
        {
            get { return amount; }
        }
        
        public Material(double amount)
        {
            this.amount = amount;
        }

        public abstract MaterialType GetMaterialType();
    }

    public class BudimexMaterial : Material
    {
        public BudimexMaterial(double amount) : base(amount)
        {
        }

        public override MaterialType GetMaterialType()
        {
            return MaterialType.Concrete;
        }

    }
    public class StrabagMaterial : Material
    {
        public StrabagMaterial(double amount) : base(amount)
        {
        }

        public override MaterialType GetMaterialType()
        {
            return MaterialType.Asphalt;
        }
    }
    public class TorpolMaterial : Material
    {
        public TorpolMaterial(double amount) : base(amount)
        {
        }

        public override MaterialType GetMaterialType()
        {
            return MaterialType.Sand;
        }
    }

}
