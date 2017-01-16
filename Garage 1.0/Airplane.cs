namespace Garage
{
    class Airplane : Vehicle
    {
        private string planeType;

        private int engineCount;
        public int EngineCount
        {
            get
            {
                return engineCount;
            }
            set
            {
                engineCount = value;
                if (engineCount == 0)
                    planeType = "Gliderplane";
                else
                    planeType = "Airplane";
            }
        }

        public Airplane(string registrationPlate, string color, int wheelCount, int engineCount)
            : base(registrationPlate, color, wheelCount)
        {
            EngineCount = engineCount;
        }

        public override string ToString()
        {
            var formatted = string.Format("{1}:{0}{2}{0}", System.Environment.NewLine, planeType, base.ToString());

            if (EngineCount > 0)
                formatted += $"{EngineCount} engines";
                
            return formatted;
        }
    }
}
