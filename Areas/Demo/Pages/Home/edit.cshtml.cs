#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using AcuERP_DemoApp.Data;
using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Areas.Demo.Pages.Home;

public class editModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<editModel> _logger;
    public editModel(AppDbContext context, ILogger<editModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    [BindProperty]
    public AcuCredential acuCredential { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        acuCredential = await _context.AcuCredentials.FindAsync(id);

        if (acuCredential == null)
        {
            return RedirectToPage("./Setup");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var acuUserToUpdate = await _context.AcuCredentials.FindAsync(id);

        /*       _context.Attach(acuUser).State = EntityState.Modified*/
        ;

        if (acuUserToUpdate == null)
        {
            return NotFound();
        }
        try
        {
            if (await TryUpdateModelAsync<AcuCredential>(
                acuUserToUpdate,
                "AcuCredential",
                s => s.siteUrl,
                s => s.userName,
                s => s.password,
                s => s.tenant,
                s => s.branch,
                s => s.locale))
            {
                await _context.SaveChangesAsync();
            }
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new Exception($"AcuCredential {acuCredential.Id} not found!");
        }

        return RedirectToPage("./Setup");
    }

}

