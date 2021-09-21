using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nomina2018.API.Response;
using Nomina2018.Core.DTOs;
using Nomina2018.Core.Interfaces;
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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _iDepartmentService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _iDepartmentService = departmentService;
            _mapper = mapper;
        }
        /// <summary>
        /// Retrieve all post
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetDepartments))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<IEnumerable<DepartmentDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetDepartments()
        {
            var deparments = _iDepartmentService.GetDepartments();
            var deparmentsDTO = _mapper.Map<IEnumerable<DepartmentDTO>>(deparments);
            var response = new ApiResponse<IEnumerable<DepartmentDTO>>(deparmentsDTO);
            return Ok(response);
        }
    }
}
