using InsuranceConsultingOffice.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceConsultingOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {

        private readonly IPolicyApplication _policyApplication;

        public PolicyController(IPolicyApplication policyApplication)
        {
            _policyApplication = policyApplication; 
        }


        // GET: api/<PolicyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PolicyController>/5
        [HttpPost("{code}")]
        public /*async*/ IActionResult GetByCode([FromRoute] string code)
        {
            var response = /*await*/ _policyApplication.GetPoliciesByCode(code);

            return Ok(response);
        }

        // POST api/<PolicyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PolicyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PolicyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
