using Bank.DAL;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bank.Pages.Expend
{
    public class IndexModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public IndexModel(MyAppDbContext context)
        {
            _context = context;
        }

        public List<Expends> Expend { get; set; } = new List<Expends>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public const int PageSize = 10;

        public async Task OnGetAsync()
        {
            if (_context.Expend != null)
            {
                var query = _context.Expend.AsQueryable();

                // Apply search filter if SearchTerm is at least 3 characters
                if (!string.IsNullOrEmpty(SearchTerm) && SearchTerm.Length >= 3)
                {
                    query = query.Where(e => e.Description.Contains(SearchTerm));
                }

                // Count total items after filtering
                int totalItems = await query.CountAsync();

                // Calculate total pages
                TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

                // Get the paginated data
                Expend = await query
                    .Skip((CurrentPage - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();
            }
        }
    }
}
