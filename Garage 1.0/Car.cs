namespace Garage
{
    public enum FuelType
    {
        Gasoline,
        Diesel,
        Electric,
        Ethanol
    }

    class Car : Vehicle
    {
        public FuelType FuelType { get; set; }

        public Car(string registrationPlate, string color, FuelType fuelType)
            : base(registrationPlate, color, wheelCount: 4)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return System.String.Format("Car:{0}{1}{0}Engine runs on {2}", System.Environment.NewLine, base.ToString(), FormatFuelType());
        }

        private string FormatFuelType()
        {
            var formatted = FuelType.ToString().ToLowerInvariant();
            if (FuelType == FuelType.Electric)
                formatted += "ity"; // Electric -> electricity

            return formatted;
        }
    }
}
