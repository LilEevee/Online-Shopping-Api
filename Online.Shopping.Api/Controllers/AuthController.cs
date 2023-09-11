using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Online.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var client = new HttpClient();


            var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", _configuration.GetSection("AuthSettings:ClientId").Value },
                    { "client_secret",  _configuration.GetSection("AuthSettings:ClientSecret").Value },
                    { "audience",  _configuration.GetSection("AuthSettings:Audience").Value },
                    { "grant_type",  _configuration.GetSection("AuthSettings:GrantType").Value }
                });

            var response = await client.PostAsync(_configuration.GetSection("AuthSettings:TokenEndPoint").Value, content);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadAsStringAsync();
                var tokenJson = JsonSerializer.Deserialize<AuthorizationAccess>(tokenResponse);
                string accessToken = tokenJson.Token;

                return Ok(accessToken);
            }
            else
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Content("Failed to get the auth token");
            }
        }
    }
    internal sealed class AuthorizationAccess
    {
        [JsonPropertyName("access_token")]
        public string Token { get; set; }
    }
}
