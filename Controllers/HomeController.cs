using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;


namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext _context;

        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()  // returns new review form
        {
            ViewData["Message"] = "Add a review page.";
            // List<User> AllUsers = _context.Users.ToList();            
            return View();
        }

        [HttpPost("reviews")] 
        public IActionResult ValidateForm(Review review)  // form method to write a new review
        {
            // When creating a new review, render a view with errors if the submission is invalid,
            if(ModelState.IsValid != true)
            {
                // ModelState.AddModelError("review", "Review cannot be blank!");
                return View("Index", review);
            }

            // process the form...   
            _context.Reviews.Add(review);  // adding passed in review object to db
            _context.SaveChanges();        // saving changes to db 
               
            // redirect to the page displaying all quotes if the submission is valid                               
            return Redirect("reviews");
        }

        [HttpGet("reviews")]
        public IActionResult DisplayReviews()  // method to display all reviews
        {
            // order the reviews in DESC order. 
            ViewData["Message"] = "All reviews display page.";
            List<Review> allReviews = _context.Reviews.ToList();
            return View(allReviews);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
