using Entity.DTOs;
using Entity.Entities;
using System.Security.Claims;

namespace Entity.TokenHandler
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(Login login);  
        string CreateRefreshToken();
       
    }
}
