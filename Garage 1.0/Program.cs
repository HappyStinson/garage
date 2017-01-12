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
            garage.Add(new Motorcycle("VR 46", "Valencia Yellow", 1000));
            garage.Add(new Car("CAR 345", "Blue", FuelType.Diesel));
            garage.Add(new Car("TESLA 345", "Silver", FuelType.Electric));
            garage.Add(new Boat("MARY 35", "Silver", 35f, isSailingBoat: true));
            garage.Add(new Boat("LISA 125", "Brown", 12.5f));

            var cityBus = new Bus("CITY LINE 10", "Leaf Green", 45);
            var schoolBus = new Bus("WEST ELEMENTARY", "Yellow", 25, isSchoolBus: true);
            garage.Add(cityBus);
            garage.Add(schoolBus);

            //garage.ListAllVehicles();

            //cityBus.RegisterAsSchoolBus();
            //schoolBus.RegisterAsCityBus();

            ////garage.ListAllVehicles();

            //garage.ListVehicleTypes();

            //var v1 = garage.SearchVehicle("CAR 345");
            
            //if (v1 != null)
            //    Console.WriteLine(v1);
            //else
            //    Console.WriteLine("No match");

            //var v2 = garage.SearchVehicle("LISA 345");
            //if (v2 != null)
            //    Console.WriteLine(v2);
            //else
            //    Console.WriteLine("No match");

            // Next test
            var matches = garage.SearchVehicle("YeLloW", 2);
            if (matches.Count() > 1)
                foreach (var item in matches)
                {
                    Console.WriteLine(item);
                }
            else
                Console.WriteLine("No match");
        }
    }
}
