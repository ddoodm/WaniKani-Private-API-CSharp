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
    public class WaniKaniReviewClient
    {
        private const string 
            WANIKANI_REVIEW_QUEUE_URI = "https://www.wanikani.com/review/queue",
            WANIKANI_REVIEW_PROGRESS_URI = "https://www.wanikani.com/json/progress";

        private WaniKaniUser user;

        public WaniKaniReviewClient(WaniKaniUser user)
        {
            this.user = user;
        }

        public WaniKaniReviewQueue GetReviews()
        {
            string response =
                WaniKaniHttpUtils.GetAuthenticatedStringResult(
                    WANIKANI_REVIEW_QUEUE_URI, user);

            var reviewQueue = JsonConvert.DeserializeObject<List<WaniKaniReviewCard>>(
                response,
                new JsonReviewConverter()
                );
            return new WaniKaniReviewQueue(reviewQueue);
        }

        /// <summary>
        /// Up date the SRS state of a given review card
        /// </summary>
        /// <param name="card">The card to update</param>
        /// <param name="meaningFailures">Number of failed attempts (0 for success)</param>
        /// <param name="readingFailures">Number of failed attempts (0 for success)</param>
        public void UpdateItemProgress(WaniKaniReviewCard card, int meaningFailures, int readingFailures)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add(card.NamedID, meaningFailures.ToString());
            parameters.Add(card.NamedID, readingFailures.ToString());

            WaniKaniHttpUtils.MakeAuthenticatedWaniKaniRequest(
                WANIKANI_REVIEW_PROGRESS_URI, user, parameters);
        }
    }
}
