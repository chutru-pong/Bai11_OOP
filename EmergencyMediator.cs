//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{
    public class EmergencyMediator : IEmergencyMediator
    {
        private readonly VentilationController ventilation;
        private readonly DoorController        door;
        private readonly Alarm                 alarm;

        public EmergencyMediator(VentilationController ventilation,
                                  DoorController door,
                                  Alarm alarm)
        {
            this.ventilation = ventilation;
            this.door        = door;
            this.alarm       = alarm;
        }

        public void Notify(object sender, string ev)
        {
            Console.WriteLine("[MEDIATOR] Nhận sự kiện '{0}' từ {1}", ev, sender.GetType().Name);

            if (ev == "CRITICAL")
            {
                ventilation.Activate();
                door.OpenEmergencyExits();
                alarm.TriggerAlarm();
            }
            else if (ev == "WARNING")
            {
                ventilation.Activate();
                alarm.TriggerAlarm();
            }
            else if (ev == "RESOLVED")
            {
                ventilation.Deactivate();
                alarm.SilenceAlarm();
            }
        }
    }
}
