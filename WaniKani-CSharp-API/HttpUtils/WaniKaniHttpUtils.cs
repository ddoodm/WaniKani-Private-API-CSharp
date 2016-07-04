using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ddoodm.WaniKani.HttpUtils
{
    internal class WaniKaniHttpUtils
    {
        internal static HttpWebResponse MakeAuthenticatedWaniKaniRequest(
            string uri, WaniKaniUser user)
        {
            HttpWebRequest queueRequest = HttpWebRequest.Create(uri) as HttpWebRequest;
            queueRequest.Accept = "application/json, text/javascript, */*; q=0.01";
            queueRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");

            CookieContainer cookieJar = queueRequest.CookieContainer = new CookieContainer();
            cookieJar.Add(user.SessionCookie);

            return queueRequest.GetResponse() as HttpWebResponse;
        }

        internal static HttpWebResponse MakeAuthenticatedWaniKaniRequest(
            string uri, WaniKaniUser user, NameValueCollection parameters)
        {
            string parameterizedUri = String.Format(
                "{0}?{1}", uri, parameters.ToQueryString());
            return MakeAuthenticatedWaniKaniRequest(parameterizedUri, user);
        }

        internal static string GetAuthenticatedStringResult(string uri, WaniKaniUser user)
        {
            HttpWebResponse response =
                WaniKaniHttpUtils.MakeAuthenticatedWaniKaniRequest(
                    uri, user);

            StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }
    }
}
