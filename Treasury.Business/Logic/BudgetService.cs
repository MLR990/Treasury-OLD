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
            if (type == "Monthly")
            {
                int currentMonth = DateTime.Now.Month;
                for (int i = currentMonth; i <= 12; i++)
                {
                    AddCoffer(amount, i, name, necessary, order, BudgetType.Monthly, budgetId, description);
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
                        AddCoffer(Math.Round(monthlyAmount, 2), i, name, necessary, order, BudgetType.OneTime, budgetId, description);
                    }
                }
                else
                {
                    int currentMonth = DateTime.Now.Month;
                    int monthsToPay = 12 - currentMonth;
                    decimal monthlyAmount = amount / monthsToPay;

                    for (int i = currentMonth; i <= 12; i++)
                    {
                        AddCoffer(Math.Round(monthlyAmount, 2), i, name, necessary, order, BudgetType.Annual, budgetId, description);
                    }

                }
            }
        }

        public void AddCoffer(decimal amount, int month, string name, bool necessary, int order, BudgetType type, int budgetId, string description)
        {
            try
            {
                using (TreasuryContext db = new TreasuryContext())
                {
                    db.Coffers.Add(new Data.Models.Coffer { Amount = double.Parse(amount.ToString()), Month = GetMonth(month), Necessary = necessary, Name = name, Order = order, BudgetId = budgetId, Description = description, Type = type });
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
