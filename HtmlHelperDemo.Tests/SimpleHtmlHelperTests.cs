using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Xunit;

namespace HtmlHelperDemo.Tests
{
    public class SimpleHtmlHelperTests
    {
        [Fact]
        public void Test1()
        {
            //https://github.com/aspnet/Mvc/issues/6621
            
            var isTestable = false;

            Assert.True(isTestable);
        }
    }
}
