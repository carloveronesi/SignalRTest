using Microsoft.AspNetCore.Mvc;

namespace SignalR1.Controllers
{
	[Route("api/message")]
	public class MessageController : Controller
	{
		public IActionResult Post()
		{
			// Broadcast the message to clients 
			return Ok();
		}
	}
}