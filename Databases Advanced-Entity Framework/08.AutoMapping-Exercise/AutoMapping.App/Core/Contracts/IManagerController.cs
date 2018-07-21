using System;
using System.Collections.Generic;
using System.Text;
using AutoMapping.App.Core.DTOs;

namespace AutoMapping.App.Core.Contracts
{
    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);

        ManagerDto GetManagerInfo(int employeeId);
    }
}
