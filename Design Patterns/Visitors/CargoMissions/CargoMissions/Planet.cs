using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoMissions
{
    public enum Planet
    {
        Earth,
        Mars,
        Tatooin,
        Hoth,
        SagittariusC,
        Dune
    }

    public static class PlanetExtensions
    {
        private static readonly double[,] distances = { 
            {0,     0.72, 23.32, 44.12, 302, 1703},
            {0.72,  0,    23.32, 44.12, 302, 1703},
            {23.32, 0.72, 0,     44.12, 302, 1703},
            {44.12, 0.72, 23.32, 0,     302, 1703},
            {302,   0.72, 23.32, 44.12, 0,   1703},
            {1703,  0.72, 23.32, 44.12, 302, 0},
        };

        public static double DistanceTo(this Planet planet, Planet destination)
        {
            return distances[(int)planet, (int)destination];
        }
    }
}
