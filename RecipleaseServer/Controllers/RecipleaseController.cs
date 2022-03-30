using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipleaseServerBL.Models;
using System.IO;
using RecipleaseServer.DTO;
using Microsoft.EntityFrameworkCore;

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

        [Route("GetRecepies")]
        [HttpGet]
        public List<Recipe> GetRecepies()
        {
            List<Recipe> list = context.Recipes.ToList();

            return list;
        }


        [Route("GetRecepiesCount")]
        [HttpGet]
        public int GetRecepiesCount()
        {
            int howmany = context.Recipes.Count();

            return howmany;
        }

        [Route("GetUsers")]
        [HttpGet]
        public List<User> GetUsers()
        {
            List<User> list = context.Users.Include(u => u.Recipes).ToList();

            return list;
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
            catch (Exception e)
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
            User user = HttpContext.Session.GetObject<User>("TheUser");
            if (user != null)
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
                var pathFrom = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", "defaultphoto.jpg");
                var pathTo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", $"{recipe.RecipeId}.jpg");
                System.IO.File.Copy(pathFrom, pathTo);
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("UploadImage")]
        [HttpPost]

        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            User user = HttpContext.Session.GetObject<User>("TheUser");
            //Check if user logged in and its ID is the same as the contact user ID
            if (user != null)
            {
                if (file == null)
                {
                    return BadRequest();
                }

                try
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }


                    return Ok(new { length = file.Length, name = file.FileName });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return BadRequest();
                }
            }
            return Forbid();
        }


        [Route("AddToLikedRecipes")]
        [HttpGet]
        public bool AddToLikedRecipes([FromQuery] int recipeID)
        {
            try
            {
                User TheUser;
                TheUser = HttpContext.Session.GetObject<User>("TheUser");

                if (TheUser != null)
                {
                    Saved UserLikedRecipes = new Saved();
                    UserLikedRecipes.UserId = TheUser.UserId;
                    UserLikedRecipes.RecipeId = recipeID;

                    try
                    {
                        context.Saveds.Remove(UserLikedRecipes);
                        context.SaveChanges();
                    }
                    catch
                    {
                        context.Saveds.Add(UserLikedRecipes);
                        context.SaveChanges();
                    }
                    return true;
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                     return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }
}