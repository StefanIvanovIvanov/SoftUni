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
using Employees.DtoModels;
using Microsoft.EntityFrameworkCore;

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
                .Find(employeeId);

            var employeDto = mapper.Map<EmployeeDto>(employee);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employeDto;
        }

        public EmployeePersonalInfoDto GetEmployeePersonalInfoDto(int employeeId)
        {
            var employee = context.Employees
                .Find(employeeId);

            var employeDto = mapper.Map<EmployeePersonalInfoDto>(employee);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employeDto;
        }

        public List<EmployeeManagerDto> OlderThanAge(int age)
        {
            var employees = context.Employees
                .Where(e => e.Birthday != null
                            && Math.Floor
                                ((DateTime.Now - e.Birthday).TotalDays / 365) > age)
                .Include(e => e.Manager)
                .ProjectTo<EmployeeManagerDto>()
                .ToList();

            return employees;
        }
    }
}
