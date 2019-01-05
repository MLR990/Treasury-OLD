using System;
namespace Treasury.Data.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double AmountFunded { get; set; }
        public double AmountSpent { get; set; }
        public bool Closed { get; set; }
        public int Order { get; set; }
        public bool Necessary { get; set; }
        public Month Month { get; set; }
        public BudgetType Type { get; set; }
    }

    public enum BudgetType
    {
        Monthly,
        OneTime,
        Annual
    }

    public enum Month
    {
        January,
        Febuary,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October, 
        November,
        December
    }
}
