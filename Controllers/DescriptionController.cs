using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Microsoft.EntityFrameworkCore;
using TestIdentityAPI;
using TestIdentityAPI.Controllers;

namespace MoveAndSeeAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize(Roles = "admin, user")]
    [Route("api/Description")]
    public class DescriptionController : BaseController
    {
        public DescriptionController(UserManager<ApplicationUser> uMgr, MoveAndSeeDatabaseTestContext context) : base(uMgr, context)
        {
        }

        //POST api/Description/AddDescription
        [HttpPost("AddDescription")]
        public IActionResult AddDescription([FromBody]Description description)
        {
                if(ModelState.IsValid){
                    Context.Description.Add(description);
                    Context.SaveChanges();

                    return Ok();
                }

                return BadRequest(ModelState);
        }

        // GET api/Description/GetDescriptionById/5
        [HttpGet("GetDescriptionById/{idDescription}")]
        public IActionResult GetDescriptionById(int idDescription)
        {
                DescriptionWithVote descriptionWithVote = Context.Description
                        .Include(a => a.VoteDescription)
                        .Include(a=>a.IdInterestPointNavigation)
                        .Include(a=>a.IdUserNavigation)
                        .Where(a => a.IdDescription == idDescription)
                        .Select(desc => new DescriptionWithVote(){
                            Description = desc,
                            Average = calculateAverage(desc)})
                        .SingleOrDefault();

                if(descriptionWithVote == null){
                    return NotFound();
                }
                
                return Ok(descriptionWithVote);
        }

        private int calculateAverage(Description desc){
            return (desc.VoteDescription.Count() >0 ? (int) (((double)desc.VoteDescription.Count(vdesc=>vdesc.IsPositiveAssessment)/desc.VoteDescription.Count())*100) : -1);
        }

        // GET api/Description/GetAllDescriptionsByInterestPoint/5
        [HttpGet("GetAllDescriptionsByInterestPoint/{idInterestPoint}")]
        public IActionResult GetAllDescriptionsByInterestPoint(int idInterestPoint) 
        {
                InterestPoint interestPoint = Context.InterestPoint
                        .SingleOrDefault(a => a.IdInterestPoint == idInterestPoint);
                if(interestPoint == null){
                    return NotFound();
                }
                
                List<DescriptionWithVote> listDescriptionWithVote = Context.Description
                    .Where(a => a.IdInterestPoint == idInterestPoint)
                    .Include(a=>a.VoteDescription)
                    .Include(a=>a.IdInterestPointNavigation)
                    .Include(a=>a.IdUserNavigation)
                    .Select(desc => new DescriptionWithVote(){
                        Description = desc,
                        Average = calculateAverage(desc)})
                    .ToList()
                    .OrderByDescending(ip => ip.Average)
                   .ToList();

                return Ok(listDescriptionWithVote);
        }

        // GET api/Description/GetAllDescriptionsByUser/5
        [HttpGet("GetAllDescriptionsByUser/{idUser}")]
        public IActionResult GetAllDescriptionsByUser(string idUser) 
        {
                ApplicationUser user = Context.ApplicationUser
                        .SingleOrDefault(a => a.Id == idUser);
                if(user == null){
                    return NotFound();
                }
                   
                List<DescriptionWithVote> listDescriptionWithVote = Context.Description
                    .Where(a => a.IdUser == idUser)
                    .Include(a=>a.VoteDescription)
                    .Include(a=>a.IdInterestPointNavigation)
                    .Include(a=>a.IdUserNavigation)
                    .Select(desc => new DescriptionWithVote(){
                        Description = desc,
                        Average = calculateAverage(desc)})
                    .ToList();
                
                return Ok(listDescriptionWithVote);  
        }

        //GET api/Description/DeleteDescriptionById/3
        [HttpDelete("DeleteDescriptionById/{idDescription}")]
        public IActionResult DeleteDescriptionById(int idDescription)
        {
                Description descriptionDelete = Context.Description
                                .Include(a=>a.VoteDescription)
                                .Include(a=>a.IdInterestPointNavigation)
                                .SingleOrDefault(a => a.IdDescription == idDescription);

                if(descriptionDelete == null){
                    return NotFound();
                }
                
                deleteVoteDescriptionDescription(descriptionDelete);
                Context.Description.Remove(descriptionDelete);
                Context.SaveChanges();

                return Ok();
        }

        private void deleteVoteDescriptionDescription(Description descriptionDelete){
            foreach(VoteDescription voteDescription in descriptionDelete.VoteDescription.ToList()){
                Context.VoteDescription.Remove(voteDescription);
            }
        }



        // GET api/Description/GetAllDescriptions
        //[Authorize(Roles = "admin")]
        [HttpGet("GetAllDescriptions")]
        public IActionResult GetAllDescriptions()
        {
                List<DescriptionWithVote> listDescriptionWithVote = Context.Description
                        .Include(a => a.VoteDescription)
                        .Include(a=>a.IdInterestPointNavigation)
                        .Include(a=>a.IdUserNavigation)
                        .Select(desc => new DescriptionWithVote(){
                            Description = desc,
                            Average = calculateAverage(desc)})
                        .ToList();

                return Ok(listDescriptionWithVote);
        }
    }
}
