//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{

    public class EmailAlertObserver : IAlertObserver
    {
        private readonly string recipientEmail;

        public EmailAlertObserver(string email)
        {
            recipientEmail = email;
        }

        public void Update(AlertEvent alertEvent)
        {
            Console.WriteLine("[EMAIL] Gửi đến {0}: Cảnh báo {1} từ {2} – Giá trị {3} {4}",
                recipientEmail,
                alertEvent.Severity,
                alertEvent.SensorName,
                alertEvent.Value,
                alertEvent.Unit);
        }
    }
}
