using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Treasury.Models;
using Treasury.Data;
using Treasury.Business.Models;
using Treasury.Business.Logic;

namespace Treasury.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTransaction(double amount, string description)
        {
            TransactionModel model = new TransactionModel { Amount = amount, Description = description };

            TransactionService service = new TransactionService();

            service.AddTransaction(model);

            return null;
        }

        [HttpPost]
        public ActionResult AddVendor(string vendorName)
        {

            VendorService service = new VendorService();

            service.AddVendor(vendorName);

            return null;
        }

        [HttpPost]
        public ActionResult AddBudget()
        {
            return null;
        }

        public IActionResult Transactions()
        {
            ViewData["Message"] = "This will be where all of the transactions are added, viewed and modified";

            return View();
        }

        public IActionResult Vendors()
        {
            ViewData["Message"] = "Add in the people who take my money";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Budget()
        {
            ViewData["Message"] = "Set up them budgets here";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
