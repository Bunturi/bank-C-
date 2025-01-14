using Bank.DAL;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bank.Pages.Expend
{
    public class CreateModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public CreateModel(MyAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Expends Expend { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid || _context.Expend == null
                || Expend == null)
            {
                return Page();
            }
            _context.Expend.Add(Expend);
            await _context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
