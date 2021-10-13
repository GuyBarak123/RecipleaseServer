using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipleaseServerBL.Models;
using System.IO;

namespace RecipleaseServer.Controllers
{
    [Route("RecipleaseAPI")]
    [ApiController]
    public class RecipleaseController : ControllerBase
    {
        RecipleaseDBContext context;
        public RecipleaseController(RecipleaseDBContext context)
        {
            this.context = context;
        }

        [Route("Test")]
        [HttpGet]
        public string Test()
        {
            return "My Name is Guy!";
        }

        [Route("Login")]
        [HttpGet]
        public User Login([FromQuery] string Name, [FromQuery] string Password)
        {
            User user = context.Login(Name, Password);

            if (user != null)
            {
                HttpContext.Session.SetObject("TheUser", user);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return user;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }


        }

        [Route("SignUp")]
        [HttpGet]
        public User SignUp([FromBody] User user)
        {
            User user = context.SignUp(Name, Password, Email, Gender, Tag, IsAdmin)
              if (user != null)
            {

            }

        }
    }
}
