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
            var formatted = string.Format("Registration plate: {1}{0}{2}", System.Environment.NewLine, RegistrationPlate, Color);

            if (WheelCount > 0)
                formatted += $"{System.Environment.NewLine}{WheelCount} wheels";

            return formatted;
        }
    }
}