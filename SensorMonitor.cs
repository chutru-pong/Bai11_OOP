//Ngô Trường Phúc 202418964
using System;
using System.Collections.Generic;

namespace SensorSystem
{

    public class SensorMonitor
    {
        private readonly List<IAlertObserver> observers = new List<IAlertObserver>();

        // >= 50 là WARNING, >= 80 là CRITICAL
        private const double WarningThreshold  = 50.0;
        private const double CriticalThreshold = 80.0;

        public void Attach(IAlertObserver observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public void Detach(IAlertObserver observer)
        {
            observers.Remove(observer);
        }

        // Đọc giá trị từ sensor, phân loại mức độ và thông báo
        public void CheckSensor(ISensor sensor, string sensorName)
        {
            double value = sensor.ReadValue();
            string unit  = sensor.GetUnit();
            string severity;

            if (value >= CriticalThreshold)
                severity = "CRITICAL";
            else if (value >= WarningThreshold)
                severity = "WARNING";
            else
                severity = "NORMAL";

            if (severity != "NORMAL")
            {
                AlertEvent alertEvent = new AlertEvent(value, severity, sensorName, unit);
                Notify(alertEvent);
            }
            else
            {
                Console.WriteLine("[SensorMonitor] {0}: {1} {2} → BÌNH THƯỜNG", sensorName, value, unit);
            }
        }

        public void Notify(AlertEvent alertEvent)
        {
            foreach (IAlertObserver observer in observers)
            {
                observer.Update(alertEvent);
            }
        }
    }
}
