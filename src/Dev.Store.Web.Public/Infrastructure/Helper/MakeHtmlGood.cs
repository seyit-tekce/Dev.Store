using HtmlAgilityPack;
using System.Linq;
namespace Dev.Store.Web.Public.Infrastructure.Helper
{
    public class MakeHtmlGood
    {
        public static string Make(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var styleAttributes = doc.DocumentNode.DescendantsAndSelf()
                .SelectMany(d => d.Attributes.Where(a => a.Name.ToLower() == "style" || a.Name.ToLower()=="class").ToList());

            foreach (var styleAttribute in styleAttributes)
            {
                styleAttribute.Remove();
            }

            return doc.DocumentNode.OuterHtml;
        }
    }
}
