using Backend_Architecture.DAL.EFCore;
using Backend_Architecture.Entities;
using Backend_Architecture.Entities.Dtos.Fags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FagsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FagsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetFag/{id}")]
        public async Task<IActionResult> GetFag(int id)
        {
            var result = await _context.Fags.FindAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpGet("GetFags")]
        public async Task<IActionResult> GetFags()
        {
            var result = await _context.Fags.ToListAsync();
            if (result.Count == 0) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFagDto FagDto)
        {
            Fag fag = new Fag()
            {
                Question = FagDto.Question,
                Answer = FagDto.Answer,
            };
            await _context.Fags.AddAsync(fag);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFagDto updatefagdto)
        {
            var result = await _context.Fags.FindAsync(id);
            if (result == null) return NotFound();
            result.Question = updatefagdto.Question;
            result.Answer = updatefagdto.Answer;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Fags.FindAsync(id);
            if (result == null) return NotFound();  
             _context.Fags.Remove(result);
            await _context.SaveChangesAsync();  
            return NoContent(); 
        }
    }
}
