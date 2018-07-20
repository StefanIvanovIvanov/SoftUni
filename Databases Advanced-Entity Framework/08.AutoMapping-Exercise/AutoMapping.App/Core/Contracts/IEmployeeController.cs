using System;
using AutoMapping.App.Core.DTOs;

namespace AutoMapping.App.Core.Contracts
{
    public interface IEmployeeController
    {
        void AddEmployee(EmployeeDto employessDto);

        void SetBirthday(int employeeId, DateTime date);

        void SetAddress(int employeeId, string address);

        EmployeeDto GetEmployeeInfo(int employeeId);

        EmployeePersonalInfoDto GetEmployeePersonalInfoDto(int employeeId);
    }
}
