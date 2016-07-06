using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.Models
{
    public class WaniKaniLessonQueue
    {
        [JsonProperty(PropertyName = "queue")]
        public List<WaniKaniLessonCard> Queue { get; set; }
    }

    public abstract class WaniKaniLessonCard : WaniKaniArtifact
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
    }

    public class WaniKaniRadicalLessonCard : WaniKaniLessonCard
    {
        [JsonProperty(PropertyName = "rad")]
        public string Radical { get; set; }

        [JsonProperty(PropertyName = "custom_font_name")]
        public string CustomFontName { get; set; }
        [JsonProperty(PropertyName = "en")]
        public string[] EnglishNames { get; set; }
        [JsonProperty(PropertyName = "mmne")]
        public string Mnemonic { get; set; }

        [JsonProperty(PropertyName = "kanji")]
        public SimpleKanjiDetails[] UsedInKanji { get; set; }

        public override string NamedID
        {
            get
            {
                return String.Format("r{0}", ID);
            }
        }

        public struct SimpleKanjiDetails
        {
            [JsonProperty(PropertyName = "en")]
            public string PrimaryEnglishMeaning { get; set; }
            [JsonProperty(PropertyName = "kan")]
            public string Kanji { get; set; }
            [JsonProperty(PropertyName = "kana")]
            public string PrimaryKanaReading { get; set; }
            [JsonProperty(PropertyName = "slug")]
            public string Slug { get; set; }
        }
    }

    public class WaniKaniKanjiLessonCard : WaniKaniLessonCard
    {
        [JsonProperty(PropertyName = "kan")]
        public string Kanji { get; set; }
        [JsonProperty(PropertyName = "en")]
        public string[] EnglishMeanings { get; set; }

        [JsonProperty(PropertyName = "kun")]
        public string[] KunyomiReadings { get; set; }
        [JsonProperty(PropertyName = "on")]
        public string[] OnyomiReadings { get; set; }
        [JsonProperty(PropertyName = "nanori")]
        public string[] NanoriReadings { get; set; }
        [JsonProperty(PropertyName = "emph")]
        public string PreferredReading { get; set; }

        [JsonProperty(PropertyName = "mmne")]
        public string MeaningMnemonic { get; set; }
        [JsonProperty(PropertyName = "mnhnt")]
        public string MeaningHint { get; set; }
        [JsonProperty(PropertyName = "rmne")]
        public string ReadingMnemonic { get; set; }
        [JsonProperty(PropertyName = "rhnt")]
        public string ReadingHint { get; set; }

        public override string NamedID
        {
            get
            {
                return String.Format("k{0}", ID);
            }
        }

        /*
        TODO:
        Implement related radical / kanji section
        */
    }
}
