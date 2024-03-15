using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly ILogger<ClassroomController> logger;
        private readonly SchoolContext context;

        public ClassroomController(ILogger<ClassroomController> logger, SchoolContext context) // injection
        {
            this.logger = logger;
            this.context = context;
        }

        // GET : https://localhost:7060/classroom
        [HttpGet]
        //public IActionResult GetClassrooms(ILogger<ClassroomController> logger) // injection dans la méthode
        public IActionResult GetClassrooms()
        {
            List<Classroom> classrooms = this.context.Classrooms.ToList();

            this.logger.LogInformation("you get all classrooms");

            return Ok(classrooms);
        }

        // GET : https://localhost:7060/classroom/1
        [HttpGet("{id}")]
        public IActionResult GetClassroom(int id)
        {
            if (id <= 0)
                return BadRequest();

            Classroom? classroom = this.context.Classrooms.Find(id);

            if (classroom == null)
                return NotFound();

            return Ok(classroom);
        }

        // POST : https://localhost:7060/classroom + body
        [HttpPost()]
        public IActionResult AddClassroom(Classroom classroom)
        {
            this.context.Add(classroom);
            this.context.SaveChanges();

            return Created($"classroom/{classroom.ClassroomID}", classroom);
        }

        // PUT : https://localhost:7060/classroom/1 + body
        [HttpPut("{id}")]
        public IActionResult AddClassroom(int id, Classroom classroom)
        {
            if(id != classroom.ClassroomID)
                return BadRequest();

            this.context.Update(classroom);
            this.context.SaveChanges();

            return NoContent();
        }

        // DELETE : https://localhost:7060/classroom/1
        [HttpDelete("{id}")]
        public IActionResult RemoveClassroom(int id)
        {
            if (id <= 0)
                return BadRequest();

            Classroom? classroom = this.context.Classrooms.Find(id);

            if (classroom == null)
                return NotFound();


            this.context.Remove(classroom);
            this.context.SaveChanges();

            return Ok(classroom);
        }
    }
}
