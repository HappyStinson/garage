using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private Vehicle[] vehicles;

        public int Capacity { get; }
        public int Count { get; private set; }

        public Garage(int capacity)
        {
            Capacity = capacity;
            vehicles = new T[capacity];
        }

        public bool Add(T vehicle)
        {
            if (Count >= Capacity) return false;

            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    Count++;
                    return true;
                }
            }

            return false;
        }

        public T Remove(T vehicle)
        {
            if (vehicle == null) return null;

            for (int i = 0; i < Capacity; i++)
            {
                if (vehicle.Equals(vehicles[i]))
                {
                    vehicles[i] = null;
                    Count--;
                    return vehicle;
                }
            }
            return null;
        }

        public void ListAllVehicles() // change return type to string? ListParkedVehicles?
        {
            Console.WriteLine("Listing all vehicles");
            foreach (var vehicle in vehicles.Where(v => v != null))
            {
                Console.WriteLine(vehicle);
                Console.WriteLine();
            }
        }

        public void ListVehicleTypes()
        {
            var types = vehicles
                .Where(v => v != null)
                .GroupBy(v => v.GetType().Name)
                .Select(v => new {
                    Count = v.Count(),
                    Vehicle = v.Key
                })
                .OrderByDescending(x => x.Count);

            Console.WriteLine($"{Count} vehicles is stored in the Garage{System.Environment.NewLine}");
            foreach (var type in types)
            {
                string s = "";
                if (type.Count > 1)
                {
                    if (type.Vehicle == "Bus") s = "es";
                    else s = "s";
                }
                Console.WriteLine($"{type.Count} {type.Vehicle}{s}");
            }
        }

        // Möjlighet att söka efter ett specifikt fordon via Reg-nr

        // Möjlighet att söka efter ett flertal fordon på ett flertal valfria variabler.

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicles.Where(v => v != null))
            {
                //if (vehicle is Airplane)
                //    yield return vehicle as Airplane;

                yield return (T)vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
