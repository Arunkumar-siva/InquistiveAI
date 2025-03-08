using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InquistiveAI_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IHomeRepository _homeRepository;

        public HomeController(IHomeRepository homeRepository)
        {
            this._homeRepository = homeRepository;
        }
        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await this._homeRepository.CheckUserCredentials(loginDto);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
