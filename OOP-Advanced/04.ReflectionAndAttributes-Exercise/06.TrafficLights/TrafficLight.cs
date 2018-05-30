using System;
using System.Collections.Generic;
using System.Text;

public class TrafficLight
{
    private Signal signal;

    public TrafficLight(string signal)
    {
        this.signal = (Signal)Enum.Parse(typeof(Signal), signal);
    }

    public void Update()
    {
        int previous = (int)signal;
        previous++;
        signal = (Signal)(previous % Enum.GetNames(typeof(Signal)).Length);
    }
}