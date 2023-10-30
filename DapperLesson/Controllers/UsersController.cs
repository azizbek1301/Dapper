using Dapper;
using DapperLesson.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperLesson.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "Select * from Test";
                var users = connection.Query<User>(query);

                return Ok(users);
            }
        }
        [HttpPost]
        public IActionResult GetlUser()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "Select * from Test";
                var users = connection.Query<User>(query);

                return Ok(users);
            }
        }
    }
}
