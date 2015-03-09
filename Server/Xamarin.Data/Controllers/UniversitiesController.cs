using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Xamarin.Data.Models;
using System.IO;
using XamarinSA.Locator.Data.Models;

namespace Xamarin.Data.Controllers
{
    [Authorize]
    public class UniversitiesController : Controller
    {
        private AmbassadorContext db = new AmbassadorContext();

        // GET: Universities
        public async Task<ActionResult> Index()
        {
            return View(await db.Universities.ToListAsync());
        }

        // GET: Universities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = await db.Universities.FindAsync(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // GET: Universities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,WebSite,ContactEmail,Logo")] University university)
        {
            if (ModelState.IsValid)
            {
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].ContentLength == 0) continue;
                    string pathToSave = Server.MapPath("~/Content/Assets/");
                    string filename = String.Format("{0}{1}", university.Id, Path.GetExtension(Request.Files[upload].FileName));
                    Request.Files[upload].SaveAs(Path.Combine(pathToSave, filename));
                    university.Logo = String.Format("/Content/Assets/{0}", filename);
                }

                db.Universities.Add(university);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(university);
        }

        // GET: Universities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = await db.Universities.FindAsync(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,WebSite,ContactEmail,Logo")] University university)
        {
            if (ModelState.IsValid)
            {
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].ContentLength == 0) continue;
                    string pathToSave = Server.MapPath("~/Content/Assets/");
                    string filename = String.Format("{0}{1}", university.Id, Path.GetExtension(Request.Files[upload].FileName));
                    Request.Files[upload].SaveAs(Path.Combine(pathToSave, filename));
                    university.Logo = String.Format("/Content/Assets/{0}", filename);
                }

                db.Entry(university).State = EntityState.Modified;
                if (String.IsNullOrEmpty(university.Logo))
                    db.Entry(university).Property("Logo").IsModified = false;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(university);
        }

        // GET: Universities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = await db.Universities.FindAsync(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            University university = await db.Universities.FindAsync(id);
            db.Universities.Remove(university);

            string path = Server.MapPath("~" + university.Logo);
            if(System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
