//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{

    public class AuditLogObserver : IAlertObserver
    {
        public void Update(AlertEvent alertEvent)
        {
            Console.WriteLine("[AUDIT LOG] Ghi nhận: " + alertEvent.ToString());
        }
    }
}
