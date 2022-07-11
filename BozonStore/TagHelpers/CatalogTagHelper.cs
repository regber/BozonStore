using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using BozonStore.Models.ProductModel;
using System.Reflection;
using BozonStore.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;


namespace BozonStore.TagHelpers
{
    public class CatalogTagHelper:TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var catalog = CreateCatalog();

            output.Content.SetHtmlContent(catalog);
        }

        private IHtmlContent CreateCatalog()
        {
            TagBuilder ul = new TagBuilder("ul");

            ul.AddCssClass("catalog");

            TagBuilder a = new TagBuilder("a");
            a.InnerHtml.Append("Каталог");
            a.Attributes.Add("href", "/?catalogType=Product");

            TagBuilder li = new TagBuilder("li");
            li.InnerHtml.AppendHtml(a);

            TagBuilder mainUl = new TagBuilder("ul");

            var prodTypes = ProdInfo.GetProdTypeInfo();

            foreach (var type in prodTypes)
            {
                var catalogNode = CreateCatalogNode(type);
                mainUl.InnerHtml.AppendHtml(catalogNode);
            }
            
            li.InnerHtml.AppendHtml(mainUl);

            ul.InnerHtml.AppendHtml(li);

            return ul;
        }

        private IHtmlContent CreateCatalogNode(Type type)
        {
            var childTypes = ExtraTypeInfo.GetFirstChildrenOfType(type);

            if (childTypes.Count() > 0)
            {
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", "/?catalogType="+ type.Name);
                a.InnerHtml.Append(ExtraTypeInfo.GetDisplayName(type));

                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.AppendHtml(a);

                TagBuilder ul = new TagBuilder("ul");
                

                foreach (var t in childTypes)
                {
                    ul.InnerHtml.AppendHtml(CreateCatalogNode(t));
                }

                li.InnerHtml.AppendHtml(ul);

                return li;
            }
            else
            {
                
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", "/?catalogType=" + type.Name);
                a.InnerHtml.Append(ExtraTypeInfo.GetDisplayName(type));

                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.AppendHtml(a);

                return li;
            }
        }
    }
}
