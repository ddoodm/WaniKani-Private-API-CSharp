using Ddoodm.WaniKani.HttpUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.Client
{
    public abstract class WaniKaniPrivateJsonApiClient<T>
    {
        protected string endpointUrl;
        protected WaniKaniUser user;

        protected WaniKaniPrivateJsonApiClient(string endpointUrl, WaniKaniUser user)
        {
            this.endpointUrl = endpointUrl;
            this.user = user;
        }

        protected async Task<T> QueryEndpointForItemAsync(int id)
        {
            // Query the WaniKani endpoint for the requested item
            string requestUri = String.Format("{0}/{1}", endpointUrl, id);
            var response = 
                await WaniKaniHttpUtils.MakeAuthenticatedRequestForResultAsync(requestUri, user);

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = await reader.ReadToEndAsync();

            return await Task<T>.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<T>(responseString));
        }
    }
}
