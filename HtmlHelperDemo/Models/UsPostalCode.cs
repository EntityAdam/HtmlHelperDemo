using System.ComponentModel.DataAnnotations;

namespace HtmlHelperDemo.Models
{
    public sealed class UsPostalCode : PostalCode
    {
        [Required]
        public string Zip { get; set; }

        public string ZipExt { get; set; }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(ZipExt) ? $"{Zip}" : $"{Zip}-{ZipExt}";
        }
    }
}