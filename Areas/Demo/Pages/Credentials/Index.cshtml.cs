#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using AcuERP_DemoApp.Data;
using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Areas.Demo.Pages.Credentials;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<AcuCredential> AcuCredential { get;set; }

    public async Task OnGetAsync()
    {
        AcuCredential = await _context.AcuCredentials.ToListAsync();
    }
}
