using System.Web;
using projectpsd.Model;

namespace projectpsd.Utils
{
    public static class SessionManager
    {
        private const string UserSessionKey = "CurrentUser";

        public static void SetCurrentUser(MsUser user)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session[UserSessionKey] = user;
            }
        }

        public static MsUser GetCurrentUser()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                return HttpContext.Current.Session[UserSessionKey] as MsUser;
            }
            return null;
        }

        public static int GetCurrentUserId()
        {
            var user = GetCurrentUser();
            return user != null ? user.UserID : 0;
        }

        public static string GetCurrentUserRole()
        {
            var user = GetCurrentUser();
            return user != null ? user.UserRole : string.Empty;
        }

        public static string GetCurrentUserName()
        {
            var user = GetCurrentUser();
            return user != null ? user.UserName : string.Empty;
        }

        public static void ClearSession()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
            }
        }

        public static bool IsLoggedIn()
        {
            return GetCurrentUser() != null;
        }

        public static bool IsAdmin()
        {
            return GetCurrentUserRole() == "Admin";
        }

        public static bool IsCustomer()
        {
            return GetCurrentUserRole() == "Customer";
        }

        public static bool IsGuest()
        {
            return !IsLoggedIn();
        }
    }
}