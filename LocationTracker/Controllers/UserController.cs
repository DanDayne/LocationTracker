using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using LocationTracker.Helpers;
using LocationTracker.Models;
using LocationTracker.Models.Request;
using LocationTracker.Providers;

namespace LocationTracker.Controllers
{
    public class UserController : Controller
    {

        [HttpPost]
        public ActionResult Register(RegisterRequest request)
        {
            return new HttpStatusCodeResult(
                UserProvider.RegisterUser(request.UserName, request.Password)
                    ? HttpStatusCode.OK
                    : HttpStatusCode.BadRequest
            );
        }

        [HttpPost]
        public ActionResult LogIn(LoginRequest request)
        {
            var sessionKey = UserProvider.LogIn(request.UserName, request.Password);

            return Json(new Dictionary<string, string>
            {
                {SessionKeyHelper.SessionKey, sessionKey}
            });
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            var sessionKey = SessionKeyHelper.GetSessionKey(Request);
            SessionKeyHelper.CheckSessionKeyValidity(sessionKey);

            return new HttpStatusCodeResult(UserProvider.LogOut(sessionKey)
                ? HttpStatusCode.OK
                : HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult StoreLocation(Location location)
        {
            var sessionKey = SessionKeyHelper.GetSessionKey(Request);
            SessionKeyHelper.CheckSessionKeyValidity(sessionKey);

            var username = UserProvider.GetUserNameForSessionKey(sessionKey);

            return new HttpStatusCodeResult(
                UserProvider.StoreLocation(username, location)
                    ? HttpStatusCode.OK
                    : HttpStatusCode.BadRequest);
        }
    }
}