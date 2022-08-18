using LiteDBProject.Data;
using LiteDBProject.Data.Models;
using LiteDBProject.Data.SQLite;
using LiteDBProject.Interfaces;
using LiteDBProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiteDBProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremixesController : ControllerBase
    {
        private readonly IPremixRepository _premixRepository;
        private readonly IVitaminRepository _vitaminRepository;

        public PremixesController(IPremixRepository premixRepository, IVitaminRepository vitaminRepository)
        {
            _premixRepository = premixRepository;
            _vitaminRepository = vitaminRepository;
        }

        // GET: api/Premixes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Premix>>> Getpremixes()
        {
          if (_premixRepository.GetPremixes == null)
          {
              return NotFound();
          }
            return Ok (_premixRepository.GetPremixes().OrderByDescending(p=>p.PremixId));
        }

        // GET: api/Premixes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PremixDto>> GetPremix(int id)
        {

            var premix = _premixRepository.GetPremix(id);

            if (premix == null)
            {
                return NotFound();
            }

            return premix;
        }

        // PUT: api/Premixes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPremix(int premixId, PremixDto premixUpdate)
        {

            if(!_premixRepository.PremixExists(premixId)) return NotFound();

            if (premixId != premixUpdate.PremixId)  return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            Premix premix = new Premix()
            {
                PremixId = premixId,
                Title = premixUpdate.Title,
                Age = premixUpdate.Age,
                Tu = premixUpdate.Tu,
                Vid = premixUpdate.Vid,
                DeveloperId = premixUpdate.DeveloperId
            };


            if (premixUpdate.Vitamins != null)
            {
                //Добоавить проверку, если витамины уже есть в таблице
                premix.PremixVitamins = new List<PremixVitamin>();
                foreach (var vitamin in premixUpdate.Vitamins)
                {
                    premix.PremixVitamins.Add(new PremixVitamin { PremixId = premixUpdate.PremixId, VitaminId = vitamin.VitaminId });
                }
            }

            bool isUpdated = _premixRepository.UpdatePremix(premixId, premix);
 

            return Ok(isUpdated);
        }

        // POST: api/Premixes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Premix>> PostPremix(PremixDto premixCreate)
        {
            List<int> vitaminIds = new List<int>();
            Premix premix = new Premix() { 
                Title = premixCreate.Title,
                Age = premixCreate.Age,
                Tu = premixCreate.Tu,
                Vid = premixCreate.Vid,
                DeveloperId = premixCreate.DeveloperId               
            };


            if (premixCreate.Vitamins != null)
            {
                premix.PremixVitamins = new List<PremixVitamin>();
                foreach (var vitamin in premixCreate.Vitamins)
                {
                    premix.PremixVitamins.Add(new PremixVitamin { PremixId = premixCreate.PremixId, VitaminId = vitamin.VitaminId});
                }
            }

            _premixRepository.CreatePremix( premix);

            return CreatedAtAction("GetPremix", new { id = premixCreate.PremixId }, premixCreate);
        }

        // DELETE: api/Premixes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePremix(int id)
        {
            if (!_premixRepository.PremixExists(id)) return NotFound();

            var premix = _premixRepository.GetPremix(id);
            Premix pr = new Premix() { PremixId = premix.PremixId };
            _premixRepository.DeletePremix(pr);

            return NoContent();
        }

        
    }
}
