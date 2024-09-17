using DotNet8WebApi.FirebaseExample.Models;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebApi.FirebaseExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendMessageAsync([FromBody] MessageRequest messageRequest)
    {
        var message = new Message()
        {
            Notification = new Notification
            {
                Title = messageRequest.Title,
                Body = messageRequest.Body,
            },
            Data = new Dictionary<string, string>()
            {
                ["FirstName"] = "Lin Thit",
                ["LastName"] = "Htoo"
            },
            Token = messageRequest.DeviceToken
        };

        var messaging = FirebaseMessaging.DefaultInstance;
        var result = await messaging.SendAsync(message);

        return Ok(result);
    }
}
