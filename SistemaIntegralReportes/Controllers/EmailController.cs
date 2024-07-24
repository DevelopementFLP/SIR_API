using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.Interfaces;
using SistemaIntegralReportes.Models;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService) => _emailService = emailService;

        [HttpPost]
        public IActionResult SendEmail(Email email)
        {
            try
            {
                _emailService.SendEmail(email);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
