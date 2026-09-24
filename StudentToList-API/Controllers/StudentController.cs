using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentToList_API.Models;
using StudentToList_API.Services;
using System.Security.Cryptography;
using StudentToList_API.DTO;

namespace StudentToList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest();
            }

            var newStudent = new Student
            {
                StudentId = Guid.NewGuid(),
                Name = dto.Name,
                Lastname = dto.Lastname,
                Email = dto.Email

            };

            _context.Add(newStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent),new { id = newStudent.StudentId}, newStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(Guid id, Student updateStudent)
        {
            var student = await _context.Students.FindAsync(id);

            if (student is null)
                return NotFound();

            student.Name = updateStudent.Name;
            student.Lastname = updateStudent.Lastname;
            student.Email = updateStudent.Email;

            _context.SaveChanges();
            return Ok(NoContent());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok(NoContent());
        }
    }
}
