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
    [Route("api/UnknownPoint")]
    public class UnknownPointController : BaseController
    {
        public UnknownPointController(UserManager<ApplicationUser> uMgr, MoveAndSeeDatabaseTestContext context) : base(uMgr, context)
        {
        }

        //POST api/UnknownPoint/AddUnknownPoint
        [HttpPost("AddUnknownPoint")]
        public IActionResult AddUnknownPoint([FromBody]UnknownPoint unknownPoint)
        {
                if(ModelState.IsValid){
                    Context.UnknownPoint.Add(unknownPoint);
                    Context.SaveChanges();

                    return Ok();
                }

                return BadRequest();
                
        }

        // GET api/UnknownPoint/GetUnknownPointById/5
        [HttpGet("GetUnknownPointById/{idUnknownPoint}")]
        public IActionResult GetUnknownPointById(int idUnknownPoint)
        {
                UnknownPoint unknownPoint = Context.UnknownPoint
                        .Include(a=>a.IdUserNavigation)
                        .SingleOrDefault(a => a.IdUnknownPoint == idUnknownPoint);
                if(unknownPoint == null){
                    return NotFound();
                }

                return Ok(unknownPoint);
        }

        // GET api/UnknownPoint/GetAllUnknownPoints
        [HttpGet("GetAllUnknownPoints")]
        public IActionResult GetAllUnknownPoints()
        {
                List<UnknownPoint> listUnknownPoint = Context.UnknownPoint
                        .Include(a=>a.IdUserNavigation)
                        .ToList();

                return Ok(listUnknownPoint);
        }

        // GET api/UnknownPoint/GetAllUnknownPointsSortedByDateCreation
        [HttpGet("GetAllUnknownPointsSortedByDateCreation")]
        public IActionResult GetAllUnknownPointsSortedByDateCreation()
        {
                List<UnknownPoint> listUnknownPoint = Context.UnknownPoint
                        .Include(a=>a.IdUserNavigation) 
                        .OrderBy(a => a.DateCreation)
                        .ToList();

                return Ok(listUnknownPoint);
        }

        //GET api/UnknownPoint/DeleteUnknownPointById/3
        [HttpDelete("DeleteUnknownPointById/{idUnknownPoint}")]
        public IActionResult DeleteUnknownPointById(int idUnknownPoint)
        {
                UnknownPoint unknownPointDelete = Context.UnknownPoint
                                .SingleOrDefault(a => a.IdUnknownPoint == idUnknownPoint);

                if(unknownPointDelete == null){
                    return NotFound();
                }
                 
                Context.UnknownPoint.Remove(unknownPointDelete);
                Context.SaveChanges();

                return Ok();
                
        }
    }
}
