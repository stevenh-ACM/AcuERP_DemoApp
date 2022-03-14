#nullable disable

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Data;

public class AppDbContext : IdentityDbContext<ApiDemoUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<AcuCredential> AcuCredentials { get; set; }

    public DbSet<Case> Cases { get; set; }

    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Opportunity> Opportunities { get; set; }

    public DbSet<SalesOrder> SalesOrders { get; set; }
}