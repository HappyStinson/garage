using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static Garage<Vehicle> garage = new Garage<Vehicle>(10);

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

            //SearchVehicle(garage, "YeLloW", 2);
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

            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 , 4, 0) of your choice"
                + "\n1. Open a new Garage (this will replace the current Garage)"
                + "\n2. Park a vehicle in the garage"
                + "\n3. Unpark a parked vehicle"
                + "\n4. Search for vehicles parked in the garage"
                + "\n5. List the vehicles parked in the garage"
                + "\n0. Quit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!"); // Never enters here?
            }

            Console.Clear();
            var quit = false;
            switch (input)
            {
                case '1':
                    OpenGarage();
                    break;
                case '2':
                    ParkVehicleMenu();
                    break;
                case '3':
                    UnparkVehicleMenu();
                    break;
                case '4':
                    SearchVehiclesMenu();
                    break;
                case '5':
                    ListVehiclesMenu();
                    break;
                case '0':
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }

            return quit;
        }

        private static void OpenGarage()
        {
            var capacity = AskForInt("Enter the number of parking slots: ");
            garage = new Garage<Vehicle>(capacity);
        }

        private static int AskForInt(string question)
        {
            int value;
            bool parsed = false;
            string error = "";

            do
            {
                string input = AskForString(error + question);
                parsed = int.TryParse(input, out value);
                error = "Felaktig inmatning!\n";
            } while (!parsed);

            return value;
        }

        private static string AskForString(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
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

        private static int ParkVehicleMenu()
        {
            Console.Clear();
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 , 4, 0) of your choice"
                + "\n1. Park an Airplane"
                + "\n2. Park a Motorcycle"
                + "\n3. Park a Car"
                + "\n4. Park a Bus"
                + "\n5. Park a Boat"
                + "\n9. Back to previous menu"
                + "\n0. Quit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!"); // Never enters here?
            }

            var quit = 0;
            switch (input)
            {
                case '1':
                    ParkAirplane();
                    break;
                //case '2':
                //    ParkMotorcycle();
                //    break;
                //case '3':
                //    ParkCar();
                //    break;
                //case '4':
                //    ParkBus();
                //    break;
                //case '5':
                //    ParkBoat();
                //    break;
                //case '9':
                //    break;
                case '0':
                    quit = 1;
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }

            return quit;
        }

        private static void ParkAirplane()
        {
            var properties = AskForVehicleProperties();
            var engineCount = AskForInt("Enter the number of engines: ");

            var airplane = new Airplane(properties.RegistrationPlate,
                                        properties.Color,
                                        properties.WheelCount,
                                        engineCount);
            garage.Add(airplane);
        }

        private static VehicleProperties AskForVehicleProperties()
        {
            var registrationPlate = AskForString("Enter registration plate: ");
            var color = AskForString("Enter color: ");
            var wheelCount = AskForInt("Enter the number of wheels: ");

            var properties = new VehicleProperties(registrationPlate,
                                                   color, wheelCount);
            return properties;
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
