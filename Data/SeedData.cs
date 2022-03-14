using Microsoft.EntityFrameworkCore;

using AcuERP_DemoApp.Entities;

namespace AcuERP_DemoApp.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (context == null || context.AcuCredentials == null)
            {
                throw new ArgumentNullException("Null AppDbContext");
            }

            // Look for any movies.
            if (context.AcuCredentials.Any())
            {
                return;   // DB has been seeded
            }

            context.AcuCredentials.AddRange(
                new AcuCredential
                {
                    siteUrl = "https://acu-demos.us/acumaticaerp",
                    userName = "admin",
                    password = "123",
                    tenant = "MyTenant",
                    branch = "main",
                    locale = "en-us"

                },

                new AcuCredential
                {
                    siteUrl = "https://acu-demos.us/acumaticaerp",
                    userName = "admin",
                    password = "123",
                    tenant = "Company",
                    branch = "USA",
                    locale = "en-us"

                },

                new AcuCredential
                {
                    siteUrl = "https://acu-demos.us/acumaticaerp",
                    userName = "admin",
                    password = "123",
                    tenant = "MyStoreInstance",
                    branch = "MyStore",
                    locale = "en-us"

                },

                new AcuCredential
                {
                    siteUrl = "https://acu-demos.us/acumaticaerp",
                    userName = "admin",
                    password = "123",
                    tenant = "OtherTenant",
                    branch = "other",
                    locale = "en-us"

                }
            );
            context.SaveChanges();
        }
    }
}