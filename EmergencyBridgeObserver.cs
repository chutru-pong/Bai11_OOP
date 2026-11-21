//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{

    public class EmergencyBridgeObserver : IAlertObserver
    {
        private readonly IEmergencyMediator mediator;

        public EmergencyBridgeObserver(IEmergencyMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Update(AlertEvent alertEvent)
        {
            Console.WriteLine("[BRIDGE] Chuyển tiếp cảnh báo '{0}' sang Mediator khẩn cấp...", alertEvent.Severity);
            mediator.Notify(this, alertEvent.Severity);
        }
    }
}
