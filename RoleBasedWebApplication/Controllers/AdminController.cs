using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using RoleBasedWebApplication.Models;

namespace RoleBasedWebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private EntriesContext db = new EntriesContext();

        // GET: Admin
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var artifacts = db.Artifacts.Include(a => a.ArtifactClass).Include(a => a.ArtifactIcon).Include(a => a.ArtifactImage).Include(a => a.ArtifactType);
            return View(artifacts.OrderBy(a => a.Id).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artifact artifact = db.Artifacts.Find(id);
            if (artifact == null)
            {
                return HttpNotFound();
            }
            return View(artifact);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.ArtifactClassId = new SelectList(db.ArtifactClasses, "Id", "Name");
            ViewBag.ArtifactIconId = new SelectList(db.ArtifactIcons, "Id", "Src");
            ViewBag.ArtifactImageId = new SelectList(db.ArtifactImages, "Id", "Src");
            ViewBag.ArtifactTypeId = new SelectList(db.ArtifactTypes, "Id", "Name");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,OrderWorth,SaleWorth,ArtifactImageId,ArtifactIconId,ArtifactClassId,ArtifactTypeId,Properties")] Artifact artifact)
        {
            if (ModelState.IsValid)
            {
                db.Artifacts.Add(artifact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtifactClassId = new SelectList(db.ArtifactClasses, "Id", "Name", artifact.ArtifactClassId);
            ViewBag.ArtifactIconId = new SelectList(db.ArtifactIcons, "Id", "Src", artifact.ArtifactIconId);
            ViewBag.ArtifactImageId = new SelectList(db.ArtifactImages, "Id", "Src", artifact.ArtifactImageId);
            ViewBag.ArtifactTypeId = new SelectList(db.ArtifactTypes, "Id", "Name", artifact.ArtifactTypeId);
            return View(artifact);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artifact artifact = db.Artifacts.Find(id);
            if (artifact == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtifactClassId = new SelectList(db.ArtifactClasses, "Id", "Name", artifact.ArtifactClassId);
            ViewBag.ArtifactIconId = new SelectList(db.ArtifactIcons, "Id", "Src", artifact.ArtifactIconId);
            ViewBag.ArtifactImageId = new SelectList(db.ArtifactImages, "Id", "Src", artifact.ArtifactImageId);
            ViewBag.ArtifactTypeId = new SelectList(db.ArtifactTypes, "Id", "Name", artifact.ArtifactTypeId);
            return View(artifact);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,OrderWorth,SaleWorth,ArtifactImageId,ArtifactIconId,ArtifactClassId,ArtifactTypeId,Properties")] Artifact artifact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artifact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtifactClassId = new SelectList(db.ArtifactClasses, "Id", "Name", artifact.ArtifactClassId);
            ViewBag.ArtifactIconId = new SelectList(db.ArtifactIcons, "Id", "Src", artifact.ArtifactIconId);
            ViewBag.ArtifactImageId = new SelectList(db.ArtifactImages, "Id", "Src", artifact.ArtifactImageId);
            ViewBag.ArtifactTypeId = new SelectList(db.ArtifactTypes, "Id", "Name", artifact.ArtifactTypeId);
            return View(artifact);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artifact artifact = db.Artifacts.Find(id);
            if (artifact == null)
            {
                return HttpNotFound();
            }
            return View(artifact);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artifact artifact = db.Artifacts.Find(id);
            db.Artifacts.Remove(artifact);
            db.SaveChanges();
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

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddAdmin(RegisterViewModel model)
        {
            var context = new ApplicationDbContext();
            var store = new UserStore<CustomUser>(context);
            var manager = new UserManager<CustomUser>(store);
            var signInManager = new SignInManager<CustomUser, string>(manager, HttpContext.GetOwinContext().Authentication);
            var roles = ApplicationRoleManager.Create(HttpContext.GetOwinContext());

            if (!await roles.RoleExistsAsync(SecurityRoles.Admin))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.Admin });
            }

            if (ModelState.IsValid)
            {
                var user = new CustomUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Login = model.Login
                };

                await manager.CreateAsync(user, model.Password);
                await manager.AddToRoleAsync(user.Id, SecurityRoles.Admin);
                return RedirectToAction("Index", "Admin");
            }

            return View(model);
        }
    }
}
