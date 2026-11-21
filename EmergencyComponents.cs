//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{


    public class VentilationController
    {
        public void Activate()
        {
            Console.WriteLine("[VENTILATION] Hệ thống thông gió khẩn cấp được BẬT.");
        }

        public void Deactivate()
        {
            Console.WriteLine("[VENTILATION] Hệ thống thông gió khẩn cấp được TẮT.");
        }
    }

    public class DoorController
    {
        public void OpenEmergencyExits()
        {
            Console.WriteLine("[DOOR] Mở tất cả cửa thoát hiểm.");
        }

        public void LockDown()
        {
            Console.WriteLine("[DOOR] Khóa tất cả cửa.");
        }
    }

    public class Alarm
    {
        public void TriggerAlarm()
        {
            Console.WriteLine("[ALARM] BÁO ĐỘNG! Phát tín hiệu âm thanh khẩn cấp.");
        }

        public void SilenceAlarm()
        {
            Console.WriteLine("[ALARM] Tắt báo động.");
        }
    }
}
