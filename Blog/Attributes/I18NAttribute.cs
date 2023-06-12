using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Blog.Attributes
{
    public class I18NAttribute : ActionFilterAttribute
    {
        private readonly IList<string> supportedLocales;
        private readonly string defaultLanguage;

        public I18NAttribute()
        {
            //this.supportedLocales =   
            this.defaultLanguage = "en";
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var language = (string)filterContext.RouteData.Values["lang"] ?? this.defaultLanguage;

            if (IsLanguageSupported(language) == true)
            {
                language = this.defaultLanguage;
            }

            SetLanguage(language);
        }

        private void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
        }

        private bool IsLanguageSupported(string language)
        {
            // this.supportedLocales.Contains(language);

            return true;
        }
    }
}