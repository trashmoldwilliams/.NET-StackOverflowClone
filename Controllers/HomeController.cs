using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StackOverflow.Models;
using Microsoft.Data.Entity;


namespace StackOverflow.Controllers
{
  

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IActionResult Index()
        {

            return View(db.Questions.ToList());
        }

        public IActionResult Details(int id)
        {
            //Question Deets = db.Questions.FirstOrDefault(x => x.Id == id).Include(question => question.Answers);

            var Deets = db.Questions.Where(x => x.Id == id).Include(question => question.Answers);

            return View(Deets);
        }
    }
}
