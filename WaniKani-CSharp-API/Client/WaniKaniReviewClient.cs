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
    public class WaniKaniReviewClient
    {
        private const string 
            WANIKANI_REVIEW_QUEUE_URI = "https://www.wanikani.com/review/queue";

        public async Task<WaniKaniReviewQueue> GetReviewsFor(WaniKaniUser user)
        {
            string response =
                await WaniKaniHttpUtils.GetAuthenticatedStringResultAsync(
                    WANIKANI_REVIEW_QUEUE_URI, user);

            var reviewQueue = JsonConvert
                .DeserializeObject<List<WaniKaniReviewCard>>(
                response,
                new JsonReviewConverter());
            return new WaniKaniReviewQueue(reviewQueue);
        }
    }
}
