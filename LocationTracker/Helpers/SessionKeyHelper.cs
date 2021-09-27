using System;
using System.Web;
using LocationTracker.Providers;

namespace LocationTracker.Helpers
{
    public static class SessionKeyHelper
    {
        public const string SessionKey = "sessionKey";

        public static void CheckSessionKeyValidity(string sessionKey)
        {
            if (!UserProvider.IsSessionKeyValid(sessionKey))
            {
                throw new UnauthorizedAccessException();
            }
        }

        public static string GetSessionKey(HttpRequestBase request) =>
            (string) request.Headers.GetValues(SessionKey)?.GetValue(0);
    }
}