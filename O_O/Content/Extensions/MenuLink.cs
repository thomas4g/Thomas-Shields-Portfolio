using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace O_O.Content.Extensions
{
    public static class MenuExtensions
    {
        public static MvcHtmlString MenuItem(this HtmlHelper htmlHelper, string controller, string action, string text)
        {
            var item = new TagBuilder("a");
            item.Attributes.Add("href", "/" + controller + "/" + action);
            var currAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            var currContr = (string)htmlHelper.ViewContext.RouteData.Values["controller"];
            if ((controller.ToLower() == currContr.ToLower() && action.ToLower() == currAction.ToLower()) || (currContr.ToLower() == "blog" && controller.ToLower() == "blog")) item.AddCssClass("selected");
            item.SetInnerText(text);
            return MvcHtmlString.Create(item.ToString());
        }
    }
}