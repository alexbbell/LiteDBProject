using LiteDBProject.Data;
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
            return Ok (_premixRepository.GetPremixes());
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
        public async Task<IActionResult> PutPremix(int premixId, Premix premix)
        {

            if(!_premixRepository.PremixExists(premixId)) return NotFound();

            if (premixId != premix.PremixId)  return BadRequest();

            if (!ModelState.IsValid) return BadRequest();
     
            
            _premixRepository.UpdatePremix(premix);
  
            return NoContent();
        }

        // POST: api/Premixes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //        public async Task<ActionResult<Premix>> PostPremix(PremixDto premixDto)
        public async Task<ActionResult<Premix>> PostPremix(int developerId, string vitamins, PremixDto premixCreate)
        {
            List<int> vitaminIds = new List<int>();
            if(vitamins != String.Empty)
            {
                vitaminIds.AddRange(vitamins.Split(',').Select(Int32.Parse).ToList());
            }
            Premix premix = new Premix() { 
                Title = premixCreate.Title,
                Age = premixCreate.Age,
                Tu = premixCreate.Tu,
                Vid = premixCreate.Vid,
                DeveloperId = developerId
                 
            };

            _premixRepository.CreatePremix(vitaminIds, premix);

            return CreatedAtAction("GetPremix", new { id = premixCreate.PremixId }, premixCreate);
        }

        // DELETE: api/Premixes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePremix(int id)
        {
          

            return NoContent();
        }

        
    }
}
