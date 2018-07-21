using System;
using System.Collections.Generic;
using AutoMapping.App.Core.DTOs;
using Employees.DtoModels;

namespace AutoMapping.App.Core.Contracts
{
    public interface IEmployeeController
    {
        void AddEmployee(EmployeeDto employessDto);

        void SetBirthday(int employeeId, DateTime date);

        void SetAddress(int employeeId, string address);

        EmployeeDto GetEmployeeInfo(int employeeId);

        EmployeePersonalInfoDto GetEmployeePersonalInfoDto(int employeeId);

        List<EmployeeManagerDto> OlderThanAge(int age);
    }
}
