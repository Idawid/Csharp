using System;
using System.Collections.Generic;

namespace Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            var amounts = new List<int>(){10, 15, 20};

            Console.WriteLine("Budimex");
            SupplyChain(amounts, new Budimex());

            Console.WriteLine("Strabag");
            SupplyChain(amounts, new Strabag());

            Console.WriteLine("Torpol");
            SupplyChain(amounts, new Torpol());
            
            Console.WriteLine("Mixed");
            Build(new Strabag().createMaterial(15), new Torpol().createTransporter(), new Budimex().createEquipment());
        }

        private static void SupplyChain(List<int> amounts, IFactory factory)
        {
            foreach (var amount in amounts)
            {
                Build(factory.createMaterial(amount), factory.createTransporter(), factory.createEquipment());
            }
        }

        private static void Build(Material material, Transporter transporter, Equipment equipement)
        {
            Console.WriteLine($"{material.Amount} tons of {material.GetMaterialType()}");
            Console.WriteLine($"Will be transported by {transporter.GetName()} on {transporter.Wheels} wheels");
            Console.WriteLine($"Load percentage: {transporter.LoadPercentage(material)}");
            Console.WriteLine($"{equipement.GetName()} {(equipement.CanApply(material)?"can":"CANNOT")} apply the material\n");
        }
    }
}
