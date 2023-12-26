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
        [HttpGet]
        public async Task<IActionResult> GetFags()
        {
            var result = await _context.Fags.ToListAsync();
            if (result.Count == 0) return NotFound();
            return Ok(await _context.Fags.ToListAsync());
        }

        [HttpPost]
        public async Task <IActionResult> Create(CreateFagDto FagDto)
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
    }
}
