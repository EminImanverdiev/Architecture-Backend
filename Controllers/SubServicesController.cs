using Backend_Architecture.DAL.EFCore;
using Backend_Architecture.Entities.Dtos.Service;
using Backend_Architecture.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Architecture.Entities.Dtos.SubService;

namespace Backend_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubServicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubServicesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetSubServices/{id}")]
        public async Task<IActionResult> GetSubServices(int id)
        {
            var result = await _context.SubServices.FindAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpGet("GetSubServices")]
        public async Task<IActionResult> GetSubServices()
        {
            var result= await _context.SubServices.ToListAsync();
            if(result.Count==0) return NotFound(); 
            return Ok(result);  
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSubServiceDto subservicedto)
        {
            SubService subservice = new SubService
            {
                Content = subservicedto.Content,
                Title = subservicedto.Title,
            };
            await _context.SubServices.AddAsync(subservice);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSubServiceDto subservicedto)
        {
            var result = await _context.SubServices.FindAsync(id);
            if (result is null) return NotFound();
            result.Content = subservicedto.Content;
            result.Title = subservicedto.Title;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.SubServices.FindAsync(id);
            if (result is null) return NotFound();
            _context.SubServices.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
