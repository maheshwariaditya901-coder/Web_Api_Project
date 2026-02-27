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
        public async Task<ActionResult> GetList()
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


        // we make a list of student class model
        //    private static List<Student> students = new List<Student>
        //{
        //    new Student { Id = 1, Name = "Ram", Age = 20 },
        //    new Student { Id = 2, Name = "Shyam", Age = 22 }
        //};

        //    [HttpGet("all")]
        //    public IActionResult GetStudents()
        //    {
        //        return Ok(students);
        //    }


        [HttpPut("{id}")]
        public async Task<ActionResult> editStudent(int id, Student updatedStudent)
        {
            var existingStudent = await db.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Email = updatedStudent.Email;
            existingStudent.Age = updatedStudent.Age;
            existingStudent.Course = updatedStudent.Course;
            await db.SaveChangesAsync();
            return Ok(updatedStudent);

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteStudent(int id)
        {
            // FirstOrDefaultAsync will execute the query 
            // ActionResult tells the return type of method

            var studentData = await db.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (studentData == null)
            {
                return NotFound();
            }

            db.Students.Remove(studentData);
            await db.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("search")]
        // so route become api/student/search?name=___. and we pass name to the api throuth the parameter of the method
        public async Task<ActionResult> getStudentByName(string name)
        {
            var student = await db.Students.Where((s) => s.Name.ToLower().Contains(name.ToLower())).ToListAsync();


            if (student == null || student.Count == 0)
            {
                return NotFound("No students found.");
            }

 
            return Ok(student);
        }

        [HttpGet("filterbyage")]
        public async Task<ActionResult> FilterStudens(int age)
        {
            var student = await db.Students.Where((s) => s.Age > age).ToListAsync();

            if (student.Count == 0)
            {
                return NotFound("No students found.");
            }

            return Ok(student);

            
        }
         

    }

}
