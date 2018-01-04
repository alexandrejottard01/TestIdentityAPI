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
    [Route("api/InterestPoint")]
    public class InterestPointController : BaseController
    {
        public InterestPointController(UserManager<ApplicationUser> uMgr, MoveAndSeeDatabaseTestContext context) : base(uMgr, context)
        {
        }

        //POST api/InterestPoint/AddInterestPoint
        [HttpPost("AddInterestPoint")]
        public IActionResult AddInterestPoint([FromBody]InterestPoint interestPoint)
        {
                if(ModelState.IsValid){
                    Context.InterestPoint.Add(interestPoint);
                    Context.SaveChanges();

                    return Ok();
                }

                return BadRequest();
        }
 
        // GET api/InterestPoint/GetInterestPointById/1
        [HttpGet("GetInterestPointById/{idInterestPoint}")]
        public IActionResult GetInterestPointById(int idInterestPoint)
        {
                InterestPointWithVote interestPointWithVote = Context.InterestPoint
                        .Include(a => a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a => a.VoteInterestPoint)
                        .Include(a=>a.IdUserNavigation)
                        .Where(a => a.IdInterestPoint == idInterestPoint)
                        .Select(ip => new InterestPointWithVote(){
                            InterestPoint = ip,
                            Average = calculateAverage(ip)})
                        .SingleOrDefault();

                if(interestPointWithVote == null){
                    return NotFound();
                }

                return Ok(interestPointWithVote);
        }

        // GET api/InterestPoint/GetAllInterestPoints
        [HttpGet("GetAllInterestPoints")]
        public IActionResult GetAllInterestPoints()
        {
                List<InterestPointWithVote> listInterestPointWithVote = Context.InterestPoint
                        .Include(a => a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a => a.VoteInterestPoint)
                        .Include(a=>a.IdUserNavigation)
                        .Select(ip => new InterestPointWithVote(){ InterestPoint = ip, Average = calculateAverage(ip)})
                        .ToList();

                    return Ok(listInterestPointWithVote);
        }

        // GET api/InterestPoint/GetAllInterestPointsByUser/5
        [HttpGet("GetAllInterestPointsByUser/{idUser}")]
        public IActionResult GetAllInterestPointsByUser(string idUser) 
        {
                ApplicationUser user = Context.ApplicationUser
                        .SingleOrDefault(a => a.Id.CompareTo(idUser) == 0);
                if(user == null){
                    return NotFound();
                }
                
                List<InterestPointWithVote> listInterestPointWithVote = Context.InterestPoint
                    .Where(a=>a.IdUser == idUser)
                    .Include(a => a.Description)
                        .ThenInclude(a => a.VoteDescription)
                    .Include(a => a.VoteInterestPoint)
                    .Include(a=>a.IdUserNavigation)
                    .Select(ip => new InterestPointWithVote(){ InterestPoint = ip, Average = calculateAverage(ip)})
                    .ToList();

                return Ok(listInterestPointWithVote);
        }

        // GET api/InterestPoint/GetAllInterestPointSortedByVoteInterestPoint
        [HttpGet("GetAllInterestPointSortedByVoteInterestPoint")] 
        public IActionResult GetAllInterestPointByVoteInterest()
        {
                List<InterestPointWithVote> listInterestPointWithVote = Context.InterestPoint
                        .Include(a => a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a => a.VoteInterestPoint)
                        .Include(a=>a.IdUserNavigation)
                        .Select(ip => new InterestPointWithVote(){ 
                            InterestPoint = ip, 
                            Average = calculateAverage(ip)})
                        .ToList()
                        .OrderBy(ip => ip.Average)
                        .ToList();
                        
                return Ok(listInterestPointWithVote);
        }

        private int calculateAverage(InterestPoint ip){
            return (ip.VoteInterestPoint.Count() >0 ? (int)(((double) ip.VoteInterestPoint.Count(vip=>vip.IsPositiveAssessment)/ip.VoteInterestPoint.Count())*100) : -1);
        }

        //GET api/InterestPoint/DeleteInterestPointById/3
        [HttpDelete("DeleteInterestPointById/{idInterestPoint}")]
        public IActionResult DeleteInterestPointById(int idInterestPoint)
        {
                InterestPoint interestPointDelete = Context.InterestPoint
                                .Where(a => a.IdInterestPoint == idInterestPoint)
                                .Include(a =>a.VoteInterestPoint)
                                .Include(a=>a.Description)
                                    .ThenInclude(a => a.VoteDescription)
                                .SingleOrDefault();

                if(interestPointDelete == null){
                    return NotFound();
                }
                else{
                    deleteVoteInterestPoint(interestPointDelete);
                    deleteDescriptionInterestPoint(interestPointDelete);
                    Context.InterestPoint.Remove(interestPointDelete);
                    Context.SaveChanges();

                    return Ok();
                }
        }

        private void deleteDescriptionInterestPoint(InterestPoint interestPointDelete){
            foreach(Description description in interestPointDelete.Description.ToList()){

                        //Suppression des votes de description
                        deleteVoteDescriptionDescription(description);
                        Context.Description.Remove(description);
                    }
        }
        private void deleteVoteInterestPoint(InterestPoint interestPointDelete){
            foreach(VoteInterestPoint voteInterestPoint in interestPointDelete.VoteInterestPoint.ToList()){
                Context.VoteInterestPoint.Remove(voteInterestPoint);
            }
        }
        private void deleteVoteDescriptionDescription(Description description){
            foreach(VoteDescription voteDescription in description.VoteDescription.ToList()){
                Context.VoteDescription.Remove(voteDescription);
            }
        }
    }
}
