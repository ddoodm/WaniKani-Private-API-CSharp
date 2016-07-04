using Ddoodm.WaniKani.JsonUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WaniKaniVocabWord
    {
        public int ID { get; private set; }

        [JsonProperty(PropertyName = "level")]
        public string Level { get; set; }
        [JsonProperty(PropertyName = "meaning_explanation")]
        public string MeaningExplanation { get; set; }
        [JsonProperty(PropertyName = "reading_explanation")]
        public string ReadingExplanation { get; set; }
        [JsonProperty(PropertyName = "en")]
        public string EnglishMeaning { get; set; }
        [JsonProperty(PropertyName = "kana")]
        public string KanaReadings { get; set; }
        [JsonProperty(PropertyName = "part_of_speech")]
        public string PartOfSpeech { get; set; }
        [JsonProperty(PropertyName = "audio")]
        public string AudioUrl { get; set; }

        [JsonProperty(PropertyName = "sentences")]
        [JsonConverter(typeof(WaniKaniSentenceConverter))]
        public WaniKaniSentence[] Sentences { get; set; }

        [JsonProperty(PropertyName = "meaning_note")]
        public string UserMeaningNote { get; set; }
        [JsonProperty(PropertyName = "reading_note")]
        public string UserReadingNote { get; set; }

        [JsonProperty(PropertyName = "related")]
        public WaniKaniVocabWordExtension[] Related { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class WaniKaniVocabWordExtension
    {
        [JsonProperty(PropertyName = "kan")]
        public string Kanji { get; set; }

        [JsonProperty(PropertyName = "en")]
        public string English { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }
    }
}
