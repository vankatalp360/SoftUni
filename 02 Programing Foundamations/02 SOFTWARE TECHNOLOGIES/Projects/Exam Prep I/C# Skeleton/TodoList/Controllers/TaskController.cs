using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new TodoListDbContext())
            {
                var articles = db
                    .Tasks
                    .ToList();
                return View(articles);
            }
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                using (var db = new TodoListDbContext())
                {

                    db.Tasks.Add(task);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(task);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new TodoListDbContext())
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
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new TodoListDbContext())
            {
                var task = db
                   .Tasks
                   .Where(a => a.Id == id)
                   .FirstOrDefault();
                if (task == null)
                {
                    return HttpNotFound();
                }

                db.Tasks.Remove(task);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}