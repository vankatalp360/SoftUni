using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new IMDBDbContext())
            {
                var films = db
                    .Films
                    .ToList();
                return View(films);
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
        public ActionResult Create(Film film)
        {

            if (ModelState.IsValid)
            {
                using (var db = new IMDBDbContext())
                {

                    db.Films.Add(film);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(film);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new IMDBDbContext())
            {
                var film = db
                   .Films
                   .Where(a => a.Id == id)
                   .FirstOrDefault();
                if (film == null)
                {
                    return HttpNotFound();
                }
                return View(film);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new IMDBDbContext())
            {
                var film = db
                   .Films
                   .Where(a => a.Id == id)
                   .FirstOrDefault();
                if (film == null)
                {
                    return HttpNotFound();
                }

                film.Name = filmModel.Name;
                film.Genre = filmModel.Genre;
                film.Director = filmModel.Director;
                film.Year = filmModel.Year;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new IMDBDbContext())
            {
                var film = db
                   .Films
                   .Where(a => a.Id == id)
                   .FirstOrDefault();
                if (film == null)
                {
                    return HttpNotFound();
                }
                return View(film);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new IMDBDbContext())
            {
                var film = db
                   .Films
                   .Where(a => a.Id == id)
                   .FirstOrDefault();
                if (film == null)
                {
                    return HttpNotFound();
                }

                db.Films.Remove(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}