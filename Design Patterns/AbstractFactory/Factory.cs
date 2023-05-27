using System;
using System.Collections.Generic;
using System.Text;

namespace Construction
{
    public interface IFactory
    {
        Material createMaterial(double amount);
        Transporter createTransporter();
        Equipment createEquipment();

    }
    public class Budimex : IFactory
    {
        public Equipment createEquipment()
        {
            return new BudimexEquipment();
        }
        public Material createMaterial(double amount)
        {
            return new BudimexMaterial(amount);
        }

        public Transporter createTransporter()
        {
            return new BudimexTransporter();
        }
    }

    public class Strabag : IFactory
    {
        public Equipment createEquipment()
        {
            return new StrabagEquipment();
        }

        public Material createMaterial(double amount)
        {
            return new StrabagMaterial(amount);
        }

        public Transporter createTransporter()
        {
            return new StrabagTransporter();
        }
    }

    public class Torpol : IFactory
    {
        public Equipment createEquipment()
        {
            return new TorpolEquipment();
        }

        public Material createMaterial(double amount)
        {
            return new TorpolMaterial(amount);
        }

        public Transporter createTransporter()
        {
            return new TorpolTransporter();
        }
    }
}
