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
        //AddInterestPoint OK
        //GetInterestPointById OK
        //GetAllInterestPoints OK
        //GetAllInterestPointsByUser OK
        //GetAllInterestPointsSortedByDateCreation OK
        //GetAllInterestPointsSortedByVoteInterestPoint OK
        //DeleteInterestPointById OK

        

        //POST api/InterestPoint/AddInterestPoint OK
        [HttpPost("AddInterestPoint")]
        public IActionResult AddInterestPoint([FromBody]InterestPoint interestPoint)
        {
                if(ModelState.IsValid){
                    Context.InterestPoint.Add(interestPoint);
                    Context.SaveChanges();

                    return Ok();
                }
                else{
                    return BadRequest();
                }
        }
 
        // GET api/InterestPoint/GetInterestPointById/1 OK
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
                            Average = (ip.VoteInterestPoint.Count() >0 ? (int)(((double)ip.VoteInterestPoint.Count(vip=>vip.IsPositiveAssessment)/ip.VoteInterestPoint.Count())*100) : -1)})
                        .SingleOrDefault();

                if(interestPointWithVote == null){
                    return NotFound();
                }
                else{
                    return Ok(interestPointWithVote);
                }
            
        }

        // GET api/InterestPoint/GetAllInterestPoints OK test
        [HttpGet("GetAllInterestPoints")]
        public IActionResult GetAllInterestPoints()
        {

                List<InterestPointWithVote> listInterestPointWithVote = Context.InterestPoint
                        .Include(a => a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a => a.VoteInterestPoint)
                        .Include(a=>a.IdUserNavigation)
                        .Select(ip => new InterestPointWithVote(){ InterestPoint = ip, Average = (ip.VoteInterestPoint.Count() >0 ? (int)(((double) ip.VoteInterestPoint.Count(vip=>vip.IsPositiveAssessment)/ip.VoteInterestPoint.Count())*100) : -1)})
                        .ToList();

                    return Ok(listInterestPointWithVote);

               /*List<InterestPoint> listInterestPoint = context.InterestPoint
                    .Include(a => a.Description)
                        .ThenInclude(a => a.VoteDescription)
                    .Include(a => a.VoteInterestPoint)
                    .ToList();

                    return Ok(listInterestPoint);*/

            
        }

        // GET api/InterestPoint/GetAllInterestPointsByUser/5 OK
        [HttpGet("GetAllInterestPointsByUser/{idUser}")]
        public IActionResult GetAllInterestPointsByUser(string idUser) 
        {

                ApplicationUser user = Context.ApplicationUser
                        .SingleOrDefault(a => a.Id.CompareTo(idUser) == 0);
                if(user == null){
                    return NotFound();
                }
                else{

                    List<InterestPointWithVote> listInterestPointWithVote = Context.InterestPoint
                        .Where(a=>a.IdUser == idUser)
                        .Include(a => a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a => a.VoteInterestPoint)
                        .Include(a=>a.IdUserNavigation)
                        .Select(ip => new InterestPointWithVote(){ InterestPoint = ip, Average = (ip.VoteInterestPoint.Count() >0 ? (int)(((double) ip.VoteInterestPoint.Count(vip=>vip.IsPositiveAssessment)/ip.VoteInterestPoint.Count())*100) : -1)})
                        .ToList();

                    return Ok(listInterestPointWithVote);

                    /*List<InterestPoint> listInterestPoint = context.InterestPoint
                        .Where(a => a.IdUser == idUser)
                        .Include(a => a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a => a.VoteInterestPoint)
                        .ToList();

                    return Ok(listInterestPoint); */
                }
            
        }

        // GET api/InterestPoint/GetAllInterestPointsSortedByDateCreation OK
        [HttpGet("GetAllInterestPointsSortedByDateCreation")]
        public IActionResult GetAllInterestPointsSortedByDateCreation()
        {

                List<InterestPointWithVote> listInterestPointWithVote = Context.InterestPoint
                        .Include(a => a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a => a.VoteInterestPoint)
                        .Include(a=>a.IdUserNavigation)
                        .OrderBy(a => a.DateCreation)
                        .Select(ip => new InterestPointWithVote(){ InterestPoint = ip, Average = (ip.VoteInterestPoint.Count() >0 ? (int)(((double) ip.VoteInterestPoint.Count(vip=>vip.IsPositiveAssessment)/ip.VoteInterestPoint.Count())*100) : -1)})
                        .ToList();

               /* List<InterestPoint> listInterestPoint = context.InterestPoint
                        .OrderBy(a => a.DateCreation)
                        .ToList();
                return Ok(listInterestPoint);*/

                return Ok(listInterestPointWithVote);
            
        }

        // GET api/InterestPoint/GetAllInterestPointSortedByVoteInterestPoint OK
        [HttpGet("GetAllInterestPointSortedByVoteInterestPoint")] 
        public IActionResult GetAllInterestPointByVoteInterest()
        {

                List<InterestPointWithVote> listInterestPointWithVote = Context.InterestPoint
                        .Include(a => a.Description)
                            .ThenInclude(a => a.VoteDescription)
                        .Include(a => a.VoteInterestPoint)
                        .Include(a=>a.IdUserNavigation)
                        .Select(ip => new InterestPointWithVote(){ InterestPoint = ip, Average = (ip.VoteInterestPoint.Count() >0 ? (int)(((double) ip.VoteInterestPoint.Count(vip=>vip.IsPositiveAssessment)/ip.VoteInterestPoint.Count())*100) : -1)})
                        .OrderBy(ip => ip.Average)
                        .ToList();

                return Ok(listInterestPointWithVote);
            
        }

        //GET api/InterestPoint/DeleteInterestPointById/3 OK
        [HttpDelete("DeleteInterestPointById/{idInterestPoint}")]
        public IActionResult DeleteInterestPointById(int idInterestPoint)
        {
                var interestPointDelete = Context.InterestPoint
                                .Where(a => a.IdInterestPoint == idInterestPoint)
                                .Include(a =>a.VoteInterestPoint)
                                .Include(a=>a.Description)
                                    .ThenInclude(a => a.VoteDescription)
                                .SingleOrDefault();

                if(interestPointDelete == null){
                    return NotFound();
                }
                else{
                    //Suppression des votes de point d'intérêt
                    foreach(var voteInterestPoint in interestPointDelete.VoteInterestPoint.ToList()){
                        Context.VoteInterestPoint.Remove(voteInterestPoint);
                    }

                    //Suppression des descriptions
                    foreach(var description in interestPointDelete.Description.ToList()){

                        //Suppression des votes de description
                        foreach(var voteDescription in description.VoteDescription.ToList()){
                                Context.VoteDescription.Remove(voteDescription);
                        }
                        Context.Description.Remove(description);
                    }
                            
                    Context.InterestPoint.Remove(interestPointDelete);
                    Context.SaveChanges();

                    return Ok();
                }
            
        }
    }
}
