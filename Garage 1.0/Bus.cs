namespace Garage
{
    class Bus : Vehicle
    {
        public int Seats { get; set; }
        public bool IsSchoolBus { get; set; } 

        public Bus(string registrationPlate, string color, int numberOfSeats, bool isSchoolBus = false)
            : base(registrationPlate, color, wheelCount: 10)
        {
            IsSchoolBus = isSchoolBus;
            if (IsSchoolBus)
                WheelCount = 6;

            Seats = numberOfSeats;
        }

        public void RegisterAsSchoolBus() => IsSchoolBus = true;
        public void RegisterAsCityBus() => IsSchoolBus = false;

        public override string ToString()
        {
            var busType = IsSchoolBus ? "School bus" : "City bus";
            var seats = Seats > 1 ? "seats" : "seat";
            return string.Format("{1}:{0}{2}{0}{3} {4}",
                System.Environment.NewLine,
                busType, base.ToString(), Seats, seats);
        }
    }
}
