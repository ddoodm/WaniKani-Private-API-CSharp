using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani
{
    public class WaniKaniUser
    {
        public Cookie SessionCookie { get; protected set; }

        public WaniKaniUser(Cookie sessionCookie)
        {
            this.SessionCookie = sessionCookie;
        }
    }
}
