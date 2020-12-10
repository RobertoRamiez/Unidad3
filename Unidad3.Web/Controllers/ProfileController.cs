using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unidad3.Web.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace Unidad3.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Profile
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult Details(ProfilesViewModel pvm)
        {
            var userId = User.Identity.GetUserId();
            var userbd = db.Users.Find(userId);

            userbd.Name = pvm.Name;
            userbd.PhoneNumber = pvm.PhoneNumber;
            userbd.Picture = pvm.Picture;
            userbd.Videos = pvm.Videos;
            userbd.Hobbies = pvm.Hobbies;
            userbd.Description = pvm.Description;
            db.SaveChanges();

            return RedirectToAction("Details");
        }

        [HttpPost]
        public ActionResult Picture(HttpPostedFileBase pic)
        {
            string path = Server.MapPath("~/Update/");
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var userId = User.Identity.GetUserId();
            var userdb = db.Users.Find(userId);
            var picture = pic.FileName;
            var dir = "";
            if (pic!=null)
            {
                dir = User.Identity.Name + Path.GetExtension(picture);
                pic.SaveAs(path + dir);
            }
            userdb.Picture = dir;
            db.SaveChanges();
            return RedirectToAction("Details");
        }
    }
}