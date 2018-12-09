using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using HtmlHelperDemo.Extensions;
using HtmlHelperDemo.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using Xunit;

namespace HtmlHelperDemo.Tests
{
    public class SimpleHtmlHelperTests
    {
        [Fact]
        public void SimpleHtmlHelper_YesNo_True()
        {
            var htmlHelperMock = new Mock<IHtmlHelper>();

            var result = htmlHelperMock.Object.YesNo(true).GetString();

            Assert.Equal("Yes", result);
        }

        [Fact]
        public void SimpleHtmlHelper_YesNo_False()
        {
            var htmlHelperMock = new Mock<IHtmlHelper>();

            var result = htmlHelperMock.Object.YesNo(false).GetString();

            Assert.Equal("No", result);
        }

        [Fact]
        public void SimpleHtmlHelper_YesNoColor_True()
        {
            var htmlHelperMock = new Mock<IHtmlHelper>();
            var expected = "<span style=\"color:green\">Yes</span>";

            var result = htmlHelperMock.Object.YesNoColor(true).GetString();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SimpleHtmlHelper_YesNoColor_False()
        {
            var htmlHelperMock = new Mock<IHtmlHelper>();
            var expected = "<span style=\"color:red\">No</span>";

            var result = htmlHelperMock.Object.YesNoColor(false).GetString();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SimpleHtmlHelper_DisplayShortAddress()
        {
            var htmlHelperMock = new Mock<IHtmlHelper>();
            var expected = "<address class=\"text-muted\">100 N. Duke St, Durham, NC 27704</address>";

            var result = htmlHelperMock.Object.DisplayShortAddress(TestHelper.GetPeople().First()).GetString();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SimpleHtmlHelper_DisplayMailingAddress()
        {
            var htmlHelperMock = new Mock<IHtmlHelper>();
            var expected = "<address class=\"text-muted\">Adam Vincent<br>100 N. Duke St<br>Durham, NC 27704<br>US<br></address>";

            var result = htmlHelperMock.Object.DisplayMailingAddress(TestHelper.GetPeople().First()).GetString();

            Assert.Equal(expected, result);
        }
    }


    public static class TestHelper
    {
        public static string GetString(this IHtmlContent content)
        {
            var writer = new StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        public static List<Person> GetPeople() => new List<Person>()
        {
            new Person()
            {
                Id = 0,
                Name = "Adam Vincent",
                IsDeveloper = true,
                Address = new UsAddress()
                {
                    Address1 = "100 N. Duke St",
                    City = "Durham",
                    State = "NC",
                    PostalCode = new UsPostalCode() { Zip = "27704" }
                }
            },
            new Person()
            {
                Id = 1,
                Name = "Thomas Edison",
                IsDeveloper = false,
                Address = new UsAddress()
                {
                    Address1 = "1 River Rd",
                    CompanyName = "General Electric",
                    City = "Schenectady",
                    State = "NY",
                    PostalCode = new UsPostalCode() { Zip = "12345" }
                }
            },
        };
    }
}
