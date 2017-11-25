using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestIdentityAPI;
using TestIdentityAPI.Controllers;

namespace MoveAndSeeAPI.Controllers
{
    [Route("api/UnknownPoint")]
    public class UnknownPointController : BaseController
    {
        public UnknownPointController(UserManager<ApplicationUser> uMgr, MoveAndSeeDatabaseTestContext context) : base(uMgr, context)
        {
        }
        //AddUnknownPoint OK
        //GetUnknwonPointById OK
        //GetAllUnknownPoints OK
        //GetAllUnknownPointsSortedByDateCreation OK
        //DeletUnknownPointById OK


        

        //POST api/UnknownPoint/AddUnknownPoint OK
        [HttpPost("AddUnknownPoint")]
        public IActionResult AddUnknownPoint([FromBody]UnknownPoint unknownPoint)
        {
            

                if(ModelState.IsValid){
                    Context.UnknownPoint.Add(unknownPoint);
                    Context.SaveChanges();

                    return Ok();
                }
                else{
                    return BadRequest();
                }

                
            
        }

        // GET api/UnknownPoint/GetUnknownPointById/5 OK
        [HttpGet("GetUnknownPointById/{idUnknownPoint}")]
        public IActionResult GetUnknownPointById(int idUnknownPoint)
        {


                UnknownPoint unknownPoint = Context.UnknownPoint
                        .Include(a=>a.IdUserNavigation)
                        .SingleOrDefault(a => a.IdUnknownPoint == idUnknownPoint);
                if(unknownPoint == null){
                    return NotFound();
                }
                else{
                    return Ok(unknownPoint); 
                }
            
        }

        // GET api/UnknownPoint/GetAllUnknownPoints OK
        [HttpGet("GetAllUnknownPoints")]
        public IActionResult GetAllUnknownPoints()
        {

                List<UnknownPoint> listUnknownPoint = Context.UnknownPoint
                        .Include(a=>a.IdUserNavigation)
                        .ToList();

                return Ok(listUnknownPoint);
            
        }

        // GET api/UnknownPoint/GetAllUnknownPointsSortedByDateCreation OK
        [HttpGet("GetAllUnknownPointsSortedByDateCreation")]
        public IActionResult GetAllUnknownPointsSortedByDateCreation()
        {
                List<UnknownPoint> listUnknownPoint = Context.UnknownPoint
                        .Include(a=>a.IdUserNavigation) 
                        .OrderBy(a => a.DateCreation)
                        .ToList();

                return Ok(listUnknownPoint);
            
        }

        

        //GET api/UnknownPoint/DeleteUnknownPointById/3 OK
        [HttpDelete("DeleteUnknownPointById/{idUnknownPoint}")]
        public IActionResult DeleteUnknownPointById(int idUnknownPoint)
        {

                UnknownPoint unknownPointDelete = Context.UnknownPoint
                                .SingleOrDefault(a => a.IdUnknownPoint == idUnknownPoint);

                if(unknownPointDelete == null){
                    return NotFound();
                }
                else{
                    Context.UnknownPoint.Remove(unknownPointDelete);
                    Context.SaveChanges();

                    return Ok();
                }
            
        }
    }
}
