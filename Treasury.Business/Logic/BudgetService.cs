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
        public IEnumerable<MonthlyCoffer> GetCoffers()
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                return db.MonthlyCoffers.Select(x => x).ToList();
            }
        }

        public IEnumerable<Budget> GetBudgets()
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                return db.Budgets.Select(x => x).ToList();
            }
        }
        public void AddBudget(string name, string description)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                db.Budgets.Add(new Data.Models.Budget { Name = name, Description = description });
                db.SaveChanges();
            }
        }
        public void SetUpCoffers(decimal amount, string name, int order, bool necessary, string type, string month, int budgetId, string description)
        {
            try
            {
                using (TreasuryContext db = new TreasuryContext())
                {
                    db.Coffers.Add(new Data.Models.Coffer { Amount = double.Parse(amount.ToString()), Month = GetMonth(GetMonthInt(month)), Name = name, Order = order, BudgetId = budgetId, Description = description, Necessary = necessary });
                    db.SaveChanges();
                    var cofferId = db.Coffers.Where(x => x.BudgetId == budgetId && x.Name == name).FirstOrDefault().Id;
                    SetUpMonthlyCoffers(amount, name, order, type, month, cofferId);
                }
            }
            catch
            {

            }
        }

        public void SetUpMonthlyCoffers(decimal amount, string name, int order, string type, string month, int cofferId)
        {
            if (type == "Monthly")
            {
                int currentMonth = DateTime.Now.Month;
                for (int i = currentMonth; i <= 12; i++)
                {
                    AddMonthlyCoffer(amount, i, name, order, cofferId);
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
                        AddMonthlyCoffer(Math.Round(monthlyAmount, 2), i, name, order, cofferId);
                    }
                }
                else
                {
                    int currentMonth = DateTime.Now.Month;
                    int monthsToPay = 12 - currentMonth;
                    decimal monthlyAmount = amount / monthsToPay;

                    for (int i = currentMonth; i <= 12; i++)
                    {
                        AddMonthlyCoffer(Math.Round(monthlyAmount, 2), i, name, order, cofferId);
                    }

                }
            }
        }

        public void AddMonthlyCoffer(decimal amount, int month, string name, int order, int cofferId)
        {
            try
            {
                using (TreasuryContext db = new TreasuryContext())
                {
                    db.MonthlyCoffers.Add(new Data.Models.MonthlyCoffer { Amount = double.Parse(amount.ToString()), Month = month, Name = name, Order = order, CofferId = cofferId });
                    db.SaveChanges();
                }
            }
            catch
            {

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
