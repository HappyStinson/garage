using System;

namespace Garage
{
    class Motorcycle : Vehicle
    {
        public float CylinderVolume { get; set; }

        public Motorcycle(string registrationPlate, string color, float cylinderVolume)
            : base(registrationPlate, color, wheelCount: 2)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString() => String.Format("Motorcycle:{0}{1}{0}{2} cc", Environment.NewLine, base.ToString(), CylinderVolume);
    }
}
