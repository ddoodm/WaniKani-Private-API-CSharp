using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace Ddoodm.WaniKani.Models
{
    public struct WaniKaniSentence
    {
        public string English { get; set; }
        public string Japanese { get; set; }
    }
}
