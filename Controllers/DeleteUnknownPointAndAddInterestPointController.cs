using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Microsoft.EntityFrameworkCore;
using TestIdentityAPI;
using TestIdentityAPI.Controllers;

namespace MoveAndSeeAPI.Controllers
{
    [Route("api/DeleteUnknownPointAndInterestPoint")]
    public class DeleteUnknownPointAndInterestPointController : BaseController
    {
        public DeleteUnknownPointAndInterestPointController(UserManager<ApplicationUser> uMgr, MoveAndSeeDatabaseTestContext context) : base(uMgr, context)
        {
        }
        //POST api/DeleteUnknownPointAndInterestPoint/DeleteUnknownPointAndInterestPoint
        [HttpPost("DeleteUnknownPointAndInterestPoint/{idUnknownPoint}")]
        public IActionResult DeleteUnknownPointAndInterestPoint([FromBody]Description description, long idUnknownPoint)
        {
            

                UnknownPoint unknownPointDelete = Context.UnknownPoint
                                .SingleOrDefault(a => a.IdUnknownPoint == idUnknownPoint);

                if(unknownPointDelete == null){
                    return NotFound();
                }
                else{
                    Context.UnknownPoint.Remove(unknownPointDelete);

                    if(ModelState.IsValid){
                        Context.Description.Add(description);
                        Context.SaveChanges();

                        return Ok();
                    }
                    else{
                        return BadRequest();
                    }
                }
            
        }
    }
}
