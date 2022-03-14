#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcuERP_DemoApp.Entities;

    public class AcuCredential
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        //[Display(Name = "Acumatica ERP Host Url (e.g. http://localhost/acumaticaerp")]
        public string siteUrl { get; set; } = string.Empty;

        [Required]
        //[Display(Name = "Acumatica User ID")]
        public string userName { get; set; } = string.Empty;

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        public string password { get; set; } = string.Empty;

        //[Display(Name = "Tenant (default is null)")]
        public string tenant { get; set; } = string.Empty;

        //[Display(Name = "Branch (default is null)")]
        public string branch { get; set; } = string.Empty;

        //[Display(Name = "Locale (default is null)")]
        public string locale { get; set; } = string.Empty;
    }
