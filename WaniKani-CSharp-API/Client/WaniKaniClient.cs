using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using HtmlAgilityPack;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Ddoodm.WaniKani.JsonUtils;
using Ddoodm.WaniKani.HttpUtils;
using Ddoodm.WaniKani.Models;

namespace Ddoodm.WaniKani.Client
{
    public class WaniKaniClient
    {
        private const string
            WANIKANI_URL = "https://www.wanikani.com/",
            WANIKANI_LOGIN_URI = "https://www.wanikani.com/login",
            WANIKANI_DASHBOARD_URI = "https://www.wanikani.com/dashboard",
            WANIKANI_SESSION_COOKIE_KEY = "_wanikani_session";

        /// <summary>
        /// Creates a new WaniKani session for the user
        /// defined by their username and password.
        /// </summary>
        /// <param name="username">A valid WaniKani user</param>
        /// <param name="password">A valid password</param>
        /// <returns>
        /// The WaniKani user associated with the account.
        /// Otherwise, null if the user could not be authenticated.
        /// </returns>
        public WaniKaniUser Login(string username, string password)
        {
            var authData = GetLoginAuthenticityTokenAndInitialCookie();
            string authenticityToken = authData.AuthenticityToken;
            Cookie initialSessionCookie = authData.WaniKaniSessionCookie;

            // Construct form data
            NameValueCollection outgoingQueryString =
                HttpUtility.ParseQueryString("");
            outgoingQueryString.Add("authenticity_token", authenticityToken);
            outgoingQueryString.Add("user[login]", username);
            outgoingQueryString.Add("user[password]", password);
            outgoingQueryString.Add("user[remember_me]", "0");
            string postData = outgoingQueryString.ToString();
            byte[] postBytes = Encoding.UTF8.GetBytes(postData);

            // Build a HTTP POST request from the fabricated form data
            HttpWebRequest loginRequest = HttpWebRequest.Create(WANIKANI_LOGIN_URI) as HttpWebRequest;
            CookieContainer cookieJar = new CookieContainer();
            loginRequest.Method = "POST";
            loginRequest.ContentType = "application/x-www-form-urlencoded";
            loginRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            loginRequest.Referer = WANIKANI_LOGIN_URI;
            loginRequest.ContentLength = postBytes.Length;
            loginRequest.CookieContainer = cookieJar;

            // Add the request cookie
            cookieJar.Add(initialSessionCookie);

            using (Stream loginPostStream = loginRequest.GetRequestStream())
            {
                loginPostStream.Write(postBytes, 0, postBytes.Length);
                loginPostStream.Flush();
            }

            // Get the WaniKani Session ID from the login response cookie
            HttpWebResponse response = loginRequest.GetResponse() as HttpWebResponse;
            CookieCollection newCookies = cookieJar.GetCookies(loginRequest.RequestUri);
            Cookie waniKaniSessionCookie = GetWaniKaniSessionCookie(newCookies);

            // If the user was not redirected away from the login, they have not been logged in
            if (response.ResponseUri == new Uri(WANIKANI_LOGIN_URI))
                return null;

            // Otherwise, create the WaniKani user
            return new WaniKaniUser(waniKaniSessionCookie);
        }

        /// <summary>
        /// In order to log in, WaniKani requires that we first obtain an
        /// Authenticity Token. A unique token is available to us on the
        /// login page, and is provided in a hidden HTML form field.
        /// 
        /// WaniKani also requires that we have a session before loggin in.
        /// We may obtain our session cookie on the login page also.
        /// </summary>
        /// <returns>A WaniKani Session Cookie and Authenticity Token pair</returns>
        private WaniKaniAuthData GetLoginAuthenticityTokenAndInitialCookie()
        {
            HtmlWeb htmlWeb = new HtmlWeb { UseCookies = true };

            // Obtain the WaniKani session cookie from the response
            Cookie waniKaniSessionCookie = null;
            htmlWeb.PostResponse += (request, response) =>
            {
                CookieCollection responseCookies = response.Cookies;
                waniKaniSessionCookie = GetWaniKaniSessionCookie(responseCookies);
            };

            // Retrieve the WaniKani login interface via a GET request
            HtmlDocument loginInterface = htmlWeb.Load(WANIKANI_LOGIN_URI);

            // Locate the hidden 'authenticity token' form field
            HtmlNode authenticityTokenInput =
                loginInterface.DocumentNode
                .SelectSingleNode("*//input[@name='authenticity_token']");

            if (authenticityTokenInput == null)
                throw new HtmlWebException("The hidden HTML form input named 'authenticity_token' could not be found on the WaniKani login document.");
            
            string authenticityToken = authenticityTokenInput
                .Attributes["value"]
                .Value;

            return new WaniKaniAuthData(authenticityToken, waniKaniSessionCookie);
        }

        private Cookie GetWaniKaniSessionCookie(CookieCollection cookies)
        {
            return cookies[WANIKANI_SESSION_COOKIE_KEY];
        }
    }
}
