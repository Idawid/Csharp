using Construction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Construction
{
    public abstract class Equipment
    {
        public abstract string GetName();

        public abstract bool CanApply(Material material);
    }

    public class BudimexEquipment : Equipment
    {
        public override bool CanApply(Material material)
        {
            if(material.GetMaterialType() == MaterialType.Concrete || material.GetMaterialType() == MaterialType.Asphalt)
            {
                return true;
            }
            return false;
        }

        public override string GetName()
        {
            return "Pump";
        }
    }
    public class StrabagEquipment : Equipment
    {
        public override bool CanApply(Material material)
        {
            if (material.GetMaterialType() == MaterialType.Asphalt)
            {
                return true;
            }
            return false;
        }

        public override string GetName()
        {
            return "RoadRoller";
        }
    }
    public class TorpolEquipment : Equipment
    {
        public override bool CanApply(Material material)
        {
            if (material.GetMaterialType() == MaterialType.Sand)
            {
                return true;
            }
            return false;
        }

        public override string GetName()
        {
            return "Excavator";
        }
    }
}
