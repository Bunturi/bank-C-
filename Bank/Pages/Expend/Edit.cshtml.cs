using Bank.DAL;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bank.Pages.Expend
{
    public class EditModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public EditModel(MyAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Expends Expend { get; set; }
        public MyAppDbContext Get_context()
        {
            return _context;
        }


        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if (itemid == null || _context.Expend == null)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Expend.Update(Expend);
            await _context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));

        }
    }
}
