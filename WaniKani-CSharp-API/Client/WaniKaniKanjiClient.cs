using Ddoodm.WaniKani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.Client
{
    public class WaniKaniKanjiClient : WaniKaniPrivateJsonApiClient<WaniKaniKanji>
    {
        private const string
            WANIKANI_KANJI_API_ENDPOINT = "https://www.wanikani.com/json/kanji";

        public WaniKaniKanjiClient(WaniKaniUser user)
            : base(WANIKANI_KANJI_API_ENDPOINT, user)
        {

        }

        public WaniKaniKanji GetKanji(int id)
        {
            return base.QueryEndpointForItem(id);
        }
    }
}
