using System.Collections.Generic;
using HtmlHelperDemo.Models;

namespace HtmlHelperDemo.DataProvider
{
    public interface IPersonProvider
    {
        List<Person> Get();
    }
}