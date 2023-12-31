﻿using Entity_Relationship_Practice.Models;
using Entity_Relationship_Practice.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Relationship_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await departmentRepository.GetDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            try
            {
                var result = await departmentRepository.GetDepartment(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateDepartment([FromBody] Department department)
        {
            try
            {
                if (department == null)
                    return BadRequest();

                var createdDepartment = await departmentRepository.AddDepartment(department);

                return CreatedAtAction(nameof(GetDepartment),
                    new { id = createdDepartment.DepartmentId }, createdDepartment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new department record");
            }
        }
    }
}
