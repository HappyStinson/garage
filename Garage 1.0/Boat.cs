namespace Garage
{
    class Boat : Vehicle
    {
        public float Length { get; set; }
        public bool IsSailingBoat { get; set; }

        public Boat(string registrationPlate, string color, float length, bool isSailingBoat = false)
            : base(registrationPlate, color, wheelCount: 0)
        {
            Length = length;
            IsSailingBoat = isSailingBoat;
        }

        public void RegisterAsSailingBoat() => IsSailingBoat = true;

        public override string ToString()
        {
            var boatType = IsSailingBoat ? "Sailing boat" : "Boat";

            return string.Format("{1}:{0}{2}{0}{3} ft", System.Environment.NewLine, boatType, base.ToString(), Length);
        }
    }
}
