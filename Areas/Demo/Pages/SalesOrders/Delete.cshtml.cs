#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using AcuERP_DemoApp.Data;
using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Areas.Demo.Pages.SalesOrders;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public SalesOrder SalesOrder { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        SalesOrder = await _context.SalesOrders.FirstOrDefaultAsync(m => m.Id == id);

        if (SalesOrder == null)
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

        SalesOrder = await _context.SalesOrders.FindAsync(id);

        if (SalesOrder != null)
        {
            _context.SalesOrders.Remove(SalesOrder);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
