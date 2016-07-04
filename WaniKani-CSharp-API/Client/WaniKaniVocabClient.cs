using Ddoodm.WaniKani.HttpUtils;
using Ddoodm.WaniKani.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.Client
{
    public class WaniKaniVocabClient : WaniKaniPrivateJsonApiClient<WaniKaniVocabWord>
    {
        private const string
            WANIKANI_VOCAB_API_ENDPOINT = "https://www.wanikani.com/json/vocabulary";

        public WaniKaniVocabClient(WaniKaniUser user)
            : base(WANIKANI_VOCAB_API_ENDPOINT, user)
        {
            
        }

        public WaniKaniVocabWord GetVocabWord(int id)
        {
            return base.QueryEndpointForItem(id);
        }
    }
}
