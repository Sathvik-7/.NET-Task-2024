using AssingnmentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssingnmentRegistration.Controllers
{
    public class DepositController : Controller
    {
        // GET: Deposit
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UserData(UserInfo model) 
        {
            BankEntities bank = new BankEntities();
            UserInfo user =bank.UserInfoes.Where(emp => emp.CustomerName == model.CustomerName).FirstOrDefault();
            if (user != null)
            {
                ViewBag.CurrentBalance = Convert.ToString(user.CurrentBalanace);
            }
            else
            {
                ViewBag.CurrentBalance = "";
                ModelState.AddModelError("", "Customer not found.");
            }
            return View("Index",model);
        }
    }
}