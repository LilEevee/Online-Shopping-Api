using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
            var tokenEndpoint = "https://dev-uo21vib8sunumd4o.us.auth0.com/oauth/token";
            var clientId = "YHaEShO4CLernWd1OBTISBsajMiBlBZv";
            var clientSecret = "5CzDo1swkB-xLKKEqms6T4zd-tNXGfDufpF1N5M-SxzVqz1amWm8FAyDZKjOsw9t";
            var audience = "https://OnlineShopping/api";
            var grantType = "client_credentials";

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", clientId },
                    { "client_secret", clientSecret },
                    { "audience", audience },
                    { "grant_type", grantType }
                });

            var response = await client.PostAsync(tokenEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadAsStringAsync();
                var tokenJson = JsonSerializer.Deserialize<AuthorizationAccess>(tokenResponse);
                string accessToken = tokenJson.Token;

                return Ok(accessToken);
            }
            else
            {
                return HttpStatusCode.InternalServerError
            }
        }

        public class AuthorizationAccess
        {
            [JsonPropertyName("access_token")]
            public string Token { get; set; }
        }

    }
}
