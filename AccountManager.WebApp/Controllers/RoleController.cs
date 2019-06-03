using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AccountManager.WebApp.Models;

namespace AccountManager.WebApp.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            List<RoleViewModel> roleList=new List<RoleViewModel> ();
            Roles.GetAllRoles().ToList().ForEach(r => {
                roleList.Add(new RoleViewModel() { RoleName = r });
                 });
            
            return View(roleList);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterRoleViewModel role)
        {
            try
            {
                if (!string.IsNullOrEmpty(role.RoleName))
                {
                    Roles.CreateRole(role.RoleName);
                }
                return RedirectToAction("Index", "Role");
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "role name error!");
                return View();
            }
            
        }

    }
}
