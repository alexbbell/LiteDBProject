//using LiteDB;
//using LiteDBProject.Data;
//using LiteDBProject.Data.LiteDB;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;
//using System.Text.Json;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace LiteDBProject.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    //[EnableCors("AllowAllHeaders")]
//    public class PremixController : ControllerBase
//    {
//        private readonly IDbContext _dbcontext;
//        public PremixController(IDbContext dbcontext)
//        {
//            _dbcontext = dbcontext;
//         }
//        // GET: api/<PremixController>
//        [HttpGet]
//        public  async Task<IActionResult> GetAll()
//        {
//            //var r = _liteDbContext.AddVitamin();
//            IEnumerable<Premix> cols = _dbcontext.GetPremix();
//            var objectWrapper = new
//            {
//                Rows = cols
//            };

// //           Boolean apw = _liteDbContext.AddPremixWithVit();
//            return new OkObjectResult(objectWrapper) ;
//        }

//        // GET api/<PremixController>/5
//        [HttpGet("{id}")]
//        public Premix Get(int id)
//        {

//            //PremixFakeData pfd = new PremixFakeData();
//            Premix premix = _dbcontext.GetPremix(id);
//            return premix;
//        }

//        // POST api/<PremixController>
//        [HttpPost]
//        //public void Post([FromBody] Premix value)
//        public void Post([FromBody] JsonElement jsonString)
//        {
//            var json = JsonConvert.SerializeObject(jsonString);
//            Response.WriteAsync(json);

//            try
//            {
//                //   var col = _liteDbContext.PostPremix(value);
//                var col = true;
//                if (col == true)
//                {
//                    Response.WriteAsync("Добавлено");
//                }
//                else
//                {
//                    Response.WriteAsync("Не Добавлено");
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.WriteAsync("Не Добавлено. Ошибка" + ex.Message.ToString());
//            }
//        }

//        // PUT api/<PremixController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<PremixController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
