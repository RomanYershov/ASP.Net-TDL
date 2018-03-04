using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TDList.Abstractions;
using TDList.BL;
using TDList.Models;

namespace ToDoList.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]


    public class AccountController : Controller
    {
        private readonly IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }

        [HttpPost]
        [Route("/api/adduser")]
        public async Task Registration([FromBody] AccountModel newUser)
        {
            if (newUser == null) await Response.WriteAsync("");
             _account.Registration(newUser);

            var identity = GetIdentity(newUser);
            if (identity == null)
            {
                await Response.WriteAsync("Логин или пароль неверный");
            }
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
                );

            AccountInfoModel accountInfoModel = _account.GetAccountInfo(newUser);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            accountInfoModel.Token = encodedJwt;

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(encodedJwt,
                new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }




        [HttpPost]
        [Route("/api/gettoken")]
        public async Task GetToken([FromBody] AccountModel account)
        {   
            var identity = GetIdentity(account);
            if (identity == null)
            {
                Response.ContentType = "application/json";
                await Response.WriteAsync("Не верный логин или пароль");
                return;
            }
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
                );

            AccountInfoModel accountInfoModel = _account.GetAccountInfo(account);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            accountInfoModel.Token = encodedJwt;

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(encodedJwt,
                new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }



        private ClaimsIdentity GetIdentity(AccountModel account)
        {
            if (_account.IsAuthorized(account))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, account.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, account.Role),
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Token",
                    ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }
            return null;
        }
    }
}