// Import necessary namespaces for JWT creation and security
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims; 
using System.Security.Cryptography;
using System.Text; 
using API.Entities; 
using API.Interfaces; 
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

// Define a service class for creating tokens that implements the ITokenService interface
public class TokenServices(IConfiguration config) : ITokenService
{
    // Method to create a JWT token for a given user
    public string CreateToken(AppUser user)
    {
        // Retrieve the token key from the configuration settings
        var tokenKey = config["TokenKey"] ?? throw new Exception("Cannot access tokenKey from appsettings");

        // Ensure the token key is sufficiently long for security purposes
        if (tokenKey.Length < 64) throw new Exception("Your tokenKey needs to be longer");
        
        // Create a security key using the token key and UTF-8 encoding
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

        // Define the claims to be included in the token, here using the user's name as the identifier
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserName)
        };

        // Specify the signing credentials using the security key and HMAC SHA-512 algorithm
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        // Create a token descriptor with the claims, expiration time, and signing credentials
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7), // Set token to expire in 7 days
            SigningCredentials = creds
        };

        // Create a token handler to manage the token creation process
        var tokenHandler = new JwtSecurityTokenHandler();
        
        // Generate a security token based on the descriptor
        var token = tokenHandler.CreateToken(tokenDescriptor);

        // Return the serialized token as a string
        return tokenHandler.WriteToken(token);
    }
}
