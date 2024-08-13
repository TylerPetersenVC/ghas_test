using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MockUsersController : ControllerBase
{
    // Mock Data: Return a list of AppUser objects
    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetMockUsers()
    {
        var mockUsers = new List<AppUser>
        {
            new AppUser
            {
                Id = 1,
                UserName = "john_doe",
                PasswordHash = new byte[] { 1, 2, 3 }, // Mock data
                PasswordSalt = new byte[] { 4, 5, 6 }  // Mock data
            },
            new AppUser
            {
                Id = 2,
                UserName = "jane_smith",
                PasswordHash = new byte[] { 7, 8, 9 }, // Mock data
                PasswordSalt = new byte[] { 10, 11, 12 }  // Mock data
            },
            new AppUser
            {
                Id = 3,
                UserName = "alice_johnson",
                PasswordHash = new byte[] { 13, 14, 15 }, // Mock data
                PasswordSalt = new byte[] { 16, 17, 18 }  // Mock data
            }
        };

        return Ok(mockUsers);
    }

    // Mock Data: Return a single AppUser by ID
    [HttpGet("{id:int}")]
    public ActionResult<AppUser> GetMockUser(int id)
    {
        var mockUser = new AppUser
        {
            Id = id,
            UserName = "mock_user_" + id,
            PasswordHash = new byte[] { 1, 2, 3 }, // Mock data
            PasswordSalt = new byte[] { 4, 5, 6 }  // Mock data
        };

        return Ok(mockUser);
    }
}
