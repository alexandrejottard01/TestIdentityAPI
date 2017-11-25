using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestIdentityAPI;
using TestIdentityAPI.Controllers;

namespace MoveAndSeeAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/User")]
    public class UserController : BaseController
    {

        public UserController(UserManager<ApplicationUser> uMgr, MoveAndSeeDatabaseTestContext context) : base(uMgr, context)
        {
        }
        //AddUser OK
        //EditUserByPseudo OK
        //GetUserById OK
        //GetUserByPseudo OK
        //DeleteUserById OK


        
        //POST api/User/AddUser OK
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody]ApplicationUser user)
        {
            
                
                if(ModelState.IsValid){
                    Context.ApplicationUser.Add(user);
                    Context.SaveChanges();

                    return Ok();
                }
                else{
                    return BadRequest();
                }
            
        }

        //POST api/User/EditUser
        [HttpPut("EditUser")] 
        public IActionResult EditUser([FromBody]ApplicationUser user)
        {
            
                if(!Context.ApplicationUser.Any(a=>a.Id == user.Id)){
                    return NotFound();
                }
                else{
                    if(ModelState.IsValid){
                        Context.Attach(user);
                        Context.Entry(user).State = EntityState.Modified; 

                        try{
                            Context.SaveChanges();
                            return Ok();
                        }
                        catch(DbUpdateConcurrencyException e){
                            return new StatusCodeResult((int)HttpStatusCode.Conflict);
                        }
                        
                    }
                    else{
                        return BadRequest();
                    } 
                }   
            
        }

        // GET api/User/GetUserById/5 OK
        [HttpGet("GetUserById/{idUser}")]
        public IActionResult GetUserById(string idUser)
        {
            
                ApplicationUser user = Context.ApplicationUser
                        .Include(a=>a.InterestPoint)
                            .ThenInclude(a => a.VoteInterestPoint)
                        .Include(a=>a.InterestPoint)
                            .ThenInclude(a => a.Description)
                                .ThenInclude(a => a.VoteDescription)
                        .Include(a=>a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a =>a.UnknownPoint)
                        .SingleOrDefault(a => a.Id == idUser);
                if(user == null){
                    return NotFound();
                }
                else{
                    return Ok(user);
                }
            
        }

        // GET api/User/GetUserByPseudo/chronix OK
        [HttpGet("GetUserByPseudo/{pseudoUser}")]
        public IActionResult GetUserByPseudo(string pseudoUser)
        {

                ApplicationUser user = Context.ApplicationUser
                        .Include(a=>a.InterestPoint)
                            .ThenInclude(a => a.VoteInterestPoint)
                        .Include(a=>a.InterestPoint)
                            .ThenInclude(a => a.Description)
                                .ThenInclude(a => a.VoteDescription)
                        .Include(a=>a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a =>a.UnknownPoint)
                        .SingleOrDefault(a => a.UserName == pseudoUser);

                if(user == null){
                    return NotFound();
                }
                else{
                    return Ok(user);
                }
            
        }

        //GET api/User/DeleteUserById/3 OK
        [HttpDelete("DeleteUserById/{idUser}")]
        public IActionResult DeleteUserById(string idUser)
        {
                ApplicationUser user = Context.ApplicationUser
                                .Where(a => a.Id == idUser)
                                .Include(a=>a.InterestPoint)
                                    .ThenInclude(a => a.VoteInterestPoint)
                                .Include(a=>a.InterestPoint)
                                    .ThenInclude(a => a.Description)
                                        .ThenInclude(a => a.VoteDescription)
                                .Include(a=>a.Description)
                                    .ThenInclude(a => a.VoteDescription)
                                .Include(a =>a.UnknownPoint)
                                .Include(a => a.VoteDescription)
                                .Include(a => a.VoteInterestPoint)
                                .SingleOrDefault();

                if(user == null){
                    return NotFound();
                }
                else{
                    //Suppression des points d'intérêt
                    foreach(var interestPoint in user.InterestPoint.ToList()){

                        //Suppression des descriptions
                        foreach(var description in interestPoint.Description.ToList()){

                            //Suppression des votes de description
                            foreach(var voteDescription in description.VoteDescription.ToList()){
                                Context.VoteDescription.Remove(voteDescription);
                            }
                            Context.Description.Remove(description);
                        }

                        //Suppression des votes de point d'intérêt
                        foreach(var voteInterestPoint in interestPoint.VoteInterestPoint.ToList()){
                            Context.VoteInterestPoint.Remove(voteInterestPoint);
                        }
                        Context.InterestPoint.Remove(interestPoint);
                    }

                    //Suppression des points inconnus
                    foreach(var unknownPoint in user.UnknownPoint.ToList()){
                        Context.UnknownPoint.Remove(unknownPoint);
                    }

                    //Suppression des descriptions
                    foreach(var description in user.Description.ToList()){

                        //Suppression des votes de description
                        foreach(var voteDescription in description.VoteDescription.ToList()){
                                Context.VoteDescription.Remove(voteDescription);
                        }
                        Context.Description.Remove(description);
                    }

                    //Suppression des votes de point d'intérêt
                    foreach(var voteInterestPoint in user.VoteInterestPoint.ToList()){
                        Context.VoteInterestPoint.Remove(voteInterestPoint);
                    }

                    //Suppression des votes de description
                    foreach(var voteDescription in user.VoteDescription.ToList()){
                        Context.VoteDescription.Remove(voteDescription);
                    }
                            
                    Context.ApplicationUser.Remove(user);
                    Context.SaveChanges();

                    return Ok();
                }

                
            
        }

        // GET api/User/GetAllUsers
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
                List<ApplicationUser> listUser =  Context.ApplicationUser
                        .Include(a=>a.InterestPoint)
                            .ThenInclude(a => a.VoteInterestPoint)
                        .Include(a=>a.InterestPoint)
                            .ThenInclude(a => a.Description)
                                .ThenInclude(a => a.VoteDescription)
                        .Include(a=>a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a =>a.UnknownPoint)
                        .ToList();
                
                return Ok(listUser);  
            
        }
    }
}
