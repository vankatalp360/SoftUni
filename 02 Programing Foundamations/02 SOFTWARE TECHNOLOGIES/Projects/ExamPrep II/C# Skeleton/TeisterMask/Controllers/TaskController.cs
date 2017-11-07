using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
        [ValidateInput(false)]
	public class TaskController : Controller
	{
	    [HttpGet]
            [Route("")]
	    public ActionResult Index()
	    {
            using (var db = new TeisterMaskDbContext())
            {
                var tasks = db
                    .Tasks
                    .ToList();
                return View(tasks);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
		{
            return View();
        }

		[HttpPost]
		[Route("create")]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Task task)
		{
            if (ModelState.IsValid)
            {
                using (var db = new TeisterMaskDbContext())
                {

                    db.Tasks.Add(task);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(task);
        }

		[HttpGet]
		[Route("edit/{id}")]
        public ActionResult Edit(int? id)
		{
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new TeisterMaskDbContext())
            {
                var task = db
                   .Tasks
                   .Where(a => a.Id == id)
                   .FirstOrDefault();
                if (task == null)
                {
                    return HttpNotFound();
                }
                return View(task);
            }
        }

		[HttpPost]
		[Route("edit/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult EditConfirm(int? id, Task taskModel)
		{
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new TeisterMaskDbContext())
            {
                var task = db
                   .Tasks
                   .Where(a => a.Id == id)
                   .FirstOrDefault();
                if (task == null)
                {
                    return HttpNotFound();
                }

                task.Title = taskModel.Title;
                task.Status = taskModel.Status;

                db.SaveChanges();
                return RedirectToAction("Index");
            }            
        }
	}
}