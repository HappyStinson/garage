﻿using System;
using System.Linq;

namespace Garage
{
    public struct VehicleProperties
    {
        public string RegistrationPlate;
        public string Color;
        public int WheelCount;

        public VehicleProperties(string registrationPlate, string color)
        {
            RegistrationPlate = registrationPlate;
            Color = color;
            WheelCount = 0;
        }

        public VehicleProperties(string registrationPlate, string color,
                                 int wheelCount)
        {
            RegistrationPlate = registrationPlate;
            Color = color;
            WheelCount = wheelCount;
        }
    }

    class Program
    {
        private static Garage<Vehicle> garage = new Garage<Vehicle>(10);
        private static string log { get; set; }

        static void Main(string[] args)
        {
            garage.Add(new Airplane("DEVIL 666", "REd", 666, 666));
            garage.Add(new Motorcycle("VR 46", "Valencia YeLloW", 1000));
            garage.Add(new Car("CAR 345", "blUE", Car.FuelType.Diesel));
            garage.Add(new Car("TESLA 345", "SilVeR", Car.FuelType.Electric));
            garage.Add(new Car("ford focus rs", "orange", Car.FuelType.Gasoline));
            garage.Add(new Boat("MARY 35", "Silver", 35.0f));
            garage.Add(new Boat("LISA 125", "brOwn", 12.5f));
            garage.Add(new Bus("CITY LINE 10", "Leaf GrEen", 45));
            garage.Add(new Bus("WEST ELEMENTARY", "Yellow", 25, isSchoolBus: true));

            var quit = false;
            do
            {
                quit = MainMenu();
            } while (quit != true);
        }

        private static bool MainMenu()
        {
            Console.Clear();
            PrintLog(wait: true);
            Console.WriteLine("--| GARAGE - MAIN MENU |--" + Environment.NewLine);
            Console.WriteLine(
                "1. Open a new Garage (this will replace the current Garage)"
                + "\n2. Park a vehicle in the garage"
                + "\n3. Unpark a parked vehicle"
                + "\n4. Search for vehicles parked in the garage"
                + "\n5. List the vehicles parked in the garage"
                + "\n0. Exit this garage\n");

            var input = AskForInt("Your choice: ");
            Console.Clear();

            var quit = false;
            switch (input)
            {
                case 1:
                    OpenGarage();
                    break;
                case 2:
                    ParkVehicleMenu();
                    break;
                case 3:
                    UnparkVehicle();
                    break;
                case 4:
                    SearchVehiclesMenu();
                    break;
                case 5:
                    ListVehiclesMenu();
                    break;
                case 0:
                    quit = true;
                    break;
                default:
                    Log("Not a valid choice");
                    break;
            }
            return quit;
        }

        private static void PrintLog(bool wait = false)
        {
            if (!string.IsNullOrWhiteSpace(log))
            {
                Console.WriteLine(log);
                log = "";

                if (wait)
                {
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void Log(string message)
        {
            log += message + Environment.NewLine;
        }

        private static void OpenGarage()
        {
            Console.WriteLine("--| OPEN NEW GARAGE |--" + Environment.NewLine);
            var capacity = AskForInt("Enter the number of parking slots: ", unsigned: true);
            garage = new Garage<Vehicle>(capacity);
        }

        private static void ParkVehicleMenu()
        {
            Console.WriteLine("--| PARK VEHICLE |--");
            PrintLog();
            LogGarageSlotInfo();

            if (!garage.IsFull())
            {
                PrintLog();

                Console.WriteLine(
                    "1. Park an Airplane"
                    + "\n2. Park a Motorcycle"
                    + "\n3. Park a Car"
                    + "\n4. Park a Bus"
                    + "\n5. Park a Boat"
                    + "\n0. Return to main menu\n");

                var input = AskForInt("Your choice: ");
                Console.Clear();

                switch (input)
                {
                    case 1:
                        ParkAirplane();
                        break;
                    case 2:
                        ParkMotorcycle();
                        break;
                    case 3:
                        ParkCar();
                        break;
                    case 4:
                        ParkBus();
                        break;
                    case 5:
                        ParkBoat();
                        break;
                    case 0:
                        break;
                    default:
                        Log("Not a valid choice");
                        break;
                }
            }
        }

        private static void LogGarageSlotInfo()
        {
            var availableSlots = garage.Capacity - garage.Count;
            Log($"{availableSlots}/{garage.Capacity} parking slots available");

            if (availableSlots == 0)
                Log("The garage is full. Come back later or unpark a vehicle");
        }

        private static void ParkAirplane()
        {
            Console.WriteLine("-- PARK AIRPLANE --" + Environment.NewLine);
            var properties = AskForVehicleProperties(mandatoryWheels: false);

            var engineCount = AskForInt("Enter the number of engines: ");
            if (engineCount < 0)
                engineCount = 0;

            var airplane = new Airplane(properties.RegistrationPlate,
                                        properties.Color,
                                        properties.WheelCount,
                                        engineCount);
            garage.Add(airplane);
        }

        private static VehicleProperties AskForVehicleProperties(bool mandatoryWheels = true)
        {
            var registrationPlate = AskForString("Enter registration plate: ");
            var color = AskForString("Enter color: ");
            var wheelCount = AskForInt("Enter the number of wheels: ", mandatoryWheels);

            var properties = new VehicleProperties(registrationPlate,
                                                   color, wheelCount);
            return properties;
        }

        private static void ParkMotorcycle()
        {
            Console.WriteLine("-- PARK MOTORCYCLE --" + Environment.NewLine);
            var properties = AskForVehicleProperties();
            var engineCC = AskForFloat("Enter the engine cylinder volume (cc): ");

            var motorcycle = new Motorcycle(properties.RegistrationPlate,
                                          properties.Color, engineCC);
            garage.Add(motorcycle);
        }

        private static VehicleProperties AskForVehicleProperties()
        {
            var registrationPlate = AskForString("Enter registration plate: ");
            var color = AskForString("Enter color: ");

            return new VehicleProperties(registrationPlate, color);
        }

        private static float AskForFloat(string message)
        {
            float value;
            bool parsed = false;
            string error = "";

            do
            {
                string input = AskForString(error + message);
                parsed = float.TryParse(input,
                                        System.Globalization.NumberStyles.Any,
                                        System.Globalization.CultureInfo.InvariantCulture,
                                        out value);

                if (value < 1)
                {
                    parsed = false;
                    error = "\nIncorrect input. You must enter a positive number.\n";
                }

            } while (!parsed);

            return value;
        }

        private static void ParkCar()
        {
            Console.WriteLine("-- PARK CAR --" + Environment.NewLine);
            var properties = AskForVehicleProperties();
            var fuelType = AskForFuelType();

            var car = new Car(properties.RegistrationPlate,
                                         properties.Color,
                                         fuelType);
            garage.Add(car);
        }

        private static Car.FuelType AskForFuelType()
        {
            var message = "Enter fuel type "
                + "(1 = Gasoline, 2 = Diesel, 3 = Electric, 4 = Ethanol): ";
            var fuelType = AskForInt(message);

            switch (fuelType)
            {
                case 1:
                    return Car.FuelType.Gasoline;
                case 2:
                    return Car.FuelType.Diesel;
                case 3:
                    return Car.FuelType.Electric;
                case 4:
                    return Car.FuelType.Ethanol;
                default:
                    return Car.FuelType.Hemp;
            }
        }

        private static void ParkBus()
        {
            Console.WriteLine("-- PARK BUS --" + Environment.NewLine);

            var properties = AskForVehicleProperties();
            var seats = AskForInt("Enter the number of seats: ", unsigned: true);

            var isSchoolBus = false;
            var answer = AskForInt("Enter category (1 = School bus, 2 = City bus): ");
            if (answer == 1)
                isSchoolBus = true;

            var bus = new Bus(properties.RegistrationPlate, properties.Color,
                              seats, isSchoolBus);
            garage.Add(bus);
        }

        private static void ParkBoat()
        {
            Console.WriteLine("-- PARK BOAT --" + Environment.NewLine);

            var properties = AskForVehicleProperties();
            var length = AskForFloat("Enter the length in feet: ");

            var boat = new Boat(properties.RegistrationPlate, properties.Color,
                                length);
            garage.Add(boat);
        }

        private static void UnparkVehicle()
        {
            Console.WriteLine("--| UNPARK VEHICLE |--" + Environment.NewLine);

            if (garage.Count > 0)
            {
                var result = garage.SearchMatchingVehicle(AskForString("Enter registration plate: "));

                if (result != null)
                {
                    if (garage.Remove(result) != null)
                        Log($"Successfully unparked vehicle{Environment.NewLine}{Environment.NewLine}{result}");
                }
                else
                    Log("No matching vehicle found in garage. Has it been stolen? ='(");
            }
            else
                Log("The garage is empty. Did you really park here? :O");
        }

        private static int AskForInt(string question, bool unsigned = false)
        {
            int value;
            bool parsed = false;
            string error = "";

            do
            {
                string input = AskForString(error + question);
                parsed = int.TryParse(input, out value);

                if (unsigned && value < 1)
                {
                    parsed = false;
                    error = "\nIncorrect input. You must enter a positive integer.\n";
                }
                else
                    error = "\nIncorrect input. You must enter an integer.\n";

            } while (!parsed);

            return value;
        }

        private static string AskForString(string question)
        {
            string input;
            bool parsed = false;
            string error = "";

            do
            {
                Console.Write(error + question);
                input = Console.ReadLine();
                parsed = !string.IsNullOrWhiteSpace(input);
                error = "\nIncorrect input. You must enter some text.\n";

            } while (!parsed);

            return input.Trim();
        }

        private static void ListVehiclesMenu()
        {
            Console.WriteLine("--| LIST VEHICLES |--" + Environment.NewLine);
            PrintLog();

            Console.WriteLine("1. List all vehicles parked in the garage"
                + "\n2. List all different vehicle types and their quantity"
                + "\n0. Return to main menu\n");

            var input = AskForInt("Your choice: ");
            Console.Clear();

            switch (input)
            {
                case 1:
                    ListAllParkedVechicles();
                    break;
                case 2:
                    ListAllParkedVechicles(groupByType: true);
                    break;
                case 0:
                    break;
                default:
                    Log("Not a valid choice");
                    break;
            }
        }

        private static void ListAllParkedVechicles(bool groupByType = false)
        {
            if (garage.Count > 0)
            {
                if (groupByType)
                    Log(garage.ListVehicleTypes());
                else
                    Log(garage.ListAllParkedVehicles());
            }
            else
                Log("The garage is empty");
        }

        private static void SearchVehiclesMenu()
        {
            Console.WriteLine("--| SEARCH VEHICLES |--" + Environment.NewLine);
            PrintLog();

            Console.WriteLine(
                "1. Search vehicle by registration number"
                + "\n2. Search vehicle by color and number of wheels"
                + "\n0. Return to main menu\n");

            var input = AskForInt("Your choice: ");
            Console.Clear();

            switch (input)
            {
                case 1:
                    SearchVehicleByRegistrationPlate();
                    break;
                case 2:
                    SearchVehicleByColorWheelCount();
                    break;
                case 0:
                    break;
                default:
                    Log($"\"{input}\" is not a valid choice");
                    break;
            }
        }

        private static void SearchVehicleByRegistrationPlate()
        {
            var registrationPlate = AskForString("Enter registration plate: ");
            var vehicle = garage.SearchMatchingVehicle(registrationPlate);

            if (vehicle != null)
            {
                Log("Matching vehicle");
                Log(vehicle.ToString());
            }
            else
            {
                var result = garage.SearchVehiclesContains(registrationPlate);
                

                if (result.Count() > 0)
                {
                    Log($"Vehicles that contain: \"{registrationPlate}\"");
                    foreach (var item in result)
                    {
                        Log(item.ToString());
                    }
                }
                else
                    Log("Found no match");
            }
        }

        private static void SearchVehicleByColorWheelCount()
        {
            var color = AskForString("Enter color: ");
            var wheelCount = AskForInt("Enter the number of wheels: ");
            Log($"{color} vehicle with at least {wheelCount} wheels in the garage: {Environment.NewLine}");

            var result = SearchVehicles(color, wheelCount);

            if (result.Count() > 0)
            {
                foreach (var item in result)
                    Log(item.ToString() + Environment.NewLine);
            }
            else
                Log("No match");
        }

        private static Vehicle[] SearchVehicles(string color, int wheelCount) => garage.SearchVehicle(color, wheelCount);
    }
}
