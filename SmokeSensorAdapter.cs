//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{
    public class SmokeSensorAdapter : ISensor
    {
        private readonly LegacySmokeDetector legacyDetector;

        public SmokeSensorAdapter(LegacySmokeDetector detector)
        {
            legacyDetector = detector;
        }

        public double ReadValue()
        {
            return (double)legacyDetector.GetSmokeLevel();
        }

        public string GetUnit()
        {
            return "ppm";
        }
    }
}
