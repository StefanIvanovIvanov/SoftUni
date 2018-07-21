using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapping.App.Core.Contracts;
using AutoMapping.App.Core.DTOs;
using AutoMapping.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoMapping.App.Core.Controllers
{
   public class ManagerController:IManagerController
   {
       private readonly AutoMappingContext context;

        public ManagerController(AutoMappingContext context)
        {
            this.context = context;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);

            var manager = this.context.Employees.Find(managerId);

            if (employee == null || manager == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Manager = manager;

            context.SaveChanges();
        }

        public ManagerDto GetManagerInfo(int employeeId)
        {
            var employee = context.Employees
                .Include(x=>x.ManagerEmployees)
                .Where(x => x.EmployeeId == employeeId)
                .ProjectTo<ManagerDto>()
                .SingleOrDefault();

           // var employee = context.Employees
           //     .Include(m => m.ManagerEmployees)
           //     .SingleOrDefault(m => m.ManagerId == employeeId);
           //
           // var managerDto = Mapper.Map<ManagerDto>(employee);

            if (employee == null)
            {
                throw new ArgumentException("Invalid id");
            }

            return employee;
        }
    }
}
