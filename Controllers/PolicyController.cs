using InsuranceConsultingOffice.Application.Dtos.Request;
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



        [HttpGet("{code}")]
        public /*async*/ IActionResult GetByCode([FromRoute] string code)
        {
            var response = /*await*/ _policyApplication.GetPoliciesByCode(code);

            return Ok(response);
        }


 
        [HttpPost("Register")]
        public IActionResult Post([FromBody] PolicyRequestDto requestDto)
        {
            var response = _policyApplication.RegisterPolicy(requestDto);

            return Ok(response);
        }



        [HttpPut("Edit{id}")]
        public IActionResult Put(int id, [FromBody] PolicyRequestDto requestDto)
        {
            var response = _policyApplication.EditPolicy(id, requestDto);

            return Ok(response);
        }



        [HttpDelete("Delete{id}")]
        public IActionResult Delete(int id)
        {
            var response = _policyApplication.RemovePolicy(id);

            return Ok(response);
        }
    }
}
