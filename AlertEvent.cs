//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{

    public class AlertEvent
    {
        public double   Value      { get; private set; }
        public string   Severity   { get; private set; }
        public string   SensorName { get; private set; }
        public string   Unit       { get; private set; }
        public DateTime OccurredAt { get; private set; }

        public AlertEvent(double value, string severity, string sensorName, string unit)
        {
            Value      = value;
            Severity   = severity;
            SensorName = sensorName;
            Unit       = unit;
            OccurredAt = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1} | {2}: {3} {4} | Mức: {5}",
                OccurredAt.ToString("HH:mm:ss"),
                SensorName,
                "Giá trị",
                Value,
                Unit,
                Severity);
        }
    }
}
