namespace Garage
{
    class Boat : Vehicle
    {
        private static float MinimumShipLength = 39.37f;

        private float length;
        public float Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
                if (Length > MinimumShipLength)
                    IsShip = true;
            }
        }

        public bool IsShip { get; private set; }

        public Boat(string registrationPlate, string color, float length)
            : base(registrationPlate, color, wheelCount: 0)
        {
            Length = length;
        }

        public override string ToString()
        {
            var boatType = IsShip ? "Ship" : "Boat";

            return string.Format("{1}:{0}{2}{0}{3} ft", System.Environment.NewLine, boatType, base.ToString(), Length);
        }
    }
}
