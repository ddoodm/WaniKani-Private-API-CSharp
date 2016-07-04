using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WaniKaniKanji
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "level")]
        public string Level { get; set; }
        [JsonProperty(PropertyName = "reading_mnemonic")]
        public string ReadingMnemonic { get; set; }
        [JsonProperty(PropertyName = "reading_hint")]
        public string ReadingHint { get; set; }
        [JsonProperty(PropertyName = "meaning_mnemonic")]
        public string MeaningMnemonic { get; set; }
        [JsonProperty(PropertyName = "meaning_hint")]
        public string MeaningHint { get; set; }

        [JsonProperty(PropertyName = "en")]
        public string English { get; set; }

        [JsonProperty(PropertyName = "reading_note")]
        public string UserReadingNote { get; set; }
        [JsonProperty(PropertyName = "meaning_note")]
        public string UserMeaningNote { get; set; }

        // TODO: Implement related
        /*
            "related": [
            {
              "rad": "七",
              "en": "Seven",
              "slug": "seven",
              "custom_font_name": null
            }
          ],
        */
    }
}
