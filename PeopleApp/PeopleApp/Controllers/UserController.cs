using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeopleApp.Data;
using PeopleApp.Models;

namespace PeopleApp.Controllers
{
    public class UserController : Controller
    {
        UserDB userDB = new UserDB();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //List all user
        public JsonResult List()
        {
            return Json(userDB.GetAllUser(), JsonRequestBehavior.AllowGet);
        }

        //Add User
        public JsonResult AddUser(Users us)
        {
            return Json(userDB.AddUser(us), JsonRequestBehavior.AllowGet);
        }

        //Retrieve by Id
        public JsonResult GetUserById(int id)
        {
            var Users = userDB.RetrieveById(id);
            return Json(User, JsonRequestBehavior.AllowGet);
        }

        //Delete all
        public JsonResult Delete()
        {
            return Json(userDB.DeleteUser(), JsonRequestBehavior.AllowGet);
        }

        //Delete by Id
        public JsonResult DeleteById(int id)
        {
            return Json(userDB.DeleteUserById(id), JsonRequestBehavior.AllowGet);
        }
    }
}