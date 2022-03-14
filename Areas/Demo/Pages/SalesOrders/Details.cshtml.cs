#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Acumatica.Auth.Api;
using Acumatica.Default_20_200_001.Api;

using AcuERP_DemoApp.Data;
using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Areas.Demo.Pages.SalesOrders;

public class DetailsModel : PageModel
{
    private readonly ILogger<DetailsModel> _logger;
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context, ILogger<DetailsModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// </summary>
    [BindProperty]
    public AcuCredential acuCredential { get; set; }

    /// <summary>
    /// </summary>
    public string ReturnUrl { get; set; }

    /// <summary>
    /// </summary>
    [TempData]
    public string ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        acuCredential = await _context.AcuCredentials.FindAsync(id);
        Console.WriteLine("acuCredential to use: " + acuCredential);

        if (acuCredential == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        //if (!ModelState.IsValid)
        //{
        //    return RedirectToPage("/Index");
        //}

        acuCredential = await _context.AcuCredentials.FindAsync(1);

        //acuCredential acuCredential = _context.acuCredentials.FirstOrDefault();
        Console.WriteLine("REST API example using acuCredential:" + acuCredential);

        //var authApi = new AuthApi(acuCredential.SiteUrl,
        //     requestInterceptor: Logger.LogRequest, responseInterceptor: Logger.LogResponse);

        var authApi = new AuthApi(acuCredential.siteUrl,
            requestInterceptor: Logger.LogRequest, responseInterceptor: Logger.LogResponse);

        try
        {
            //var configuration = authApi.LogIn(acuCredential.UserId, acuCredential.Password, acuCredential.Tenant, acuCredential.Branch, acuCredential.Locale);

            var configuration = authApi.LogIn(acuCredential.userName, acuCredential.password, "", "", "");

            Console.WriteLine("Reading Accounts...");
            var accountApi = new AccountApi(configuration);
            var salesOrderApi = new SalesOrderApi(configuration);
            var accounts = accountApi.GetList(top: 99);
            var salesOrders = salesOrderApi.GetList(top: 22);
            foreach (var account in accounts)
            {
                Console.WriteLine("Account Nbr: " + account.AccountCD.Value + "/" + account.Description.Value + ";");
            }
            foreach (var order in salesOrders)
            {
                Console.WriteLine("Sales Order Nbr: " + order.OrderNbr.Value + "/" + order.OrderTotal.Value + ";");
            }

            //Console.WriteLine("Reading Sales Order by Keys...");
            //var salesOrderApi = new SalesOrderApi(configuration);
            //var order = salesOrderApi.GetByKeys(new List<string>() { "SO", "SO006596" });
            //Console.WriteLine("Order Total: " + order.OrderTotal.Value);


            //var shipmentApi = new ShipmentApi(configuration);
            //var shipment = shipmentApi.GetByKeys(new List<string>() { "004202" });
            //Console.WriteLine("ConfirmShipment");
            //shipmentApi.WaitActionCompletion(shipmentApi.InvokeAction(new ConfirmShipment(shipment)));

            //Console.WriteLine("CorrectShipment");
            //shipmentApi.WaitActionCompletion(shipmentApi.InvokeAction(new CorrectShipment(shipment)));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            //we use logout in finally block because we need to always logout, even if the request failed for some reason

            authApi.Logout();
            Console.WriteLine("Logged Out...");

        }
        return RedirectToPage("/Index");
    }
}

//#nullable disable

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;

//using AcuERP_DemoApp.Data;
//using AcuERP_DemoApp.Entities;

//namespace AcuERP_DemoApp.Areas.Demo.Pages.SalesOrders;

//public class DetailsModel : PageModel
//{
//    private readonly AppDbContext _context;

//    public DetailsModel(AppDbContext context)
//    {
//        _context = context;
//    }

//    public SalesOrder SalesOrder { get; set; }

//    public async Task<IActionResult> OnGetAsync(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        SalesOrder = await _context.SalesOrders.FirstOrDefaultAsync(m => m.Id == id);

//        if (SalesOrder == null)
//        {
//            return NotFound();
//        }
//        return Page();
//    }
//}
