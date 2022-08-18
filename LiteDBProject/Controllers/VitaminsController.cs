using LiteDBProject.Data;
using LiteDBProject.Data.Models;
using LiteDBProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LiteDBProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitaminsController : ControllerBase
    {
        //private readonly PremixContext _context;
        private readonly IVitaminRepository _vitaminRepository;
        
        public VitaminsController(IVitaminRepository vitaminRepository)
        {
            _vitaminRepository = vitaminRepository;
        }

        // GET: api/Vitamins
        [HttpGet]
        public IActionResult GetVitamins()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_vitaminRepository.GetVitamins());
        }

        // GET: api/Vitamins/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Vitamin))]
        [ProducesResponseType(400)]
        public IActionResult GetVitamin(int id)
        {

            if (!_vitaminRepository.VitaminExists(id)) return NotFound();
            var vitamin = _vitaminRepository.GetVitamin(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(vitamin);

        }

        // PUT: api/Vitamins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVitamin(int id, VitaminDto vitamin)
        {
            if(vitamin == null) return BadRequest(ModelState);

            if (id != vitamin.VitaminId)
                return BadRequest(ModelState);

            if (!_vitaminRepository.VitaminExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();



            Vitamin v = new Vitamin()
            {
                Title = vitamin.VitaminTitle,
                VitaminId = id,
                Rastvor = vitamin.Rastvor

            };

            if (!_vitaminRepository.UpdateVitamin(v))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();


        }

        // POST: api/Vitamins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Vitamin>> PostVitamin(VitaminDto vitamin)
        {
            var vitaminExists = _vitaminRepository.GetVitamins().Where(v => v.Title.Trim().ToUpper() == vitamin.VitaminTitle.ToUpper()).FirstOrDefault();

            if(vitaminExists != null)
            {
                ModelState.AddModelError("", "Vitamin already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Vitamin v = new Vitamin()
            {
                Title = vitamin.VitaminTitle,
                VitaminId = vitamin.VitaminId,
                Rastvor = vitamin.Rastvor

            };

            if(!_vitaminRepository.CreateVitamin(v))
            {
                ModelState.AddModelError("", "something wrong on creating");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully saved");

        }

        // DELETE: api/Vitamins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVitamin(int id)
        {
            if (!_vitaminRepository.VitaminExists(id)) return NotFound();



            var vitaminToDelete = _vitaminRepository.GetVitamin(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_vitaminRepository.DeleteVitamin(vitaminToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();


            //_vitaminRepository.DeleteVitamin()

        }

        private bool VitaminExists(int id)
        {
            return _vitaminRepository.VitaminExists(id);
        }
    }
}
