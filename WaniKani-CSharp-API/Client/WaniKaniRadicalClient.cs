using Ddoodm.WaniKani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.Client
{
    public class WaniKaniRadicalClient : WaniKaniPrivateJsonApiClient<WaniKaniRadical>
    {
        private const string
            WANIKANI_RADICAL_API_ENDPOINT = "https://www.wanikani.com/json/radical";

        public WaniKaniRadicalClient(WaniKaniUser user)
            : base(WANIKANI_RADICAL_API_ENDPOINT, user)
        {

        }

        public WaniKaniRadical GetRadical(int id)
        {
            return base.QueryEndpointForItem(id);
        }
    }
}
