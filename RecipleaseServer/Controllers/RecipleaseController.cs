using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipleaseServerBL.Models;
using System.IO;
using RecipleaseServer.DTO;

namespace RecipleaseServer.Controllers
{
    [Route("RecipleaseAPI")]
    [ApiController]
    public class RecipleaseController : ControllerBase
    {
        RecipleaseContext context;
        public RecipleaseController(RecipleaseContext context)
        {
            this.context = context;
        }

        [Route("Test")]
        [HttpGet]
        public string Test()
        {
            return "My Name is Guy!";
        }

        [Route("GetLookups")]
        [HttpGet]
        public LookupTables GetLookups()
        {
            LookupTables obj = new LookupTables()
            {
                Genders = context.Genders.ToList(),
                Tags = context.Tags.ToList(),
                Ingridients = context.Ingridients.ToList(),
              

            };

            return obj;
        }

        [Route("Login")]
        [HttpGet]
        public User Login([FromQuery] string email, [FromQuery] string password)
        {
            User user = context.Login(email, password);

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
        [HttpPost]
        public User SignUp([FromBody] User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return user;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return null;
            }
        }
        [Route("Explore")]
        [HttpGet]
        public List<Recipe> Explore()
        {
            return context.Recipes.ToList(); 
        }


        [Route("NewPost")]
        [HttpPost]
        public Recipe NewPost([FromBody] Recipe recipe)
        {
            try
            {
                context.Recipes.Add(recipe);
                context.SaveChanges();
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return recipe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return null;
            }
        }
    }
}
