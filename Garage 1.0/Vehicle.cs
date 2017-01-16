namespace Garage
{
    internal abstract class Vehicle
    {
        public string RegistrationPlate { get; set; }
        public string Color { get; set; }
        public int WheelCount { get; set; }

        public Vehicle(string registrationPlate, string color, int wheelCount)
        {
            RegistrationPlate = registrationPlate.ToUpperInvariant();
            Color = color.ToLowerInvariant();
            WheelCount = wheelCount < 0 ? 0 : wheelCount;
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