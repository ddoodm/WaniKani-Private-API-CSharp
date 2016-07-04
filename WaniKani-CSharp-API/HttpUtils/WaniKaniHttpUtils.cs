﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ddoodm.WaniKani.HttpUtils
{
    internal class WaniKaniHttpUtils
    {
        internal static HttpWebResponse MakeAuthenticatedWaniKaniRequest(string uri, WaniKaniUser user)
        {
            HttpWebRequest queueRequest = HttpWebRequest.Create(uri) as HttpWebRequest;
            queueRequest.Accept = "application/json, text/javascript, */*; q=0.01";
            queueRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");

            CookieContainer cookieJar = queueRequest.CookieContainer = new CookieContainer();
            cookieJar.Add(user.SessionCookie);

            return queueRequest.GetResponse() as HttpWebResponse;
        }
    }
}
