using System;
using System.Collections.Generic;
using System.Linq;
using Treasury.Data;
using Treasury.Data.Models;

namespace Treasury.Business.Logic
{
    public class BudgetService
    {
        public BudgetService()
        {
        }
        public IEnumerable<Coffer> GetCoffers()
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                return db.Coffers.Select(x => x).ToList();
            }
        }

        public void ResetFunding()
        {
            CofferService cofferService = new CofferService();
            AccountService accountService = new AccountService();
            cofferService.ResetFunding();
            double balance = accountService.GetAccounts().Where(x => x.Type == AccountTypes.Cash || x.Type == AccountTypes.Checking || x.Type == AccountTypes.Credit).Sum(x => x.Balance);
            if (balance > 0)
            {
                UpdateCoffers(balance);
            }


        }


        public void UpdateCoffers(double amount)
        {
            IEnumerable<Coffer> coffers = GetCoffersForFunding(DateTime.Now.Month);
            double fundingLeft = amount;
            foreach (Coffer coffer in coffers)
            {
                double cofferBalance = coffer.Amount - coffer.AmountFunded;

                if (cofferBalance <= fundingLeft)
                {
                    SetAmountFunded(coffer.Id, coffer.Amount);
                    fundingLeft = Math.Round(fundingLeft - cofferBalance, 2);

                }
                else
                {
                    double fundAmount = coffer.AmountFunded + fundingLeft;
                    SetAmountFunded(coffer.Id, fundAmount);
                    break;
                }
            }
        }

        public IEnumerable<Coffer> GetCoffersForFunding(int month)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                List<Coffer> cofferList = new List<Coffer>();
                cofferList.AddRange(db.Coffers.Where(x => x.AmountFunded < x.Amount && x.Month >= month && x.Month < month + 4 && x.Necessary).Select(x => x).OrderBy(x => x.Month).ThenBy(x => x.Order));
                cofferList.AddRange(db.Coffers.Where(x => x.AmountFunded < x.Amount && x.Month >= month && x.Month < month + 4 && !x.Necessary).Select(x => x).OrderBy(x => x.Month).ThenBy(x => x.Order));
                return cofferList;
            }
        }

        public IEnumerable<Expense> GetExpenses()
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                return db.Expenses.Select(x => x).ToList();
            }
        }

        public void AddExpense(string name, string description)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                db.Expenses.Add(new Data.Models.Expense { Name = name, Description = description });
                db.SaveChanges();
            }
        }

        public void SetUpBudgets(decimal amount, string name, int order, bool necessary, string type, string month, int expenseId, string description)
        {
            try
            {
                using (TreasuryContext db = new TreasuryContext())
                {
                    db.Budgets.Add(new Data.Models.Budget { Amount = double.Parse(amount.ToString()), Month = GetMonth(GetMonthInt(month)), Name = name, Order = order, ExpenseId = expenseId, Description = description, Necessary = necessary });
                    db.SaveChanges();
                    var budgetId = db.Budgets.Where(x => x.ExpenseId == expenseId && x.Name == name).FirstOrDefault().Id;
                    SetUpMonthlyCoffers(amount, name, order, type, month, budgetId, necessary);
                }
            }
            catch
            {

            }
        }

        public void SetUpMonthlyCoffers(decimal amount, string name, int order, string type, string month, int budgetId, bool necessary)
        {
            if (type == "Monthly")
            {
                int currentMonth = DateTime.Now.Month;
                for (int i = currentMonth; i <= 12; i++)
                {
                    AddCoffer(amount, i, name, order, budgetId, necessary);
                }
            }
            else
            {
                if (type == "One Time")
                {
                    int currentMonth = DateTime.Now.Month;
                    int expenseMonth = GetMonthInt(month);
                    int monthsToPay = expenseMonth - currentMonth;
                    if (monthsToPay == 0)
                    {
                        monthsToPay = 1;
                    }
                    decimal monthlyAmount = amount / monthsToPay;

                    for (int i = currentMonth; i <= expenseMonth; i++)
                    {
                        AddCoffer(Math.Round(monthlyAmount, 2), i, name, order, budgetId, necessary);
                    }
                }
                else
                {
                    int currentMonth = DateTime.Now.Month;
                    int monthsToPay = 12 - currentMonth;
                    decimal monthlyAmount = amount / monthsToPay;

                    for (int i = currentMonth; i <= 12; i++)
                    {
                        AddCoffer(Math.Round(monthlyAmount, 2), i, name, order, budgetId, necessary);
                    }

                }
            }
        }

        public void AddCoffer(decimal amount, int month, string name, int order, int budgetId, bool necessary)
        {
            try
            {
                using (TreasuryContext db = new TreasuryContext())
                {
                    db.Coffers.Add(new Data.Models.Coffer { Amount = double.Parse(amount.ToString()), Month = month, Name = name, Order = order, BudgetId = budgetId, Necessary = necessary });
                    db.SaveChanges();
                }
            }
            catch
            {

            }
        }

        private void SetAmountFunded(int cofferId, double amountFunded)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                var cof = db.Coffers.Where(x => x.Id == cofferId).FirstOrDefault();
                if (cof != null)
                {
                    cof.AmountFunded = amountFunded;
                    db.SaveChanges();
                }

            }
        }

        private Month GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return Month.January;
                case 2:
                    return Month.Febuary;
                case 3:
                    return Month.March;
                case 4:
                    return Month.April;
                case 5:
                    return Month.May;
                case 6:
                    return Month.June;
                case 7:
                    return Month.July;
                case 8:
                    return Month.August;
                case 9:
                    return Month.September;
                case 10:
                    return Month.October;
                case 11:
                    return Month.November;
                case 12:
                    return Month.December;
                default:
                    return Month.January;
            }
        }

        private int GetMonthInt(string month)
        {
            switch (month)
            {
                case "January":
                    return 1;
                case "Febuary":
                    return 2;
                case "March":
                    return 3;
                case "April":
                    return 4;
                case "May":
                    return 5;
                case "June":
                    return 6;
                case "July":
                    return 7;
                case "August":
                    return 8;
                case "September":
                    return 9;
                case "October":
                    return 10;
                case "November":
                    return 11;
                case "December":
                    return 12;
                default:
                    return 12;
            }
        }
    }
}
