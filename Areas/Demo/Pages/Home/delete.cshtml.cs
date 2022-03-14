#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using AcuERP_DemoApp.Data;
using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Areas.Demo.Pages.Home;

public class deleteModel : PageModel
{
    private readonly AppDbContext _context;

    public deleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public AcuCredential acuCredential { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        acuCredential = await _context.AcuCredentials.FirstOrDefaultAsync(m => m.Id == id);

        if (acuCredential == null)
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

        acuCredential = await _context.AcuCredentials.FindAsync(id);

        if (acuCredential != null)
        {
            _context.AcuCredentials.Remove(acuCredential);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Setup");

    }
}
