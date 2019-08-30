﻿using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Common.Queries;
using MatchaLatte.HumanResources.App.Employees;
using MatchaLatte.HumanResources.Domain.Departments;
using MatchaLatte.HumanResources.Domain.Employees;

namespace MatchaLatte.HumanResources.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            this.departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        }

        public async Task<PaginationResult<EmployeeSummary>> GetEmployeesAsync(EmployeeOption option)
        {
            var employees = await employeeRepository.GetEmployeesAsync(option.Offset, option.Limit);
            var count = await employeeRepository.GetEmployeesCountAsync();
            var departments = await departmentRepository.GetDepartmentsAsync();
            var result = new PaginationResult<EmployeeSummary>
            {
                Items = employees
                    .Select(e => new EmployeeSummary
                    {
                        Name = e.Name,
                        DisplayName = e.DisplayName,
                    })
                    .ToList(),
                ItemCount = count
            };

            return result;
        }

        public Task<EmployeeDetail> CreateEmployeeAsync(CreateEmployeeCommand command)
        {
            throw new NotImplementedException();
        }
    }
}