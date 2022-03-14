#nullable disable

using Microsoft.AspNetCore.Identity;

namespace AcuERP_DemoApp.Entities;

// Add profile data for application users by adding properties to the ApiDemoUser class
public class ApiDemoUser : IdentityUser
{
    [PersonalData]
    public string Name { get; set; }
    [PersonalData]
    public DateTime DOB { get; set; }

}

