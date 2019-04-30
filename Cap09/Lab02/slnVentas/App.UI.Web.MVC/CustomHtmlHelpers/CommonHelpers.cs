using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.CustomHtmlHelpers
{
    public static class CommonHelpers
    {
        public static MvcHtmlString SemaforoStock(
            this HtmlHelper helper,
            decimal stock
            )
        {
            string html = "";
            string imgUrl = "";
            if(stock>0)
            {
                imgUrl = "/Content/images/circulo-verde.png";
            }
            else
            {
                imgUrl = "/Content/images/circulo-rojo.png";
            }

            TagBuilder tag = new TagBuilder("img");
            tag.Attributes.Add("src", imgUrl);

            html = tag.ToString(TagRenderMode.SelfClosing);

            return new MvcHtmlString(html);

        }
    }
}