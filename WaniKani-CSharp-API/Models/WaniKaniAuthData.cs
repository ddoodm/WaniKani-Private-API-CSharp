using System.Net;

namespace Ddoodm.WaniKani.Models
{
    internal class WaniKaniAuthData
    {
        public string AuthenticityToken { get; private set; }
        public Cookie WaniKaniSessionCookie { get; private set; }

        public WaniKaniAuthData(string authenticityToken, Cookie waniKaniSessionCookie)
        {
            this.AuthenticityToken = authenticityToken;
            this.WaniKaniSessionCookie = waniKaniSessionCookie;
        }
    }
}