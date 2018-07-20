using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapping.App.Core.Contracts;
using AutoMapping.App.Core.DTOs;
using AutoMapping.Data;
using AutoMapping.Models;

namespace AutoMapping.App.Core.Controllers
{
    public class EmployeeController : IEmployeeController
    {
        private readonly AutoMappingContext context;
        private readonly IMapper mapper;

        public EmployeeController(AutoMappingContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddEmployee(EmployeeDto employessDto)
        {
            var employee = mapper.Map<Employee>(employessDto);

            this.context.Employees.Add(employee);

            this.context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Birthday = date;

            context.SaveChanges();
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Adress = address;

            context.SaveChanges();
        }

        public EmployeeDto GetEmployeeInfo(int employeeId)
        {
            var employee = context.Employees
                .Where(x => x.EmployeeId==employeeId)
                .ProjectTo<EmployeeDto>()
                .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employee;
        }

        public EmployeePersonalInfoDto GetEmployeePersonalInfoDto(int employeeId)
        {
            var employee = context.Employees
                .Where(x => x.EmployeeId == employeeId)
                .ProjectTo<EmployeePersonalInfoDto>()
                .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employee;
        }
    }
}
