using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WaniKaniRadical
    {
        public int ID { get; private set; }

        [JsonProperty(PropertyName = "level")]
        public string Level { get; set; }
        [JsonProperty(PropertyName = "mnemonic")]
        public string Mnemonic { get; set; }
        [JsonProperty(PropertyName = "en")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "rad")]
        public string Radical { get; set; }
        [JsonProperty(PropertyName = "custom_font_name")]
        public string CustomFontName { get; set; }

        [JsonProperty(PropertyName = "meaning_note")]
        public string UserMeaningNote { get; set; }
    }
}
