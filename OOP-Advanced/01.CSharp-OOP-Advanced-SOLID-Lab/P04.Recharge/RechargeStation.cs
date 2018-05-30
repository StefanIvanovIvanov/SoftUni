using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    class RechargeStation
    {
        public void Recharge(IRechargeable rechargeable)
        {
            rechargeable.Recharge();
        }
    }
}
