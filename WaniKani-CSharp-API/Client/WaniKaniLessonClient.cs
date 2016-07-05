using Ddoodm.WaniKani.HttpUtils;
using Ddoodm.WaniKani.JsonUtils;
using Ddoodm.WaniKani.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.Client
{
    public class WaniKaniLessonClient
    {
        private static string
            WANIKANI_LESSON_ENDPOINT_URI = "https://www.wanikani.com/lesson/queue",
            WANIKANI_LESSON_COMPLETE_URI = "https://www.wanikani.com/json/lesson/completed";

        private WaniKaniUser user;

        public WaniKaniLessonClient(WaniKaniUser user)
        {
            this.user = user;
        }

        public async Task<WaniKaniLessonQueue> GetLessonQueueAsync()
        {
            string response =
                await WaniKaniHttpUtils.GetAuthenticatedStringResultAsync(
                    WANIKANI_LESSON_ENDPOINT_URI, user);

            return await Task<WaniKaniLessonQueue>.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<WaniKaniLessonQueue>
                ( response, new JsonLessonConverter()));
        }

        /// <summary>
        /// Notify WaniKani that this item has been learned
        /// </summary>
        /// <param name="card">The item that has been completed</param>
        public void CompleteItem(WaniKaniLessonCard card)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("keys[]", card.NamedID);

            WaniKaniHttpUtils.MakeAuthenticatedRequestForResultAsync(
                WANIKANI_LESSON_COMPLETE_URI, user, parameters);
        }
    }
}
