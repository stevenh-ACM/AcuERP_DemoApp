#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using AcuERP_DemoApp.Data;
using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Areas.Demo.Pages.Opportunities;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Opportunity Opportunity { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Opportunities.Add(Opportunity);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
