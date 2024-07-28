using Azure;
using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Models.FileUploadProcess;
using InsuranceConsultingOffice.Infrastructure.Persistences.Repositories;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceConsultingOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadProcess _uploadProcess;
        private readonly InsuranceDbContext _context;

        public FileUploadController(IFileUploadProcess process, InsuranceDbContext context)
        {
            _uploadProcess = process;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var repository = new PolicyRepository(_context);
            var response = repository.GetAllPoliciesIds();

            return Ok();
        }

        // POST api/<FileUploadController>
        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            try
            {
                var response = new BaseResponse<bool>();

                string[] permittedExtensions = { ".txt", ".xlsx" };
                var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

                if ( file is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se ha recibido ningún archivo.";

                    return Ok(response);
                }

                if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                {
                    response.IsSuccess = false;
                    response.Message = "El tipo de archivo que intenta cargar no esta soportado.";
                
                    return Ok(response);
                }
                
                response = _uploadProcess.UploadFile(file);

                return Ok(response);
                
            }
            catch (FileNotFoundException  ex) // or FileLoadException 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
