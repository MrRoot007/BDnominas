using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nomina2018.API.Response;
using Nomina2018.Core.DTOs;
using Nomina2018.Core.Entities;
using Nomina2018.Core.Interfaces;
using Nomina2018.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nomina2018.API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _iEmployeeService;
        private readonly IMapper _mapper;
        //private readonly IUriService _iUriService;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _iEmployeeService = employeeService;
            _mapper = mapper;
        }
        /// <summary>
        /// Retrieve all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetEmployees))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<IEnumerable<EmployeeDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetEmployees([FromQuery] EmployeeQueryFilter filters)
        {
            var employee = await _iEmployeeService.GetEmployees();
            return Ok(new ApiResponse<IEnumerable<Employee>>(employee));
        }
        /// <summary>
        /// Retrieve employee by id
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetEmployee))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<EmployeeDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _iEmployeeService.GetEmployee(id);
            var response = new ApiResponse<Employee>(employee);
            return Ok(response);
        }
        /// <summary>
        /// Retrieve list of employee by department
        /// </summary>
        /// <param name="id">department id</param>
        /// <returns></returns>
        [HttpGet("Department/{id}", Name = nameof(GetEmployeesByDepartment))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<IEnumerable<EmployeeDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetEmployeesByDepartment(int id)
        {
            var employee = await _iEmployeeService.GetEmployeesByDepartment(id);
            var response = new ApiResponse<IEnumerable<Employee>>(employee);
            return Ok(response);
        }
        /// <summary>
        /// Create a employee
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = nameof(Post))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<EmployeeDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            await _iEmployeeService.CreateEmployee(employee);
            employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            var response = new ApiResponse<EmployeeDTO>(employeeDTO);
            return Ok(response);
        }
        /// <summary>
        /// Update a employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <param name="employeeDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}",Name = nameof(Put))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<EmployeeDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            employee.Id = id;
            var result = await _iEmployeeService.UpdateEmployee(employee);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        /// <summary>
        /// Delete a employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = nameof(Delete))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _iEmployeeService.DeleteEmployee(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

    }
}
