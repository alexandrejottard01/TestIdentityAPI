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
    [Route("api/VoteInterestPoint")]
    public class VoteInterestPointController : BaseController
    {

        public VoteInterestPointController(UserManager<ApplicationUser> uMgr, MoveAndSeeDatabaseTestContext context) : base(uMgr, context)
        {
        }
        //AddVoteInterestPoint OK
        //GetAllVotesInterestPointByInterestPoint OK

        //POST api/VoteInterestPoint/AddVoteInterestPoint OK
        [HttpPost("AddVoteInterestPoint")]
        public IActionResult AddVoteInterestPoint([FromBody]VoteInterestPoint voteInterestPoint)
        {
            

                if(ModelState.IsValid){
                    Context.VoteInterestPoint.Add(voteInterestPoint);
                    Context.SaveChanges();

                    return Ok();
                }
                else{
                    return BadRequest();
                }
            
        }

        // GET api/VoteInterestPoint/GetAllVotesInterestPointByInterestPoint/5 OK
        [HttpGet("GetAllVotesInterestPointByInterestPoint/{idInterestPoint}")]
        public IActionResult GetAllVotesInterestPointByInterestPoint(int idInterestPoint) 
        {
            

                List<VoteInterestPoint> listVoteInterestPoint = Context.VoteInterestPoint
                        .Where(a => a.IdInterestPoint == idInterestPoint)
                        .Include(a=>a.IdInterestPointNavigation)
                        .Include(a=>a.IdUserNavigation)
                        .ToList();

                return Ok(listVoteInterestPoint);
            
        }
    }
}
