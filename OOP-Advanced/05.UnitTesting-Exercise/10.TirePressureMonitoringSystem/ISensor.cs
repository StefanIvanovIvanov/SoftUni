using System;
using System.Collections.Generic;
using System.Text;

namespace _10.TirePressureMonitoringSystem
{
    public interface ISensor
    {
        double PopNextPressurePsiValue();
    }
}
