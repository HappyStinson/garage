using System;
using System.Linq;

namespace Garage
{
    public struct VehicleProperties
    {
        public string RegistrationPlate;
        public string Color;
        public int WheelCount;

        public VehicleProperties(string registrationPlate,
                          string color, int wheelCount)
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
            var quit = false;
            do
            {
                quit = MainMenu();
            } while (quit != true);




            //garage.Add(new Airplane("DEVIL 666", "REd", 666, 666));
            //garage.Add(new Motorcycle("VR 46", "Valencia YeLloW", 1000));
            //garage.Add(new Car("CAR 345", "blUE", FuelType.Diesel));
            //garage.Add(new Car("TESLA 345", "SilVeR", FuelType.Electric));
            //garage.Add(new Boat("MARY 35", "Silver", 35f, isSailingBoat: true));
            //garage.Add(new Boat("LISA 125", "brOwn", 12.5f));

            //var cityBus = new Bus("CITY LINE 10", "Leaf GrEen", 45);
            //var schoolBus = new Bus("WEST ELEMENTARY", "Yellow", 25, isSchoolBus: true);
            //garage.Add(cityBus);
            //garage.Add(schoolBus);

            //SearchVehicle(garage, "YeLloW", 0);
            //SearchVehicle(garage, "yellow", 2);
            //SearchVehicle(garage, "Yellow", 2);
            //SearchVehicle(garage, "YELLOW", 2);
            //SearchVehicle(garage, "Black", 2);
            //SearchVehicle(garage, "red", 2);
            //SearchVehicle(garage, "green", 2);
            //SearchVehicle(garage, "browN", 2);

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
        }

        private static bool MainMenu()
        {
            Console.Clear();

            // Debug prints
            Console.WriteLine($"Capacity: {garage.Capacity}");
            Console.WriteLine($"First Vehicle: {garage.FirstOrDefault()}");
            Console.WriteLine();
            // </Debug>

            Console.WriteLine("--| GARAGE 1.0 MAIN MENU |--" + Environment.NewLine);
            PrintLog();

            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 , 4, 0) of your choice"
                + "\n1. Open a new Garage (this will replace the current Garage)"
                + "\n2. Park a vehicle in the garage"
                + "\n3. Unpark a parked vehicle"
                + "\n4. Search for vehicles parked in the garage"
                + "\n5. List the vehicles parked in the garage"
                + "\n0. Quit the application\n");

            var input = AskForInt("Your choice: ");

            var quit = false;
            switch (input)
            {
                case 1:
                    Console.Clear();
                    OpenGarage();
                    break;
                case 2:
                    ParkVehicleMenu();
                    //ParkAirplane();
                    break;
                case 3:
                    UnparkVehicleMenu();
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
                    Log("Not a valid choice.");
                    break;
            }

            return quit;
        }

        private static void PrintLog()
        {
            Console.WriteLine(Environment.NewLine + log);
            log = "";
        }

        private static void Log(string message)
        {
            log += message + Environment.NewLine;
        }

        private static void OpenGarage()
        {
            Console.WriteLine("--| OPENING NEW GARAGE |--" + Environment.NewLine);
            var capacity = AskForInt("Enter the number of parking slots: ", unsigned: true);
            garage = new Garage<Vehicle>(capacity);
        }

        private static int ParkVehicleMenu()
        {
            Console.Clear();

            Console.WriteLine("--| PARK VECHICLE |--" + Environment.NewLine);
            PrintLog();

            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 , 4, 0) of your choice"
                + "\n1. Park an Airplane"
                + "\n2. Park a Motorcycle"
                + "\n3. Park a Car"
                + "\n4. Park a Bus"
                + "\n5. Park a Boat"
                + "\n9. Back to previous menu"
                + "\n0. Quit the application");

            var input = AskForInt("Your choice: ");

            var quit = 0;
            switch (input)
            {
                case 1:
                    Console.Clear();
                    ParkAirplane();
                    break;
                //case 2:
                //    ParkMotorcycle();
                //    break;
                //case 3:
                //    ParkCar();
                //    break;
                //case 4:
                //    ParkBus();
                //    break;
                //case 5:
                //    ParkBoat();
                //    break;
                //case 9:
                //    break;
                case 0:
                    quit = 1;
                    break;
                default:
                    Log("Park Vehicle - default");
                    break;
            }

            return quit;
        }

        private static void ParkAirplane()
        {
            Console.WriteLine("-- PARKING AIRPLANE --" + Environment.NewLine);
            var properties = AskForVehicleProperties(mandatoryWheels: false);
            var engineCount = AskForInt("Enter the number of engines: ");

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
            Console.Clear();
            Console.WriteLine("List vehicles sub menu");
            Console.ReadKey();
        }

        private static void SearchVehiclesMenu()
        {
            Console.Clear();
            Console.WriteLine("List vehicles sub menu");
            Console.ReadKey();
        }

        private static void UnparkVehicleMenu()
        {
            Console.Clear();
            Console.WriteLine("List vehicles sub menu");
            Console.ReadKey();
        }

        private static void SearchVehicle(Garage<Vehicle> garage, string color, int wheelCount)
        {
            Console.Clear();
            Console.WriteLine($"{color} vehicle with at least {wheelCount} wheels in the garage:");
            var matches = garage.SearchVehicle(color, wheelCount);
            if (matches.Count() > 0)
            {
                foreach (var item in matches)
                    Console.WriteLine(item + System.Environment.NewLine);
                Console.ReadKey();
            }
            else
                Console.WriteLine("No match");
        }
    }
}
