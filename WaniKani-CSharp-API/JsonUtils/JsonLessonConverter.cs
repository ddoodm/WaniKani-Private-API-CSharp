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
    public class JsonLessonConverter : Newtonsoft.Json.Converters.CustomCreationConverter<WaniKaniLessonCard>
    {
        public override WaniKaniLessonCard Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public WaniKaniLessonCard Create(Type objectType, JObject jObject)
        {
            if (jObject["rad"] != null)
                return new WaniKaniRadicalLessonCard();
            if (jObject["kan"] != null)
                return new WaniKaniKanjiLessonCard();
            throw new NotImplementedException();
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
