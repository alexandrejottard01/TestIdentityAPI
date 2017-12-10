using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestIdentityAPI.DTO;

namespace TestIdentityAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager=userManager;
            this._roleManager=roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewUserDTO dto)
        {
            var newUser=new ApplicationUser{
                UserName=dto.UserName,
                        Email = dto.Email,
                        IsCertified = dto.IsCertified,
                        Language = dto.Language,
                        NameCertified = dto.NameCertified,
                        IsMale = dto.IsMale,
                        BirthDate = dto.BirthDate
                };
                IdentityResult result = await _userManager.CreateAsync(newUser,dto.Password);
                bool userExist = await _roleManager.RoleExistsAsync("user");
                if(!userExist){
                    await _roleManager.CreateAsync(new IdentityRole("user"));
                }

                await _userManager.AddToRoleAsync(newUser,"user");

                // TODO: retourner un Created à la place du Ok;
                return (result.Succeeded)?Ok():(IActionResult)BadRequest();
        }
    }
    //Créer un user sans rôle
    /*public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this._userManager=userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewUserDTO dto)
        {
                var newUser=new ApplicationUser{
                    UserName=dto.UserName,
                    Email = dto.Email,
                    IsCertified = dto.IsCertified,
                    Language = dto.Language,
                    NameCertified = dto.NameCertified,
                    IsMale = dto.IsMale,
                    BirthDate = dto.BirthDate
                        
                };
                IdentityResult result = await _userManager.CreateAsync(newUser,dto.Password);
                // TODO: retourner un Created à la place du Ok;
                return (result.Succeeded)?Ok():(IActionResult)BadRequest();
        }
    }*/

    //Créer un Administrateur
    /* 
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager=userManager;
            this._roleManager=roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewUserDTO dto)
        {
            var newUser=new ApplicationUser{
                UserName=dto.UserName,
                        Email = dto.Email,
                        IsCertified = dto.IsCertified,
                        Language = dto.Language,
                        NameCertified = dto.NameCertified,
                        IsMale = dto.IsMale,
                        BirthDate = dto.BirthDate
                };
                IdentityResult result = await _userManager.CreateAsync(newUser,dto.Password);
                bool adminExist = await _roleManager.RoleExistsAsync("admin");
                if(!adminExist){
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                }

                await _userManager.AddToRoleAsync(newUser,"admin");

                // TODO: retourner un Created à la place du Ok;
                return (result.Succeeded)?Ok():(IActionResult)BadRequest();
        }
    }
    */
}