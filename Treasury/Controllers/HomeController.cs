using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Treasury.Models;
using Treasury.Data;

namespace Treasury.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                try
                {
                    db.Vendors.Add(new Data.Models.Vendor { Name = "Skyline Gourmet Deli" });
                    db.Transactions.Add(new Data.Models.Transaction { Amount = 1490.48, Description = "Paycheck", TransactionDate = DateTime.UtcNow });
                    db.SaveChanges();
                }
                catch
                {

                }

            }
            return View();
        }

        public IActionResult Transactions()
        {
            ViewData["Message"] = "This will be where all of the transactions are added, viewed and modified";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
