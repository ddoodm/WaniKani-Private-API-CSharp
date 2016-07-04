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

    public abstract class WaniKaniLessonCard
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        /// <summary>
        /// A string variant of the item's ID which
        /// indicates the item's type as well as its ID.
        /// Used with the lesson completion API to
        /// specify which item was completed.
        /// 
        /// Example: r22
        /// </summary>
        public abstract string NamedID { get; }
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
}
