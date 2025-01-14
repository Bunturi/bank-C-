using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Bank.Models
{
    public enum TransactionCategory
    {
        [Display(Name = "Withdraw Money")]
        WithdrawMoney,

        [Display(Name = "Bank & Insurance")]
        BankInsurance,

        [Display(Name = "Family Expense")]
        FamilyExpense,

        [Display(Name = "Transfers")]
        Transfers,

        [Display(Name = "Restaurant")]
        Restaurant,

        [Display(Name = "Shopping")]
        Shopping,

        [Display(Name = "Utility Payments")]
        UtilityPayments,

        [Display(Name = "Transportation")]
        Transportation,

        [Display(Name = "Health & Beauty")]
        HealthAndBeauty,

        [Display(Name = "Travel")]
        Travel,

        [Display(Name = "Other Expenses")]
        OtherExpenses
    }

    public class Expends
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [DefaultValue("Expends")] 
        public string Transaction { get; set; } = "Expends";

        [Required]
        [DefaultValue(TransactionCategory.OtherExpenses)]
        public TransactionCategory TransactionCategory { get; set; } = TransactionCategory.OtherExpenses;

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public DateTime? Date { get; internal set; }

    }


    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));
            return attribute != null ? attribute.Name : value.ToString();
        }
    }
}