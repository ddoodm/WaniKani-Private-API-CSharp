using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.JsonUtils
{
    public class JsonReviewConverter : Newtonsoft.Json.Converters.CustomCreationConverter<WaniKaniReviewCard>
    {
        public override WaniKaniReviewCard Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public WaniKaniReviewCard Create(Type objectType, JObject jObject)
        {
            if (jObject["voc"] != null)
                return new WaniKaniReviewVocabCard();
            if (jObject["kan"] != null)
                return new WaniKaniReviewKanjiCard();

            return null;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            var target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}
