using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingApplicationNew.Models;
using TravellingApplicationNew.Repository;

namespace TravellingApplicationNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        ITravelRepository loginRepository;
        public LoginController(IConfiguration config, ITravelRepository _l)
        {
            _config = config;
            loginRepository = _l;
        }



        [AllowAnonymous]
        [HttpGet("{userName}/{password}")]
        //loginmethod--IActionResult
        public IActionResult Login(string userName, string password)
        {
            IActionResult response = Unauthorized();

            Login dbUser = null;

            //Authenticate the user by passing username and password
            dbUser = AuthenticateUser(userName, password);



            if (dbUser != null)
            {
                var tokenString = GenerateJSONWebToken(dbUser);
                response = Ok(new
                {
                    token = tokenString,
                    UserId = dbUser.UserId,
                    UserName = dbUser.UserName,
                    Userpassword = dbUser.UserPassword,
                    RoleId = dbUser.RoleId
                });
            }
            return response;
        }
       

        private string GenerateJSONWebToken(Login user)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //generate token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //AuthenticateUSer()
        private Login AuthenticateUser(string userName, string password)
        {

            //validate the user credentials
            //Retrieve data from the database


            Login dbuser = loginRepository.validateUser(userName, password);//checking validity of user by username and password

            if (dbuser != null)
            {

                return dbuser;

            }
            return null;
        }

        //GenerateJsonWebToken()

        // get user details with username and password
        #region userdetails details 
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("getuser/{userName}/{password}")]
        public async Task<IActionResult> getUser(string userName, string password)
        {
            try
            {
                var dbuser = loginRepository.validateUser(userName, password);
                if (dbuser == null)
                {
                    return NotFound();
                }
                return Ok(dbuser);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion


    }
}