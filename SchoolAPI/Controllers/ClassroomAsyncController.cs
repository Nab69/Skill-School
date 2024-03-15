using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomAsyncController : ControllerBase
    {
        private readonly ILogger<ClassroomController> logger;
        private readonly SchoolContext context;

        public ClassroomAsyncController(ILogger<ClassroomController> logger, SchoolContext context) // injection
        {
            this.logger = logger;
            this.context = context;
        }

        // GET : https://localhost:7060/classroomasync
        [HttpGet]
        public async Task<ActionResult<List<Classroom>>> GetClassrooms()
        {
            var classrooms = await this.context.Classrooms.ToListAsync();

            this.logger.LogInformation("you get all classrooms");

            return Ok(classrooms);
        }

        // GET : https://localhost:7060/classroom/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassroom(int id)
        {
            if (id <= 0)
                return BadRequest();

            Classroom? classroom = await this.context.Classrooms.FindAsync(id);

            if (classroom == null)
                return NotFound();

            return Ok(classroom);
        }

        // POST : https://localhost:7060/classroom + body
        [HttpPost()]
        public async Task<IActionResult> AddClassroom(Classroom classroom)
        {
            this.context.Add(classroom);
            await this.context.SaveChangesAsync();

            return Created($"classroom/{classroom.ClassroomID}", classroom);
        }

        // PUT : https://localhost:7060/classroom/1 + body
        [HttpPut("{id}")]
        public async Task<IActionResult> AddClassroom(int id, Classroom classroom)
        {
            if(id != classroom.ClassroomID)
                return BadRequest();

            this.context.Update(classroom);
            await this.context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE : https://localhost:7060/classroom/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveClassroom(int id)
        {
            if (id <= 0)
                return BadRequest();

            Classroom? classroom = await this.context.Classrooms.FindAsync(id);

            if (classroom == null)
                return NotFound();


            this.context.Remove(classroom);
            await this.context.SaveChangesAsync();

            return Ok(classroom);
        }
    }
}
