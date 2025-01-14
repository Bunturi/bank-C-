using Bank.DAL;
using Bank.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Bank.Pages.Dash
{
    public class DashboardModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public DashboardModel(MyAppDbContext context)
        {
            _context = context;
        }

        public List<TransactionSummary> TransactionSummaries { get; set; }

        public async Task OnGetAsync()
        {
            // Group by TransactionCategory and calculate the total amount for each category
            TransactionSummaries = await _context.Expend
                .GroupBy(e => e.TransactionCategory)
                .Select(group => new TransactionSummary
                {
                    Category = group.Key,
                    TotalAmount = group.Sum(e => e.Amount),
                    Count = group.Count()
                })
                .ToListAsync();
        }

        public class TransactionSummary
        {
            public TransactionCategory Category { get; set; }
            public decimal TotalAmount { get; set; }
            public int Count { get; set; }
        }
    }
}
