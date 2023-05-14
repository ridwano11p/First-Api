using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Firstapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Firstapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        // Declare a public readonly field of type BrandContext with a different name
        public  readonly BrandContext _dbcontext;

        // Define a constructor that accepts a BrandContext parameter and assigns it to the field
        public BrandController(BrandContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // Create a GET method that returns all the brands from the database asynchronously
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            // Use the ToListAsync method of the DbSet to get all the brands
            var brands = await _dbcontext.Brands.ToListAsync();
            // Return an Ok response with the brands as the data
            return Ok(brands);
        }

        // Create a GET method that returns a single brand by id asynchronously
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            // Use the FindAsync method of the DbSet to get the brand by id
            var brand = await _dbcontext.Brands.FindAsync(id);
            // If the brand is null, return a NotFound response
            if (brand == null)
            {
                return NotFound();
            }
            // Otherwise, return an Ok response with the brand as the data
            return Ok(brand);
        }

        // Create a POST method that creates a new brand in the database asynchronously
        [HttpPost]
        public async Task<ActionResult<Brand>> CreateBrand(Brand brand)
        {
            // Use the AddAsync method of the DbSet to add the brand to the database
            await _dbcontext.Brands.AddAsync(brand);
            // Use the SaveChangesAsync method of the DbContext to save the changes
            await _dbcontext.SaveChangesAsync();
            // Return a CreatedAtAction response with the name of the GET method, the id of the brand, and the brand as the data
            return CreatedAtAction(nameof(GetBrand), new { id = brand.Id }, brand);
        }

        // Create a PUT method that updates an existing brand in the database asynchronously
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, Brand brand)
        {
            // If the id of the brand does not match the id parameter, return a BadRequest response
            if (id != brand.Id)
            {
                return BadRequest();
            }
            // Use the Entry method of the DbContext to mark the brand as modified
            _dbcontext.Entry(brand).State = EntityState.Modified;
            // Try to save the changes asynchronously using a try-catch block
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // If there is a concurrency exception, check if the brand exists in the database using the AnyAsync method of the DbSet
                bool exists = await _dbcontext.Brands.AnyAsync(b => b.Id == id);
                // If it does not exist, return a NotFound response
                if (!exists)
                {
                    return NotFound();
                }
                // Otherwise, rethrow the exception
                else
                {
                    throw;
                }
            }
            // Return a NoContent response to indicate success
            return NoContent();
        }

        // Create a DELETE method that deletes an existing brand from the database asynchronously
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            // Use the FindAsync method of the DbSet to get the brand by id
            var brand = await _dbcontext.Brands.FindAsync(id);
            // If the brand is null, return a NotFound response
            if (brand == null)
            {
                return NotFound();
            }
            // Use the Remove method of the DbSet to delete the brand from the database
            _dbcontext.Brands.Remove(brand);
            // Use the SaveChangesAsync method of the DbContext to save the changes
            await _dbcontext.SaveChangesAsync();
            // Return a NoContent response to indicate success
            return NoContent();
        }
    }
}