//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("========== HỆ THỐNG GIÁM SÁT CẢM BIẾN THÔNG MINH ==========");
            Console.WriteLine();

            // ------------------------------------------------------------------
            // KHỞI TẠO PATTERN MEDIATOR
            // ------------------------------------------------------------------
            VentilationController ventilation = new VentilationController();
            DoorController        door        = new DoorController();
            Alarm                 alarm       = new Alarm();
            EmergencyMediator mediator = new EmergencyMediator(ventilation, door, alarm);

            // ------------------------------------------------------------------
            // KHỞI TẠO PATTERN OBSERVER
            // ------------------------------------------------------------------
            SensorMonitor monitor = new SensorMonitor();

            AuditLogObserver       auditLog       = new AuditLogObserver();
            EmailAlertObserver     emailAlert      = new EmailAlertObserver("admin@home.vn");
            DashboardObserver      dashboard       = new DashboardObserver();
            EmergencyBridgeObserver bridgeObserver = new EmergencyBridgeObserver(mediator);

            monitor.Attach(auditLog);
            monitor.Attach(emailAlert);
            monitor.Attach(dashboard);
            monitor.Attach(bridgeObserver);

            // ------------------------------------------------------------------
            // KHỞI TẠO PATTERN ADAPTER
            // ------------------------------------------------------------------
            LegacySmokeDetector legacyDetector = new LegacySmokeDetector(0);
            ISensor smokeSensor = new SmokeSensorAdapter(legacyDetector);

            // ------------------------------------------------------------------
            // KỊCH BẢN KIỂM THỬ
            // ------------------------------------------------------------------

            Console.WriteLine("--- T1: Sensor bình thường (mức khói: 20 ppm) ---");
            legacyDetector.SetSmokeLevel(20);
            monitor.CheckSensor(smokeSensor, "Cảm biến khói phòng khách");
            Console.WriteLine();

            Console.WriteLine("--- T2: Sensor cảnh báo WARNING (mức khói: 60 ppm) ---");
            legacyDetector.SetSmokeLevel(60);
            monitor.CheckSensor(smokeSensor, "Cảm biến khói phòng khách");
            Console.WriteLine();

            Console.WriteLine("--- T3: Sensor cảnh báo CRITICAL (mức khói: 90 ppm) ---");
            legacyDetector.SetSmokeLevel(90);
            monitor.CheckSensor(smokeSensor, "Cảm biến khói phòng khách");
            Console.WriteLine();

            // ------------------------------------------------------------------
            // KIỂM THỬ DETACH OBSERVER
            // ------------------------------------------------------------------
            Console.WriteLine("--- T4: Gỡ EmailAlertObserver, kiểm tra không còn nhận thông báo ---");
            monitor.Detach(emailAlert);
            legacyDetector.SetSmokeLevel(55);
            monitor.CheckSensor(smokeSensor, "Cảm biến khói nhà bếp");
            Console.WriteLine();

            // ------------------------------------------------------------------
            // KIỂM THỬ ADAPTER: Giá trị ReadValue() khớp với LegacySmokeDetector
            // ------------------------------------------------------------------
            Console.WriteLine("--- T5: Kiểm tra Adapter chuyển đổi đúng giá trị ---");
            legacyDetector.SetSmokeLevel(42);
            double adapted = smokeSensor.ReadValue();
            bool t5 = (adapted == 42.0) && (smokeSensor.GetUnit() == "ppm");
            Console.WriteLine("T5 " + (t5 ? "Đạt" : "Thất bại") +
                ": ReadValue()=" + adapted + " " + smokeSensor.GetUnit());
            Console.WriteLine();

            // ------------------------------------------------------------------
            // KIỂM THỬ MEDIATOR trực tiếp
            // ------------------------------------------------------------------
            Console.WriteLine("--- T6: Kiểm tra Mediator phản ứng RESOLVED ---");
            mediator.Notify(new object(), "RESOLVED");
            Console.WriteLine();

            Console.WriteLine("============================================================");
            Console.WriteLine("Hoàn tất kiểm thử – Nhấn phím bất kỳ để thoát...");
            if (Environment.UserInteractive)
                Console.ReadKey();
            else
                Console.Read();
        }
    }
}
