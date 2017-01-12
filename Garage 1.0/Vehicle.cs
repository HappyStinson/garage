namespace Garage
{
    internal abstract class Vehicle
    {
        public string RegistrationPlate { get; set; } // readonly?
        public string Color { get; set; } // refactor to enum later? Change text to display as ConsoleColor
        public int WheelCount { get; set; }

        public Vehicle(string registrationPlate, string color, int wheelCount)
        {
            RegistrationPlate = registrationPlate;
            Color = color;
            WheelCount = wheelCount;
        }

        public override string ToString()
        {
            
            return System.String.Format("Registration plate: {1}{0}{2}{0}{3} wheels", System.Environment.NewLine, RegistrationPlate, Color, WheelCount);
        }
    }
}