using Dapper;
using DapperLesson.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
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
        public IActionResult CreateUser(UserDto model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = $"Insert into Test Values ({model.id},'{model.name}',{model.age})";
                connection.Execute(query);
                

                return Ok("Created");
            }
        }
    }
}
