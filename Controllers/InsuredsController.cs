using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using InsuranceConsultingOffice.Application.Interfaces;
using InsuranceConsultingOffice.Application.Dtos.Request;

namespace InsuranceConsultingOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredsController : ControllerBase
    {
        private readonly IInsuredsApplication _insuredsApplication;

        public InsuredsController(IInsuredsApplication insuredsApplication)
        {
            _insuredsApplication = insuredsApplication;
        }


 
        [HttpGet("{cardId}")]
        public IActionResult GetByCardId(string cardId)
        {
            //INGRESAR VALIDACIÓN DEL CARDID. Simple usando if, o inyectando dependencia del validator.
          
            var response = _insuredsApplication.GetInsuredsByCardId(cardId);

            return Ok(response);
        }



        [HttpPost("Register")]
        public IActionResult Post([FromBody] InsuredRequestDto requestDto)
        {
            var response = _insuredsApplication.RegisterInsured(requestDto);

            return Ok(response);
        }



        [HttpPut("Edit{id}")]
        public IActionResult Put(int id, [FromBody] InsuredRequestDto requestDto)
        {
            var response = _insuredsApplication.EditInsured(requestDto, id);

            return Ok(response);
        }



        [HttpDelete("Delete{id}")]
        public IActionResult Delete(int id)
        {
            var response = _insuredsApplication.RemoveInsured(id);

            return Ok(response);
        }
    }
}
//if (id != insured.InsuredId)
//{
//    return BadRequest();
//}

//_context.Entry(insured).State = EntityState.Modified;

//try
//{
//    await _context.SaveChangesAsync();
//}
//catch (DbUpdateConcurrencyException)
//{
//    if (!InsuredExists(id))
//    {
//        return NotFound();
//    }
//    else
//    {
//        throw;
//    }
//}


// GET: api/Insureds/5
//[HttpGet("{id}")]
//public async Task<ActionResult<Insured>> GetInsured(int id)
//{
//    var insured = await _context.Insureds.FindAsync(id);

//    if (insured == null)
//    {
//        return NotFound();
//    }

//    return insured;
//}
