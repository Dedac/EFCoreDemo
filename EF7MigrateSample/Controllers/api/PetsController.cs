using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using EF7NavigationSample.Models;

namespace EF7MigrateSample.Controllers
{
    [Produces("application/json")]
    [Route("api/Pets")]
    public class PetsController : Controller
    {
        private PetPalaceDbContext _context;

        public PetsController(PetPalaceDbContext context)
        {
            _context = context;
        }

        // GET: api/Pets
        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets;
        }

        // GET: api/Pets/5
        [HttpGet("{id}", Name = "GetPet")]
        public async Task<IActionResult> GetPet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Pet pet = await _context.Pets.SingleAsync(m => m.Id == id);

            if (pet == null)
            {
                return HttpNotFound();
            }

            return Ok(pet);
        }

        // PUT: api/Pets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet([FromRoute] int id, [FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != pet.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Pets
        [HttpPost]
        public async Task<IActionResult> PostPet([FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Pets.Add(pet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PetExists(pet.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetPet", new { id = pet.Id }, pet);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Pet pet = await _context.Pets.SingleAsync(m => m.Id == id);
            if (pet == null)
            {
                return HttpNotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return Ok(pet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Count(e => e.Id == id) > 0;
        }
    }
}