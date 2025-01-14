using Bank.DAL;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Pages.Dash
{
    public class TransModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public TransModel(MyAppDbContext context)
        {
            _context = context;
        }

        public List<Expends> Transactions { get; set; }

        // Bind the SelectedCategory from the query string
        [BindProperty(SupportsGet = true)]
        public TransactionCategory SelectedCategory { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Expend != null)
            {
                // Filter transactions based on the selected category
                Transactions = await _context.Expend
                    .Where(e => e.TransactionCategory.ToString() == SelectedCategory.ToString())
                    .ToListAsync();
            }
        }
    }
}
