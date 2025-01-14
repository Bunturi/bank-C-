using Bank.DAL;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bank.Pages.Expend
{
    public class DeleteModel : PageModel
    {
        public readonly MyAppDbContext _context;

        public DeleteModel(MyAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Expends Expend { get; set; }

        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if (itemid == null)
            {
                return NotFound();
            }

            var expend = await _context.Expend.FirstOrDefaultAsync(p => p.Id == itemid);

            if (expend == null)
            {
                return NotFound();
            }
            Expend = expend;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? itemid)
        {
            if (itemid == null)
            {
                return NotFound();
            }
            var expend = await _context.Expend.FindAsync(itemid);

            if (expend == null)
            {
                return NotFound();
            }
            Expend = expend;

            _context.Remove(Expend);
            await _context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));

        }

    }
}
