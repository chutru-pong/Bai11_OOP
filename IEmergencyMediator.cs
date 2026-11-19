//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{

    public interface IEmergencyMediator
    {
        void Notify(object sender, string ev);
    }
}
