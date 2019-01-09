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
using Treasury.Data.Models;

namespace Treasury.Controllers
{
    public class HomeController : Controller
    {
        #region Transactions

        public IActionResult Transactions()
        {
            ViewData["Message"] = "This will be where all of the transactions are added, viewed and modified";
            Models.TransactionModel model = new Models.TransactionModel();
            VendorService vendorService = new VendorService();
            model.Vendors = vendorService.GetVendors();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddTransaction(double amount, string description, int vendorId)
        {
            Business.Models.TransactionModel model = new Business.Models.TransactionModel { Amount = amount, Description = description, VendorId = vendorId };

            TransactionService service = new TransactionService();

            service.AddTransaction(model);

            return null;
        }

        #endregion

        #region Vendors
        public IActionResult Vendors()
        {
            ViewData["Message"] = "Add in the people who take my money";

            return View();
        }

        [HttpPost]
        public ActionResult AddVendor(string vendorName)
        {

            VendorService service = new VendorService();

            service.AddVendor(vendorName);

            return null;
        }
        #endregion

        #region Budget
        public IActionResult Budget()
        {
            BudgetService budgetService = new BudgetService();
            ViewData["Message"] = "Set up the budget";
            BudgetModel model = new BudgetModel();

            model.Expenses = budgetService.GetExpenses();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddBudget(string name, decimal amount, int order, bool necessary, string type, string month, int expenseId, string description)
        {
            BudgetService budgetService = new BudgetService();
            budgetService.SetUpBudgets(amount, name, order, necessary, type, month, expenseId, description);

            return null;
        }
        #endregion

        #region Expense
        public IActionResult Expense()
        {
            ViewData["Message"] = "Set up the expenses here";
            ExpenseModel model = new ExpenseModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddExpense(string name, string description)
        {

            BudgetService budgetService = new BudgetService();
            budgetService.AddExpense(name, description);
            return null;
        }
        #endregion

        #region Account
        public IActionResult Account()
        {
            ViewData["Message"] = "Add Bank accounts.";
            AccountModel model = new AccountModel();

            List<AccountTypes> types = new List<AccountTypes>();
            types.Add(AccountTypes.Investment);
            types.Add(AccountTypes.Checking);
            types.Add(AccountTypes.Credit);
            types.Add(AccountTypes.Savings);
            types.Add(AccountTypes.Cash);
            model.AccountTypes = types;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAccount(string name, double balance, string type)
        {
            AccountService accountService = new AccountService();
            accountService.AddAccount(name, type, balance);
            return null;
        }

        #endregion

        #region Income
        public IActionResult Income()
        {
            ViewData["Message"] = "Add the moneys";
            IncomeModel model = new IncomeModel();
            AccountService accountService = new AccountService();

            model.Accounts = accountService.GetAccounts();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddIncome(double amount, string description, int accountId, string source)
        {
            TransactionService transactionService = new TransactionService();
            BudgetService budgetService = new BudgetService();
            transactionService.AddIncome(amount, description, source, accountId);
            IEnumerable<Coffer> coffers = budgetService.GetCoffersForFunding(DateTime.Now.Month);
            double fundingLeft = amount;
            foreach (Coffer coffer in coffers)
            {
                double cofferBalance = coffer.Amount - coffer.AmountFunded;

                if (cofferBalance <= fundingLeft)
                {
                    budgetService.UpdateCofferFunding(coffer.Id, coffer.Amount);
                    fundingLeft = Math.Round(fundingLeft - cofferBalance, 2);

                }
                else
                {
                    double fundAmount = coffer.AmountFunded + fundingLeft;
                    budgetService.UpdateCofferFunding(coffer.Id, fundAmount);
                    break;
                }

            }
            return null;
        }
        #endregion
        public IActionResult Index()
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
