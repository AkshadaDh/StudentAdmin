using Microsoft.AspNetCore.Mvc;
using StudentAdminUI.Repositories;

namespace StudentAdminUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserInterface userInterface;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserInterface userInterface, ITokenHandler tokenHandler)
        {
            this.userInterface = userInterface;
            this.tokenHandler = tokenHandler;
        }

        public ITokenHandler TokenHandler { get; }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(DomainModels.LoginRequest loginrequest)
        {
            //
            //Check if User is Authenticate?
            var user=await userInterface.Authenticate(loginrequest.Username, loginrequest.Passworrd);

            if(user!=null)
            {

                //Generate JWT Token
                var token=await tokenHandler.CreateTokenAsync(user);
                return Ok(token);

            }
            return BadRequest("Username or Password is Incorrect");
        }
    }
}

