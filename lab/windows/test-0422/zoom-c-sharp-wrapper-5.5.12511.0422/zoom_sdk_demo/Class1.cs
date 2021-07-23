
// Reference: 
// https://devforum.zoom.us/t/how-to-create-jwt-token-using-rest-api-in-c/6620/20

using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
namespace ZoomIntegration.Configuration
{

    public class ZoomToken
    {
        public ZoomToken(string ZoomApiKey, string ZoomApiSecret)
        {
            DateTime Expiry = DateTime.UtcNow.AddMinutes(5);
            string ApiKey = ZoomApiKey;
            string ApiSecret = ZoomApiSecret;

            //int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;
            DateTime now = DateTime.UtcNow;
            int ts = (int)(now - new DateTime(1970, 1, 1)).TotalSeconds;

            // Create Security key  using private key above:
            // note that latest version of JWT using Microsoft namespace instead of System
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiSecret));

            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Finally create a Token
            var header = new JwtHeader(credentials);

            //Zoom Required Payload
            var payload = new JwtPayload
            {
                //{ "iss", ApiKey},
                //{ "exp", ts }
                
                // modify by Jing.
                {"appKey", ApiKey},
                {"iat", ts },
                {"exp", ts + 3600},
                {"tokenExp", ts + 3600}
                // end of modification
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            var tokenString = handler.WriteToken(secToken);
            //string Token = tokenString;
            this.Token = tokenString;
            Console.WriteLine("token = " + tokenString);
        }

        public string Token { get; set; }
    }

}

