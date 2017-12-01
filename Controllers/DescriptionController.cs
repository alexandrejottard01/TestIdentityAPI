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
    [Route("api/Description")]
    public class DescriptionController : BaseController
    {
        public DescriptionController(UserManager<ApplicationUser> uMgr, MoveAndSeeDatabaseTestContext context) : base(uMgr, context)
        {
        }
        //AddDescription OK
        //GetDescriptionById OK
        //GetAllDescriptionsByInterestPoint OK
        //GetAllDescriptionsByUser OK
        //DeleteDescriptionById OK
        
        //POST api/Description/AddDescription OK
        [HttpPost("AddDescription")]
        public IActionResult AddDescription([FromBody]Description description)
        {
            

                if(ModelState.IsValid){
                    Context.Description.Add(description);
                    Context.SaveChanges();

                    return Ok();
                }
                else{
                    return BadRequest(ModelState);
                }
            
        }

        // GET api/Description/GetDescriptionById/5 OK
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
                            Average = (desc.VoteDescription.Count() >0 ? (int) (((double)desc.VoteDescription.Count(vdesc=>vdesc.IsPositiveAssessment)/desc.VoteDescription.Count())*100) : -1)})
                        .SingleOrDefault();

                if(descriptionWithVote == null){
                    return NotFound();
                }
                else{
                    return Ok(descriptionWithVote);
                }
            
        }

        // GET api/Description/GetAllDescriptionsByInterestPoint/5 OK
        [HttpGet("GetAllDescriptionsByInterestPoint/{idInterestPoint}")]
        public IActionResult GetAllDescriptionsByInterestPoint(int idInterestPoint) 
        {
            

                InterestPoint interestPoint = Context.InterestPoint
                        .SingleOrDefault(a => a.IdInterestPoint == idInterestPoint);
                if(interestPoint == null){
                    return NotFound();
                }
                else{

                    List<DescriptionWithVote> listDescriptionWithVote = Context.Description
                        .Where(a => a.IdInterestPoint == idInterestPoint)
                        .Include(a=>a.VoteDescription)
                        .Include(a=>a.IdInterestPointNavigation)
                        .Include(a=>a.IdUserNavigation)
                        .Select(desc => new DescriptionWithVote(){
                            Description = desc,
                            Average = (desc.VoteDescription.Count() >0 ? (int) (((double)desc.VoteDescription.Count(vdesc=>vdesc.IsPositiveAssessment)/desc.VoteDescription.Count())*100) : -1)})
                        .ToList();

                        List<DescriptionWithVote> SortedListDescriptionWithVote = listDescriptionWithVote.OrderBy(ip => ip.Average).ToList();

                    return Ok(SortedListDescriptionWithVote); 
                }      
            
        }

        // GET api/Description/GetAllDescriptionsByUser/5 OK
        [HttpGet("GetAllDescriptionsByUser/{idUser}")]
        public IActionResult GetAllDescriptionsByUser(string idUser) 
        {

                ApplicationUser user = Context.ApplicationUser
                        .SingleOrDefault(a => a.Id == idUser);
                if(user == null){
                    return NotFound();
                }
                else{
                    List<DescriptionWithVote> listDescriptionWithVote = Context.Description
                        .Where(a => a.IdUser == idUser)
                        .Include(a=>a.VoteDescription)
                        .Include(a=>a.IdInterestPointNavigation)
                        .Include(a=>a.IdUserNavigation)
                        .Select(desc => new DescriptionWithVote(){
                            Description = desc,
                            Average = (desc.VoteDescription.Count() >0 ? (int) (((double)desc.VoteDescription.Count(vdesc=>vdesc.IsPositiveAssessment)/desc.VoteDescription.Count())*100) : -1)})
                        .ToList();

                        

                    return Ok(listDescriptionWithVote);
                }      

                
            
        }

        //GET api/Description/DeleteDescriptionById/3 OK
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
                else{
                    //Suppression des votes de description
                    foreach(var voteDescription in descriptionDelete.VoteDescription.ToList()){
                        Context.VoteDescription.Remove(voteDescription);
                    }

                    Context.Description.Remove(descriptionDelete);
                    Context.SaveChanges();

                    return Ok();
                }
                
            
        }


        //------------------------------------------------
        //Autres méthodes qu'on pourrait utiliser plus tard
        //------------------------------------------------

        // GET api/Description/GetAllDescriptions OK
        [HttpGet("GetAllDescriptions")]
        public IActionResult GetAllDescriptions()
        {
                List<DescriptionWithVote> listDescriptionWithVote = Context.Description
                        .Include(a => a.VoteDescription)
                        .Include(a=>a.IdInterestPointNavigation)
                        .Include(a=>a.IdUserNavigation)
                        .Select(desc => new DescriptionWithVote(){
                            Description = desc,
                            Average = (desc.VoteDescription.Count() >0 ? (int) (((double)desc.VoteDescription.Count(vdesc=>vdesc.IsPositiveAssessment)/desc.VoteDescription.Count())*100) : -1)})
                        .ToList();

                return Ok(listDescriptionWithVote);
            
        }

        

        

        

        

        

        /*// GET api/Description/GetAllDescriptionsSortedByEvaluation
        [HttpGet("GetAllDescriptionsSortedByEvaluation")]
        public IEnumerable<Description> GetAllDescriptionsSortedByEvaluation()
        {
            using(var context = new MoveAndSeeDatabaseContext()){

                var listDescription = context.Description.ToList();
                
                int nbAssessmentPositive = 0;
                int nbAssessment = 0;

                foreach(var description in listDescription){
                    var listVoteDescription = context.VoteDescription
                                                .Where(a => a.IdDescription == description.IdDescription)
                                                .ToList();
                    foreach(var voteDescription in listVoteDescription){
                        if(voteDescription.IsPositiveAssessment){
                            nbAssessmentPositive ++;
                        }
                        nbAssessment++;

                    }
                    double ratioDescription = nbAssessmentPositive / nbAssessment;

                    var test = context.Description
                                    .Select(a => new{

                                    })


                }
        }*/

        


    }
}
