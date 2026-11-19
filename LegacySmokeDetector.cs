//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{
    public class LegacySmokeDetector
    {
        private int smokeLevel;

        public LegacySmokeDetector(int initialLevel = 0)
        {
            smokeLevel = initialLevel;
        }

        public int GetSmokeLevel()
        {
            return smokeLevel;
        }

        public void SetSmokeLevel(int value)
        {
            smokeLevel = value;
        }
    }
}
