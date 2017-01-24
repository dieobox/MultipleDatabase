#region Using

using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using QuickMonServer.Models;
using QuickMonServer.ViewModels.Account;
using System.Collections.Generic;


#endregion

namespace QuickMonServer.Controllers
{
    
    [Route("api/[controller]")]
    [Authorize]
    public class EnrollmentController : Controller
    {

        private readonly ILogger _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public EnrollmentController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpGet("")]
        public IEnumerable<Note> List(string username)
        {
            var name = HttpContext.User.Identity.Name;
            return new List<Note>{
                new Note{Title = "Shopping list", Contents="Some Apples"},
                new Note{Title = "Thoughts on .NET Core", Contents="To follow..."}
             };
        }


        //[HttpPost]
        //public IActionResult Create([FromBody]CompInfo Info)
        //{
        //    return Json(new { status="ok" });

        //}

        public class Note
        {
            public string Title { get; set; }
            public string Contents { get; set; }
        }


    }
}