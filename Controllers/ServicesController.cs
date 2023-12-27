using Backend_Architecture.DAL.EFCore;
using Backend_Architecture.Entities.Dtos.AboutSolution;
using Backend_Architecture.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Architecture.Entities.Dtos.Service;

namespace Backend_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetService/{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var result = await _context.Services.FindAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpGet("GetServices")]
        public async Task<IActionResult> GetServices()
        {
            var result= await _context.Services.ToListAsync();  
            if(result.Count==0) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto servicedto)
        {
            Service service = new Service
            {
                Content = servicedto.Content,
                Title = servicedto.Title,
                Picture = servicedto.Picture,
            };
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateServiceDto servicedto)
        {
            var result = await _context.Services.FindAsync(id);
            if (result is null) return NotFound();
            result.Content = servicedto.Content;
            result.Title = servicedto.Title;
            result.Picture = servicedto.Picture;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Services.FindAsync(id);
            if (result is null) return NotFound();
            _context.Services.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
