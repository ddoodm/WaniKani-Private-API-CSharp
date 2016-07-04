using Ddoodm.WaniKani.HttpUtils;
using Ddoodm.WaniKani.JsonUtils;
using Ddoodm.WaniKani.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            WANIKANI_LESSON_ENDPOINT_URI = "https://www.wanikani.com/lesson/queue";

        public WaniKaniLessonQueue GetLessonsFor(WaniKaniUser user)
        {
            string response =
                WaniKaniHttpUtils.GetAuthenticatedStringResult(
                    WANIKANI_LESSON_ENDPOINT_URI, user);

            return JsonConvert.DeserializeObject<WaniKaniLessonQueue>
                ( response, new JsonLessonConverter());
        }
    }
}
