using GuiBugTracker.Models;
using System.Linq;
using System.Web.Mvc;

namespace GuiBugTracker.Controllers
{
    public class TicketController : Controller
    {
        private ApplicationDbContext Context { get; set; }

        public TicketController()
        {
            Context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View(new DetailsViewModel()
            {
                Title = "My title"

            });
        }

        [HttpGet]
        public ActionResult Create()
        {
            var statuses = Context.TicketStatuses.ToList();

            var selectListStatuses = 
                new SelectList(statuses, "Id", "Name");

            var model = new CreateTicketViewModel();
            model.AllStatuses = selectListStatuses;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateTicketViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var ticket = new Ticket();
            ticket.TicketStatusId = model.StatusId;
            ticket.Title = model.Title;

            Context.Tickets.Add(ticket);
            Context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ticket = Context
                .Tickets
                .FirstOrDefault(p => p.Id == id);

            var model = new CreateTicketViewModel();
            model.Title = ticket.Title;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateTicketViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var ticket = Context.Tickets.FirstOrDefault(p => p.Id == id);
            ticket.Title = model.Title;

            Context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}