using Ddoodm.WaniKani.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.JsonUtils
{
    class WaniKaniSentenceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray sentencePairArray = JArray.Load(reader);

            List<WaniKaniSentence> sentences = new List<WaniKaniSentence>();
            foreach (JArray sentencePair in sentencePairArray)
                sentences.Add(new WaniKaniSentence()
                {
                    Japanese = sentencePair[0].Value<string>(),
                    English = sentencePair[1].Value<string>()
                });

            return sentences.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
