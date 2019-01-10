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
        AccountService accountService = new AccountService();
        BudgetService budgetService = new BudgetService();
        TransactionService transactionService = new TransactionService();
        VendorService vendorService = new VendorService();
        CofferService cofferService = new CofferService();
        #region Transactions

        public IActionResult Transactions()
        {
            ViewData["Message"] = "This will be where all of the transactions are added, viewed and modified";
            Models.TransactionModel model = new Models.TransactionModel();


            model.Vendors = vendorService.GetVendors();
            model.Coffers = cofferService.GetMonthlyCoffers(DateTime.UtcNow.Month);
            model.Accounts = accountService.GetAccountsForTransactions();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddTransaction(double amount, string description, int vendorId, int cofferId, int accountId)
        {
            Business.Models.TransactionModel model = new Business.Models.TransactionModel { Amount = amount, Description = description, VendorId = vendorId, CofferId = cofferId, AccountId = accountId };

            transactionService.AddTransaction(model);
            transactionService.ApplySpendingToCoffer(model.CofferId, model.Amount);
            accountService.UpdateAccountBalance(model.AccountId, model.Amount);

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
            vendorService.AddVendor(vendorName);

            return null;
        }
        #endregion

        #region Budget
        public IActionResult Budget()
        {

            ViewData["Message"] = "Set up the budget";
            BudgetModel model = new BudgetModel();

            model.Expenses = budgetService.GetExpenses();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddBudget(string name, decimal amount, int order, bool necessary, string type, string month, int expenseId, string description)
        {
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

            accountService.AddAccount(name, type, balance);
            return null;
        }

        public ActionResult ResetFunding()
        {
            budgetService.ResetFunding();
            return null;
        }

        #endregion

        #region Income
        public IActionResult Income()
        {
            ViewData["Message"] = "Add the moneys";
            IncomeModel model = new IncomeModel();

            model.Accounts = accountService.GetAccounts();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddIncome(double amount, string description, int accountId, string source)
        {
            transactionService.AddIncome(amount, description, source, accountId);
            budgetService.UpdateCoffers(amount);
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
