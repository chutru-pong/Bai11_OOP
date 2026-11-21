//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{

    public class DashboardObserver : IAlertObserver
    {
        public void Update(AlertEvent alertEvent)
        {
            Console.WriteLine("[DASHBOARD] Cập nhật bảng điều khiển: {0} | Mức độ: {1} | Lúc: {2}",
                alertEvent.SensorName,
                alertEvent.Severity,
                alertEvent.OccurredAt.ToString("HH:mm:ss"));
        }
    }
}
