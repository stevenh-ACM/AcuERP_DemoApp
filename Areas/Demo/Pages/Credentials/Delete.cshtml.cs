#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using AcuERP_DemoApp.Data;
using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Areas.Demo.Pages.Credentials;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public AcuCredential AcuCredential { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        AcuCredential = await _context.AcuCredentials.FirstOrDefaultAsync(m => m.Id == id);

        if (AcuCredential == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        AcuCredential = await _context.AcuCredentials.FindAsync(id);

        if (AcuCredential != null)
        {
            _context.AcuCredentials.Remove(AcuCredential);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
