using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using StackOverflow.Models;
using System;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=39786
namespace StackOverflow.Controllers
{

    [Authorize]

    public class AnswerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnswerController(
          UserManager<ApplicationUser> userManager,
          ApplicationDbContext db
          )
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        //public IActionResult Create(int id)
        //{
        //    var Deets = db.Answers.FirstOrDefault(x => x.QuestionId == id);
        //    return View(Deets);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(Answer answer)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            answer.User = currentUser;
            _db.Answers.Add(answer);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
