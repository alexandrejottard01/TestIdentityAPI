using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/VoteDescription")]
    public class VoteDescriptionController : BaseController
    {
        public VoteDescriptionController(UserManager<ApplicationUser> uMgr, MoveAndSeeDatabaseTestContext context) : base(uMgr, context)
        {
        }
        
        //POST api/VoteDescription/AddVoteDescription
        [HttpPost("AddVoteDescription")]
        public IActionResult AddVoteDescription([FromBody]VoteDescription voteDescription)
        {
                if(ModelState.IsValid){
                    Context.VoteDescription.Add(voteDescription);
                    Context.SaveChanges();

                    return Ok();
                }
                
                return BadRequest();
                
        }

        // GET api/VoteDescription/GetAllVotesDescriptionByDescription/5
        [HttpGet("GetAllVotesDescriptionByDescription/{idDescription}")]
        public IActionResult GetAllVotesDescriptionByDescription(int idDescription) 
        {
                List<VoteDescription> listVoteDescription = Context.VoteDescription
                        .Where(a => a.IdDescription == idDescription)
                        .Include(a=>a.IdDescriptionNavigation)
                        .Include(a=>a.IdUserNavigation)
                        .ToList();

                return Ok(listVoteDescription);
        }
    }
}
