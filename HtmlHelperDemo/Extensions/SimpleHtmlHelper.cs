using System;
using HtmlHelperDemo.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HtmlHelperDemo.Extensions
{
    public static class SimpleHtmlHelper
    {
        public static IHtmlContent YesNo(this IHtmlHelper htmlHelper, bool isTrue)
        {
            var x = new HtmlContentBuilder();
            var text = isTrue ? "Yes" : "No";
            return x.Append(text);
        }

        public static IHtmlContent YesNoColor(this IHtmlHelper htmlHelper, bool isTrue)
        {
            var builder = new TagBuilder("span");
            
            if (isTrue) { 
                builder.Attributes.Add("style", "color:green");
                builder.InnerHtml.Append("Yes");
            }
            else
            {
                builder.Attributes.Add("style", "color:red");
                builder.InnerHtml.Append("No");
            }
            return builder;
        }

        public static IHtmlContent DisplayShortAddress(this IHtmlHelper htmlHelper, Person person)
        {
            var builder = new TagBuilder("address");
            
            builder.AddCssClass("text-muted");
            
            builder.InnerHtml
                .Append(person.Address.ShortAddress());

            return builder;
        }
        public static IHtmlContent DisplayMailingAddress(this IHtmlHelper htmlHelper, Person person)
        {
            var builder = new TagBuilder("address");
            
            builder.AddCssClass("text-muted");

            builder.InnerHtml
                .Append(person.Name)
                .AppendHtml("<br>");

            foreach (var line in person.Address.MailingAddress())
            {
                builder.InnerHtml.Append(line).AppendHtml("<br>");
            }

            return builder;
        }

        public static IHtmlContent IsActive(this IHtmlHelper htmlHelper, bool isActive)
        {
            var x = new HtmlContentBuilder();
            var text = isActive ? "Active" : "Inactive";
            return x.Append(text);
        }

        public static IHtmlContent ShortDateFor(this IHtmlHelper htmlHelper, DateTime? dateTime)
        {
            var x = new HtmlContentBuilder();
            var text = "No Date";
            if (dateTime.HasValue)
            {
                text = dateTime.Value.ToShortDateString();
            }
            return x.Append(text);
        }
    }


}
