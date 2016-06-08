using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;
using RoleBasedWebApplication.Models;

namespace RoleBasedWebApplication.Controllers
{
    [Authorize(Roles = "user")]
    public class PageController : Controller
    {
        private EntriesContext db = new EntriesContext();

        // GET: Page
        public ActionResult CharacterList(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            string currentUserId = User.Identity.GetUserId();
            var characterList = db.Characters.Where(c => c.UserId == currentUserId);
            return View(characterList.OrderBy(c => c.Id).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Store()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Buying(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var artifacts = db.Artifacts;
            return View(artifacts.OrderBy(a => a.Id).ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Buying(Buying model, int id)
        {
            if (ModelState.IsValid)
            {
                var newBuying = new Buying
                {
                    ArtifactId = model.ArtifactId,
                    DateTime = DateTime.Now,
                    UserId = model.UserId
                };
                var currentUser = model.UserId;

                var currentCharacter = db.Characters.FirstOrDefault(c => c.UserId == currentUser && c.Id == id);

                var artifactOrder = db.Artifacts.FirstOrDefault(a => a.Id == model.ArtifactId);
                

                if (currentCharacter.GoldDime < artifactOrder.OrderWorth)
                {
                    return Content("У вас недостаточно золотых монет для покупки этого артифакта");
                }
                currentCharacter.GoldDime -= artifactOrder.OrderWorth;
                db.Characters.AddOrUpdate(currentCharacter);
                db.Buyings.Add(newBuying);
                db.SaveChanges();
                return RedirectToAction("CharacterList", "Page");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Selling(int id, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var currentUser = User.Identity.GetUserId();
            var buyingArtifacts = db.Buyings.Where(a => a.UserId == currentUser);
            var characterName = db.Characters.Where(c => c.Id == id).ToArray();
            ViewBag.CharacterName = characterName[0].Name;
            return View(buyingArtifacts.OrderBy(a => a.Id).ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Selling(Buying model)
        {
            if (ModelState.IsValid)
            {
                var newSelling = new Selling
                {
                    ArtifactId = model.ArtifactId,
                    DateTime = DateTime.Now,
                    UserId = model.UserId,
                    CharacterId = int.Parse(Request.Form["CharacterId"])
                };
                var saleWorth = int.Parse(Request.Form["SaleWorth"]);
                var characterId = int.Parse(Request.Form["CharacterId"]);
                var currentUser = model.UserId;
                
                var currentCharacter = db.Characters.Where(c => c.UserId == currentUser && c.Id == characterId).ToArray();

                currentCharacter[0].GoldDime = currentCharacter[0].GoldDime + saleWorth;
                db.Characters.AddOrUpdate(currentCharacter);

                var selling = db.Buyings.Find(model.Id);

                if (selling != null)
                {
                    db.Buyings.Remove(selling);
                    db.SaveChanges();
                }

                return RedirectToAction("Selling", "Page");
            }
            return View();
        }

        public ActionResult Report()
        {
            var characterBuy = db.Buyings.Where(b => b.UserId.Equals(User.Identity.GetUserId())).ToList();
            return View(characterBuy);
        }

        [HttpGet]
        public ActionResult CreateCharacter()
        {
            ViewBag.CharacterAvatarId = new SelectList(db.CharacterAvatars, "Id", "Avatar");
            ViewBag.CharacterRaseId = new SelectList(db.CharacterRases, "Id", "Name");
            ViewBag.CharacterTypeId = new SelectList(db.CharacterTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult CreateCharacter(Character character)
        {
            if (ModelState.IsValid)
            {
                character.GoldDime = 1000;
                character.UserId = User.Identity.GetUserId();
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("CharacterList");
            }

            ViewBag.CharacterAvatarId = new SelectList(db.CharacterAvatars, "Id", "Avatar", character.CharacterAvatarId);
            ViewBag.CharacterRaseId = new SelectList(db.CharacterRases, "Id", "Name", character.CharacterRaseId);
            ViewBag.CharacterTypeId = new SelectList(db.CharacterTypes, "Id", "Name", character.CharacterTypeId);
            return View(character);
        }

        public ActionResult SelectCharacter(int id)
        {
            var characher = db.Characters.Where(c => c.Id == id).ToList();
            return View(characher);
        }
    }
}