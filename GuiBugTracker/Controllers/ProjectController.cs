using GuiBugTracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuiBugTracker.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext Context;

        public ProjectController()
        {
            Context = new ApplicationDbContext();
        }

        [Authorize(Roles = "Admin,Project Manager")]
        public ActionResult IndexAllProjects()
        {
            var model = Context.Projects
                .Select(p => new ProjectIndexViewModel
                {
                    Name = p.Name,
                    AssignedUsers = p.Users.Count,
                    Tickets = 0,
                    Created = p.DateCreated,
                    Updated = p.DateUpdated
                }).ToList();

            return View("Index");
        }

        [Authorize]
        public ActionResult IndexMyProjects()
        {
            var userId = User.Identity.GetUserId();

            var model = Context
                .Projects
                .Where(p => p.Users.Any(t => t.Id == userId))
                .Select(p => new ProjectIndexViewModel
                {
                    Name = p.Name,
                    AssignedUsers = p.Users.Count,
                    Tickets = 0,
                    Created = p.DateCreated,
                    Updated = p.DateUpdated
                }).ToList();

            return View("Index");
        }
    }
}