using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ddoodm.WaniKani
{
    public class WaniKaniReviewQueue
    {
        private List<WaniKaniReviewCard> reviewCards;

        public WaniKaniReviewQueue(List<WaniKaniReviewCard> reviewCards)
        {
            this.reviewCards = reviewCards;
        }
    }

    public class WaniKaniReviewCard
    {

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class WaniKaniReviewVocabCard : WaniKaniReviewCard
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "voc")]
        public string VocabWord { get; set; }
        [JsonProperty(PropertyName = "srs")]
        public int SRSLevel { get; set; }
        [JsonProperty(PropertyName = "en")]
        public string[] EnglishMeanings { get; set; }
        [JsonProperty(PropertyName = "kana")]
        public string[] KanaReadings { get; set; }
        [JsonProperty(PropertyName = "aud")]
        public string AudioClipURL { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class WaniKaniReviewKanjiCard : WaniKaniReviewCard
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "kan")]
        public string Kanji { get; set; }
        [JsonProperty(PropertyName = "srs")]
        public int SRSLevel { get; set; }
        [JsonProperty(PropertyName = "en")]
        public string[] EnglishMeanings { get; set; }
        [JsonProperty(PropertyName = "kun")]
        public string[] KunyomiReadings { get; set; }
        [JsonProperty(PropertyName = "on")]
        public string[] OnyomiReadings { get; set; }
        [JsonProperty(PropertyName = "emph")]
        public string PreferredReading { get; set; }
        [JsonProperty(PropertyName = "nanori")]
        public string[] Nanori { get; set; }
        [JsonProperty(PropertyName = "syn")]
        public string[] Syn { get; set; }
    }
}
