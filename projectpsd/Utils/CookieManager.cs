using System;
using System.Web;

namespace projectpsd.Utils
{
    public static class CookieManager
    {
        private const string RememberMeCookieName = "RememberMeJawels";

        public static void SetRememberMeCookie(string email, string hashedPassword)
        {
            if (HttpContext.Current != null)
            {
                HttpCookie cookie = new HttpCookie(RememberMeCookieName);
                cookie["Email"] = email;
                cookie["PasswordHash"] = hashedPassword;
                cookie.Expires = DateTime.Now.AddDays(30);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static HttpCookie GetRememberMeCookie()
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.Cookies[RememberMeCookieName];
            }
            return null;
        }

        public static void ClearRememberMeCookie()
        {
            if (HttpContext.Current != null)
            {
                HttpCookie cookie = new HttpCookie(RememberMeCookieName);
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}