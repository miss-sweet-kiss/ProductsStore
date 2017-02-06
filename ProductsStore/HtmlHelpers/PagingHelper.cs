using System;
using System.Text;
using System.Web.Mvc;
using ProductsStore.Models;

namespace ProductsStore.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                result.Append(tag);
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}