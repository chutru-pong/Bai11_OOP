//Ngô Trường Phúc 202418964
using System;

namespace SensorSystem
{

    public interface ISensor
    {
        double ReadValue();
        string GetUnit();
    }
}
