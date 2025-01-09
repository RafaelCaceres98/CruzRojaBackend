using Microsoft.AspNetCore.Mvc;
using Backend_CruzRoja.Utilidades; // Asegúrate de tener el namespace correcto aquí

namespace Backend_CruzRoja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        private readonly TelegramNotificationService _telegramService;

        public TelegramController()
        {
            // Reemplaza con tus credenciales de bot y chat ID
            string botToken = "7470712382:AAHT6LGTl53rdE256kehg_IXGfEDiE4Tj2A";
            long chatId = 5997661225;

            _telegramService = new TelegramNotificationService(botToken, chatId);
        }

        //[HttpPost("EnviarMensaje")]
        //public async Task<IActionResult> EnviarMensaje([FromBody] string mensaje)
        //{
        //    try
        //    {
        //        await _telegramService.EnviarMensaje(mensaje);
        //        return Ok("Mensaje enviado correctamente a Telegram.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error al enviar mensaje a Telegram: {ex.Message}");
        //    }
        //}

        [HttpPost("EnviarMensaje")]
        public async Task<IActionResult> EnviarMensaje([FromBody] string mensaje)
        {
            try
            {
                await _telegramService.EnviarMensaje(mensaje);
                return Ok(new { mensaje = "Mensaje enviado correctamente a Telegram." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = $"Error al enviar mensaje a Telegram: {ex.Message}" });
            }
        }
    }
}
