using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecordStore.MVC.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string IsActive(this IHtmlHelper html, string controller = "", string action = "")
        {
            var cssClass = "active";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];
            if (string.IsNullOrEmpty(controller)) controller = currentController;
            if (string.IsNullOrEmpty(action)) action = currentAction;
            return controller == currentController && action == currentAction ? cssClass : string.Empty;
        }
    }
}
