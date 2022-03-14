#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using AcuERP_DemoApp.Data;
using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Areas.Demo.Pages.Home;

public class SetupModel : PageModel
{
    private readonly ILogger<SetupModel> _logger;
    private readonly AppDbContext _context;

    public SetupModel(AppDbContext context, ILogger<SetupModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// </summary>
    [BindProperty]
    public AcuCredential acuCredential { get; set; }

    public IList<AcuCredential> acuCredentials { get; set; }

    /// <summary>
    /// </summary>
    public string ReturnUrl { get; set; }

    /// <summary>
    /// </summary>
    [TempData]
    public string ErrorMessage { get; set; }

    public async Task OnGetAsync()
    {
        if (!ModelState.IsValid)
        {
            RedirectToPage("./Setup");
        }

        acuCredentials = await _context.AcuCredentials.ToListAsync();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.AcuCredentials.Add(acuCredential);
        await _context.SaveChangesAsync();


        return RedirectToPage("./Main");
    }
}


