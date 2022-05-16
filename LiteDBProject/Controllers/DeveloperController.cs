using LiteDBProject.Data;
using LiteDBProject.Data.LiteDB;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiteDBProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {

        private readonly IDbContext _dbContext;
        public DeveloperController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<DeveloperController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DeveloperController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeveloperController>
        [HttpPost]
        public void Post([FromBody] Developer value)
        {
            //Object developer = JsonConvert.DeserializeObject<Developer>(value);

            _dbContext.PostDeveloper(value);


        }

        // PUT api/<DeveloperController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeveloperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
