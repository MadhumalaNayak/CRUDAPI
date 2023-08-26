using CRUDAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public Response GetAllEmployees()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnect").ToString());
            Response response = new Response();
            DAL dAL = new DAL();
            response = dAL.GetAllEmployees(connection);
            return response;
        }

        [HttpGet]
        [Route("GetAllEmployeesByDepartmentId/{Id}")]
        public Response GetAllEmployeesByDepartmentId(int Id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnect").ToString());
            Response response = new Response();
            DAL dAL = new DAL();
            response = dAL.GetAllEmployeesByDepartmentId(connection, Id);
            return response;

        }

        [HttpPost]
        [Route("AddEmployee")]
        public Response AddEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnect").ToString());
            Response response = new Response();
            DAL dAL = new DAL();
            response = dAL.AddEmployee(connection, employee);
            return response;
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public Response UpdateEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnect").ToString());
            Response response = new Response();
            DAL dAL = new DAL();
            response = dAL.UpdateEmployee(connection, employee);
            return response;
        }

        [HttpDelete]
        [Route("DeleteEmployee /{Id}")]
        public Response DeleteEmployee(int Id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnect").ToString());
            Response response = new Response();
            DAL dAL = new DAL();
            response = dAL.DeleteEmployee(connection, Id);
            return response;
        }


    }
}
