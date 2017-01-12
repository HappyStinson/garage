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
            var busType = IsSchoolBus ? "school" : "city";
            return string.Format("Bus:{0}{1}{0}{2} seats{0}Works as {3} bus", System.Environment.NewLine, base.ToString(), Seats, busType);
        }
    }
}
