using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter garage capacity: ");
            var capacity = 10;
            var garage = new Garage<Vehicle>(capacity);
            garage.Add(new Airplane("ABC 123", "Black", 16, 4));
            garage.Add(new Airplane("DEVIL 666", "Red", 666, 666));
            garage.Add(new Motorcycle("VR 46", "Valencia yellow", 1000));

            garage.ListAllVehicles();

        }
    }
}
