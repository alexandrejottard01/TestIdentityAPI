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
                    
                    return BadRequest();
                    
                }   
        }

        // GET api/User/GetUserById/5
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
                
                return Ok(user);
                
        }

        // GET api/User/GetUserByPseudo/chronix
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
                
                return Ok(user);
        }

        //GET api/User/DeleteUserById/3
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
                
                deleteInterestPointUser(user);
                deleteUnknownPoint(user);
                deleteDescriptionUser(user);
                deleteVoteInterestPointUser(user);
                deleteVoteDescriptionUser(user);
                Context.ApplicationUser.Remove(user);
                Context.SaveChanges();

                return Ok();
        }

        private void deleteInterestPointUser(ApplicationUser user){
            foreach(InterestPoint interestPoint in user.InterestPoint.ToList()){

                deleteDescriptionInterestPoint(interestPoint);
                deleteVoteInterestPointInterestPoint(interestPoint);
                Context.InterestPoint.Remove(interestPoint);
            }
        }

        private void deleteDescriptionInterestPoint(InterestPoint interestPoint){
            foreach(Description description in interestPoint.Description.ToList()){
                deleteVoteDescriptionDescription(description);
                Context.Description.Remove(description);
            }
        }

        private void deleteVoteDescriptionDescription(Description description){
            foreach(VoteDescription voteDescription in description.VoteDescription.ToList()){
                Context.VoteDescription.Remove(voteDescription);
            }
        }

        private void deleteVoteInterestPointInterestPoint(InterestPoint interestPoint){
            foreach(VoteInterestPoint voteInterestPoint in interestPoint.VoteInterestPoint.ToList()){
                Context.VoteInterestPoint.Remove(voteInterestPoint);
            }
        }

        private void deleteUnknownPoint(ApplicationUser user){
            foreach(UnknownPoint unknownPoint in user.UnknownPoint.ToList()){
                Context.UnknownPoint.Remove(unknownPoint);
            }
        }

        private void deleteDescriptionUser(ApplicationUser user){
            foreach(Description description in user.Description.ToList()){
                deleteVoteDescriptionDescription(description);
                Context.Description.Remove(description);
            }
        }
        

        private void deleteVoteDescriptionUser(ApplicationUser user){
            foreach(VoteDescription voteDescription in user.VoteDescription.ToList()){
                Context.VoteDescription.Remove(voteDescription);
            }
        }

        private void deleteVoteInterestPointUser(ApplicationUser user){
            foreach(VoteInterestPoint voteInterestPoint in user.VoteInterestPoint.ToList()){
                Context.VoteInterestPoint.Remove(voteInterestPoint);
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
