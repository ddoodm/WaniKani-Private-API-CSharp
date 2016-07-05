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
        internal static async Task<HttpWebResponse> MakeAuthenticatedRequestForResultAsync(
            string uri, WaniKaniUser user)
        {
            HttpWebRequest queueRequest = HttpWebRequest.Create(uri) as HttpWebRequest;
            queueRequest.Accept = "application/json, text/javascript, */*; q=0.01";
            queueRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");

            CookieContainer cookieJar = queueRequest.CookieContainer = new CookieContainer();
            cookieJar.Add(user.SessionCookie);

            return await queueRequest.GetResponseAsync() as HttpWebResponse;
        }

        internal static async Task<HttpWebResponse> MakeAuthenticatedRequestForResultAsync(
            string uri, WaniKaniUser user, NameValueCollection parameters)
        {
            string parameterizedUri = String.Format(
                "{0}?{1}", uri, parameters.ToQueryString());
            return await MakeAuthenticatedRequestForResultAsync(parameterizedUri, user);
        }

        internal static async Task<string> GetAuthenticatedStringResultAsync(string uri, WaniKaniUser user)
        {
            HttpWebResponse response =
                await WaniKaniHttpUtils.MakeAuthenticatedRequestForResultAsync(
                    uri, user);

            StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }
    }
}
