using System;
using System.Collections;
using System.Collections.Generic;
using LocationTracker.Database;
using LocationTracker.Helpers;
using LocationTracker.Models;

namespace LocationTracker.Providers
{
    public static class UserProvider
    {
        public static bool RegisterUser(string userName, string password) =>
            DatabaseManager.CreateNewUser(userName, PasswordHelper.ToHash(password));

        public static string LogIn(string userName, string password)
        {
            var sessionKey = Guid.NewGuid().ToString();
            return DatabaseManager.LogInUser(userName, PasswordHelper.ToHash(password), sessionKey) ? sessionKey : null;
        }

        public static bool LogOut(string sessionKey) => DatabaseManager.RemoveSessionKey(sessionKey);

        public static bool IsSessionKeyValid(string sessionKey) => DatabaseManager.CheckSessionKeyValidity(sessionKey);

        public static Location GetLastLocationForUser(string userName) => DatabaseManager.GetLastLocation(userName);

        public static string GetUserNameForSessionKey(string sessionKey) =>
            DatabaseManager.GetUserNameForSessionKey(sessionKey);

        public static bool StoreLocation(string userName, Location location) =>
            DatabaseManager.StoreLocation(location, userName);

        public static IEnumerable<string> GetUsersWithLocation()
        {
            return DatabaseManager.GetUsersWithLocation();
        }

    }
}