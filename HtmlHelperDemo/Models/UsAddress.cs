using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HtmlHelperDemo.Models
{
    public sealed class UsAddress : Address
    {

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string CompanyName { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }

        [Required]
        public PostalCode PostalCode { get; set; }

        public override string ShortAddress()
        {
            var builder = new StringBuilder();
            builder.Append($"{Address1}, {City}, {State} {PostalCode}");
            return builder.ToString();
        }

        public override string[] MailingAddress()
        {
            var lines = new List<string>();
            if (!string.IsNullOrWhiteSpace(CompanyName))
            {
                lines.Add(CompanyName);
            }
            lines.Add(Address1);
            if (!string.IsNullOrWhiteSpace(Address2))
            {
                lines.Add(Address2);
            }
            lines.Add($"{City}, {State} {PostalCode}");
            lines.Add("US");
            return lines.ToArray();
        }
    }
}