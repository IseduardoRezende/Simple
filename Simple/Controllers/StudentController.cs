using Microsoft.AspNetCore.Mvc;
using Simple.Extensions;
using Simple.ViewModels.Students;

namespace Simple.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly SimpleDatabaseContext _simpleDatabase;

        public StudentController(SimpleDatabaseContext simpleDatabase)
        {
            _simpleDatabase = simpleDatabase;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentViewModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                
            _simpleDatabase.Student.Add(student.ToBase());
            await _simpleDatabase.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_simpleDatabase.Student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateStudentViewModel student, long id)
        {
            if (!ModelState.IsValid || id != student.Id)
                return BadRequest();

            _simpleDatabase.Student.Update(student.ToBase());
            await _simpleDatabase.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id == default)
                return BadRequest();

            var student = await _simpleDatabase.Student.FindAsync(id);

            if (student is null)
                return NotFound();

            _simpleDatabase.Student.Remove(student);
            await _simpleDatabase.SaveChangesAsync();            
            return NoContent();                
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            if (id == default)
                return BadRequest();
        
            var student = await _simpleDatabase.Student.FindAsync(id);

            if (student is null)
                return NotFound();

            return Ok(student);
        }
    }
}
