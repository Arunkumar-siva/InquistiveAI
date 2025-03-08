using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InquistiveAI_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public TrainerController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        // GET: api/<TrainerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TrainerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TrainerController>
        [HttpPost("AddBatch")]
        public async Task<ActionResult> AddNewBatch([FromBody] BatchDetailsDto batchDetailsDto)
        {
            try
            {
                var response = await this._unitOfWork.Trainer.AddNewBatchAsync(batchDetailsDto);
                await this._unitOfWork.CommitAsync();
                return Ok($"{response} added Successfully");

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/<TrainerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TrainerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
