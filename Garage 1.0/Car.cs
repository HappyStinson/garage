namespace Garage
{
    class Car : Vehicle
    {
        public enum FuelType
        {
            BadInput,
            Gasoline,
            Diesel,
            Electric,
            Ethanol
        }

        public FuelType Fuel { get; set; }

        public Car(string registrationPlate, string color, FuelType fuelType)
            : base(registrationPlate, color, wheelCount: 4)
        {
            Fuel = fuelType;
        }

        public override string ToString()
        {
            return string.Format("Car:{0}{1}{0}Engine runs on {2}", System.Environment.NewLine, base.ToString(), FormatFuelType());
        }

        private string FormatFuelType()
        {
            var fuelTypeString = Fuel.ToString();
            var formatted = char.ToLowerInvariant(fuelTypeString[0]) + fuelTypeString.Substring(1);

            if (Fuel == FuelType.Electric)
                formatted += "ity"; // Electric -> electricity

            return formatted;
        }
    }
}
