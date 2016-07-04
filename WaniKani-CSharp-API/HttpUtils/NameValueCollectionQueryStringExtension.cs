using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ddoodm.WaniKani.HttpUtils
{
    public static class NameValueCollectionQueryStringExtension
    {
        /// <summary>
        /// Builds a HTTP query string from a NameValueCollection.
        /// 
        /// By StackOverflow author "bbeda"
        /// http://stackoverflow.com/a/19724253/5571426
        /// </summary>
        public static string ToQueryString(this NameValueCollection collection)
        {
            var array = (from key in collection.AllKeys
                         from value in collection.GetValues(key)
                         select string.Format(
                             "{0}={1}",
                             HttpUtility.UrlEncode(key),
                             HttpUtility.UrlEncode(value))).ToArray();
            return string.Join("&", array);
        }
    }
}
