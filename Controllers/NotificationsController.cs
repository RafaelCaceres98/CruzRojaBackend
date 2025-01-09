
// NotificationsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly IEmailService _emailService;

    public NotificationsController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    //[HttpPost("send")]
    //public async Task<IActionResult> SendNotification([FromBody] EmailRequest emailRequest)
    //{
    //    if (emailRequest == null || string.IsNullOrEmpty(emailRequest.To) || string.IsNullOrEmpty(emailRequest.Subject) || string.IsNullOrEmpty(emailRequest.HtmlContent))
    //    {
    //        return BadRequest("Invalid email request");
    //    }

    //    try
    //    {
    //        await _emailService.SendEmailAsync(emailRequest.To, emailRequest.Subject, emailRequest.HtmlContent);
    //        return Ok("Email sent successfully");
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, $"Internal server error: {ex.Message}");
    //    }
    //}

    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] EmailRequest emailRequest)
    {
        if (emailRequest == null || string.IsNullOrEmpty(emailRequest.To) || string.IsNullOrEmpty(emailRequest.Subject) || string.IsNullOrEmpty(emailRequest.HtmlContent))
        {
            return BadRequest(new { message = "Invalid email request" });
        }

        try
        {
            await _emailService.SendEmailAsync(emailRequest.To, emailRequest.Subject, emailRequest.HtmlContent);
            return Ok(new { message = "Email sent successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }

}

public class EmailRequest
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string HtmlContent { get; set; }
}
