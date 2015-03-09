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
    public class XamarinAmbassadorsController : Controller
    {
        private AmbassadorContext db = new AmbassadorContext();

        // GET: XamarinAmbassadors
        public async Task<ActionResult> Index()
        {
            var xamarinAmbassadors = db.XamarinAmbassadors.Include(x => x.University);
            return View(await xamarinAmbassadors.ToListAsync());
        }

        // GET: XamarinAmbassadors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambassador xamarinAmbassador = await db.XamarinAmbassadors.FindAsync(id);
            if (xamarinAmbassador == null)
            {
                return HttpNotFound();
            }
            return View(xamarinAmbassador);
        }

        // GET: XamarinAmbassadors/Create
        public ActionResult Create()
        {
            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name");
            return View();
        }

        // POST: XamarinAmbassadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,MiddleName,LastName,City,StateRegion,Country,ContactEmail,TwitterHandle,FacebookName,LinkedInName,Blog,IsCertified,PhotoUri,EventPage,Biography,GpsCoordinates,UniversityId")] Ambassador xamarinAmbassador)
        {
            if (ModelState.IsValid)
            {
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].ContentLength == 0) continue;
                    string pathToSave = Server.MapPath("~/Content/Assets/");
                    string filename = String.Format("{0}_{1}{2}", xamarinAmbassador.FirstName.Trim(), xamarinAmbassador.FacebookName, Path.GetExtension(Request.Files[upload].FileName));
                    Request.Files[upload].SaveAs(Path.Combine(pathToSave, filename));
                    xamarinAmbassador.PhotoUri = String.Format("/Content/Assets/{0}",filename);
                }
                
                db.XamarinAmbassadors.Add(xamarinAmbassador);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", xamarinAmbassador.UniversityId);
            return View(xamarinAmbassador);
        }

        // GET: XamarinAmbassadors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambassador xamarinAmbassador = await db.XamarinAmbassadors.FindAsync(id);
            if (xamarinAmbassador == null)
            {
                return HttpNotFound();
            }
            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", xamarinAmbassador.UniversityId);
            return View(xamarinAmbassador);
        }

        // POST: XamarinAmbassadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,City,StateRegion,Country,ContactEmail,TwitterHandle,FacebookName,LinkedInName,Blog,IsCertified,PhotoUri,EventPage,Biography,GpsCoordinates,UniversityId")] Ambassador xamarinAmbassador)
        {
            if (ModelState.IsValid)
            {
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].ContentLength == 0) continue;
                    string pathToSave = Server.MapPath("~/Content/Assets/");
                    string filename = String.Format("{0}_{1}{2}", xamarinAmbassador.FirstName.Trim(), xamarinAmbassador.FacebookName, Path.GetExtension(Request.Files[upload].FileName));
                    Request.Files[upload].SaveAs(Path.Combine(pathToSave, filename));
                    xamarinAmbassador.PhotoUri = String.Format("/Content/Assets/{0}", filename);
                }

                db.Entry(xamarinAmbassador).State = EntityState.Modified;
                if (String.IsNullOrEmpty(xamarinAmbassador.PhotoUri))
                    db.Entry(xamarinAmbassador).Property("PhotoUri").IsModified = false;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", xamarinAmbassador.UniversityId);
            return View(xamarinAmbassador);
        }

        // GET: XamarinAmbassadors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambassador xamarinAmbassador = await db.XamarinAmbassadors.FindAsync(id);
            if (xamarinAmbassador == null)
            {
                return HttpNotFound();
            }
            return View(xamarinAmbassador);
        }

        // POST: XamarinAmbassadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ambassador xamarinAmbassador = await db.XamarinAmbassadors.FindAsync(id);
            db.XamarinAmbassadors.Remove(xamarinAmbassador);

            string path = Server.MapPath("~" + xamarinAmbassador.PhotoUri);
            if (System.IO.File.Exists(path))
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
