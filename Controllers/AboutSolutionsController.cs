using Backend_Architecture.DAL.EFCore;
using Backend_Architecture.Entities;
using Backend_Architecture.Entities.Dtos.AboutSolution;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutSolutionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AboutSolutionController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAboutSolution/{id}")]
        public async Task<IActionResult> GetAboutSolution(int id)
        {
            var result = await _context.AboutSolutions.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result is null) return NotFound();
            return Ok(result);
        }
        [HttpGet("GetAboutSolutions")]
        public async Task<IActionResult> GetAboutSolutions()
        {
            var result= await _context.AboutSolutions.ToListAsync();
            if(result.Count==0) return NotFound();  
            return Ok(result);  
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutSolutionDto aboutsolutiondto)
        {
            AboutSolution aboutsolution = new AboutSolution
            {
                CountTitle = aboutsolutiondto.CountTitle,
                Count = aboutsolutiondto.Count
            };
            await _context.AboutSolutions.AddAsync(aboutsolution);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateAboutSolutionDto aboutsolutiondto)
        {
            var result = await _context.AboutSolutions.FindAsync(id);
            if (result is null) return NotFound();
            result.CountTitle = aboutsolutiondto.CountTitle;
            result.Count = aboutsolutiondto.Count;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.AboutSolutions.FindAsync(id);
            if (result is null) return NotFound();
            _context.AboutSolutions.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
