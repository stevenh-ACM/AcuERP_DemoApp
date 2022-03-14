#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using AcuERP_DemoApp.Data;
using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Areas.Demo.Pages.Home;

public class detailsModel : PageModel
{
    private readonly AppDbContext _context;

    public detailsModel(AppDbContext context)
    {
        _context = context;
    }

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
}
