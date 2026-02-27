using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_Project.Models;

namespace Web_Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly MvcappDbContext db;

        public StudentApiController(MvcappDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult>  GetStudents()
        {
            var data = await db.Students.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(Student st)
        {
          await db.Students.AddAsync(st); 
            await db.SaveChangesAsync();
            return Ok(st);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> editUser(int id , Student st)
        {
            
        }

    }
}
