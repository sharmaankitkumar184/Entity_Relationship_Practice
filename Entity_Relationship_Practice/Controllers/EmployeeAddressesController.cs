using Entity_Relationship_Practice.Dto;
using Entity_Relationship_Practice.Models;
using Entity_Relationship_Practice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Relationship_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAddressesController : ControllerBase
    {
        private readonly IEmployeeAddressesRepository employeeaddressesRepository;

        public EmployeeAddressesController(IEmployeeAddressesRepository employeeaddressesRepository)
        {
            this.employeeaddressesRepository = employeeaddressesRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployeeAddresses()
        {
            try
            {
                return Ok(await employeeaddressesRepository.GetEmployeeAddresses());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeAddresses>> GetEmployeeAddresses(int id)
        {
            try
            {
                var result = await employeeaddressesRepository.GetEmployeeAddresses(id);

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
        public async Task<ActionResult<EmployeeAddresses>> CreateEmployeeAddresses([FromBody] EmployeeAddressDto employeeaddressdto)
        {
            try
            {
                if (employeeaddressdto == null)
                    return BadRequest();
                var empadss = await employeeaddressesRepository.GetEmployeeAddresses(employeeaddressdto.Id);
                if (empadss != null)
                {
                    ModelState.AddModelError("Id", "Employee Address Id already in use");
                    return BadRequest(ModelState);
                }
                var employeeAddress = new EmployeeAddresses
                {

                   City= employeeaddressdto.City,
                   Country= employeeaddressdto.Country,
                   EmployeeId= employeeaddressdto.EmployeeId

                };
                var createdEmployeeAddresses = await employeeaddressesRepository.AddEmployeeAddresses(employeeAddress);

                return CreatedAtAction(nameof(GetEmployeeAddresses),
                    new { id = createdEmployeeAddresses.Id }, createdEmployeeAddresses);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }
    }
}
