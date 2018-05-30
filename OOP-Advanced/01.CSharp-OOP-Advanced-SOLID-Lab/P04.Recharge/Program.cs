namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            ISleeper worker = new Employee("ID");
            IRechargeable robot=new Robot("ID", 42);
            worker.Sleep();
            robot.Recharge();
        }
    }
}
