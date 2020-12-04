using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unidad3.Web.Models;

namespace Unidad3.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RolesController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        public ActionResult AddRoles(string id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult AddRoles(UserViewModels uvm)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var UserRole = UserManager.GetRoles(uvm.UserId);
            if (UserRole.Count>0)
            {
                UserManager.RemoveFromRoles(uvm.UserId, UserRole.ToArray());
                UserManager.AddToRole(uvm.UserId, uvm.RolName);
            }
            else
            {
                UserManager.AddToRole(uvm.UserId, uvm.RolName);
            }

            return RedirectToAction("Index");
        }
    }
}