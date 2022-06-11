using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // Some required attributes
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // To get some data from the database: Using Dependency Injection
            // Generate constructor 'UsersController()'
        private readonly DataContext _context;

            public UsersController(DataContext context) // specifying 'datacontext' - using API.Data
            {
            _context = context;                 // Initialized field from parameter 

            } 


            // Add two endpoints to get all of the users in Database
                // [Httpget] - getting data
            [HttpGet]
            // Returning list of users in Actionresult by using IEnumerable of type AppUser.
            public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
            {
                // To store users create variable call users
                // var users = _context.Users.ToList();
                
                return await _context.Users.ToListAsync(); // returning users from this endpoints
                // return users; // returning users from this endpoints

                
            }

            // api/users/3
            [HttpGet("{id}")]       // id is the root parameter.
            // Returning list of users in Actionresult by using IEnumerable of type AppUser.
            public async Task<ActionResult<AppUser>> GetUser(int id) // id from the root parameter
            {
                // To store users create variable call users
                // var user = _context.Users.Find(id);
                
                return await _context.Users.FindAsync(id); // returning users from this endpoints

                
                // return user; // returning users from this endpoints

                
            }


    }
}