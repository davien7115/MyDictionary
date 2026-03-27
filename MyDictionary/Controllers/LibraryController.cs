using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDictionaryAPI.Mapping;
using MyDictionary.Models;        

namespace MyDictionaryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TermsController : ControllerBase
    {
        private readonly LibraryDbContext _db;

        public TermsController(LibraryDbContext db)
        {
            _db = db;
        }

        // GET: api/terms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TermDto>>> GetAll()
        {
            var entities = await _db.Words.AsNoTracking().ToListAsync();
            var dtos = entities.Select(e => e.ToDto()).ToList();
            return Ok(dtos);
        }

        // GET: api/terms/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TermDto>> GetById(int id)
        {
            var entity = await _db.Words.AsNoTracking()
                                        .FirstOrDefaultAsync(w => w.word_id == id);
            if (entity == null)
                return NotFound();

            return Ok(entity.ToDto());
        }

        // POST: api/terms
        [HttpPost]
        public async Task<ActionResult<TermDto>> Create([FromBody] CreateTermDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Term) || string.IsNullOrWhiteSpace(dto.Definition))
                return BadRequest("Term and Meaning are required.");

            var entity = dto.ToEntity();

            _db.Words.Add(entity);
            await _db.SaveChangesAsync();

            var response = entity.ToDto();

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        // PUT: api/terms/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTermDto dto)
        {
            var entity = await _db.Words.FirstOrDefaultAsync(w => w.word_id == id);
            if (entity == null)
                return NotFound();

            dto.Apply(entity);

            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/terms/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _db.Words.FirstOrDefaultAsync(w => w.word_id == id);
            if (entity == null)
                return NotFound();

            _db.Words.Remove(entity);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}