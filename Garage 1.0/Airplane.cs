namespace Garage
{
    class Airplane : Vehicle
    {
        public int EngineCount { get; set; }

        public Airplane(string registrationPlate, string color, int wheelCount, int engineCount)
            : base(registrationPlate, color, wheelCount)
        {
            EngineCount = engineCount;
        }

        public override string ToString() => string.Format("Airplane:{0}{1}{0}{2} engines", System.Environment.NewLine, base.ToString(), EngineCount);
    }
}
