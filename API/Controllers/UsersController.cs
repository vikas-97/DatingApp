using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        // To get some data from the database: Using Dependency Injection
            // Generate constructor 'UsersController()'
      
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

            public UsersController(IUserRepository userRepository, IMapper mapper) 
            {
            _mapper = mapper;
            _userRepository = userRepository;// Initialized field from parameter 

            } 


            // Add two endpoints to get all of the users in Database
                // [Httpget] - getting data
            [HttpGet]
            // Returning list of users in Actionresult by using IEnumerable of type AppUser.
            public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() 
            {
                // To store users create variable call users
                // var users = _context.Users.ToList();
                var users = await _userRepository.GetMembersAsync();
               
                return Ok(users); // returning users from this endpoints
                // return users; // returning users from this endpoints

                
            }

            [Authorize]
            // api/users/3
            [HttpGet("{username}")]       // id is the root parameter.
            // Returning list of users in Actionresult by using IEnumerable of type AppUser.
            public async Task<ActionResult<MemberDto>> GetUser(string username) // id from the root parameter
            {
                return await _userRepository.GetMemberAsync(username);  // returning users from this endpoints
         
            }        
     }
}