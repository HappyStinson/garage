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

        public override string ToString()
        {
            var formatted = string.Format("Airplane:{0}{1}{0}", System.Environment.NewLine, base.ToString());

            if (EngineCount > 0)
                formatted += $"{System.Environment.NewLine}{EngineCount} engines";
            //formatted += $"{System.Environment.NewLine}Gliderplane without engine";
                
            return formatted;
        }
    }
}
