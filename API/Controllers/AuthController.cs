using Entity.DTOs;
using Entity.Entities;
using Entity.TokenHandler;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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

        [HttpPost("[action]")]
        public async Task<TokenDto> Login([FromForm] Login login)
        {
           

            if (login.UserName == Test().UserName && login.Password == Test().Password)
            {

                Entity.TokenHandler.TokenHandler tokenHandler = new(_configuration);
                TokenDto token = tokenHandler.CreateAccessToken(login);


                return token;

            }
           
            return null;
        }

        [NonAction]
        public Login Test()
        {
            Login model = new()
            {
                UserName = "cemBey",
                Password = "123"
            };
            return model;
        }
    }

}
