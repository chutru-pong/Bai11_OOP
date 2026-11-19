//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{

    public interface IAlertObserver
    {
        void Update(AlertEvent alertEvent);
    }
}
