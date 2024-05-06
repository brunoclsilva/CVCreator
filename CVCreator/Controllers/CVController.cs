using CVCreator.Domain.Entities.Models;
using CVCreator.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CVCreator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CVController : ControllerBase
    {
        private readonly ICVService _cvService;

        public CVController(ICVService cvService)
        {
            _cvService = cvService;
        }

        [HttpPost(Name = "GenerateCV")]
        public IActionResult GenerateCV([FromBody] CVPayload payload)
        {
            byte[] generatedDocument = _cvService.GenerateCV(payload);

            return File(generatedDocument, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"generated_cv_{payload.Name}.docx");
        }
    }
}
