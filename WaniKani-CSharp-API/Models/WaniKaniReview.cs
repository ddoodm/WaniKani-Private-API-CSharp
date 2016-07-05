using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ddoodm.WaniKani.Models
{
    public class WaniKaniReviewQueue
    {
        public List<WaniKaniReviewCard> Queue { get; private set; }

        public WaniKaniReviewQueue(List<WaniKaniReviewCard> reviewCards)
        {
            this.Queue = reviewCards;
        }
    }

    public abstract class WaniKaniReviewCard : WaniKaniArtifact
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "srs")]
        public int SRSLevel { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class WaniKaniReviewRadicalCard : WaniKaniReviewCard
    {
        [JsonProperty(PropertyName = "en")]
        public string[] EnglishNames { get; set; }
        [JsonProperty(PropertyName = "rad")]
        public string Radical { get; set; }
        [JsonProperty(PropertyName = "syn")]
        public string[] Unknown_Syn { get; set; }
        [JsonProperty(PropertyName = "custom_font_name")]
        public string CustomFontName { get; set; }

        public override string NamedID
        {
            get
            {
                return String.Format("r{0}", ID);
            }
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class WaniKaniReviewVocabCard : WaniKaniReviewCard
    {
        [JsonProperty(PropertyName = "voc")]
        public string VocabWord { get; set; }
        [JsonProperty(PropertyName = "en")]
        public string[] EnglishMeanings { get; set; }
        [JsonProperty(PropertyName = "kana")]
        public string[] KanaReadings { get; set; }
        [JsonProperty(PropertyName = "aud")]
        public string AudioClipURL { get; set; }

        public override string NamedID
        {
            get
            {
                return String.Format("v{0}", ID);
            }
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class WaniKaniReviewKanjiCard : WaniKaniReviewCard
    {
        [JsonProperty(PropertyName = "kan")]
        public string Kanji { get; set; }
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

        public override string NamedID
        {
            get
            {
                return String.Format("k{0}", ID);
            }
        }
    }
}
