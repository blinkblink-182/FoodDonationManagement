using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodDonationManagement.Models;

namespace FoodDonationManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DonarsController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donar>>> GetDonars()
        {
            return await _context.Donars.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Donar>> GetDonar(int id)
        {
            var donar = await _context.Donars.FindAsync(id);

            if (donar == null)
            {
                return NotFound();
            }

            return donar;
        }


        [HttpPost]
        public async Task<ActionResult<Donar>> PostDonar(Donar donar)
        {
            var newDonar = _context.Donars.Add(donar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonar", new { id = newDonar.Entity.DonarId }, newDonar.Entity);
        }
    }
}
