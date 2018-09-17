using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ID4.Controllers
{
  [Route("identity")]
  public class IdentityController : ControllerBase
  {
    [HttpGet("[action]")]
    public async Task<IActionResult> Login()
    {
      var tokenClient = new TokenClient("https://localhost:5001/connect/token", "ReactApp", "secretkey");
      var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api");

      if (tokenResponse.IsError)
      {
        return Unauthorized();
      }

      return Ok(tokenResponse.Json);
    }

    [HttpGet("test")]
    [Authorize]
    public IActionResult Get()
    {
      return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
  }
}