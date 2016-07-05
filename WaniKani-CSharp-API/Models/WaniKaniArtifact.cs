using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddoodm.WaniKani.Models
{
    /// <summary>
    /// WaniKani often won't give all of the details about a particular item,
    /// so we take what we can get from a particular endpoint, and call it
    /// an 'artifact', or a 'part of an item'. Most (all?) item details
    /// are offered at the item detail endpoints for Radicals, Kanji and Vocab.
    /// </summary>
    public abstract class WaniKaniArtifact
    {
        /// <summary>
        /// A string variant of the item's ID which
        /// indicates the item's type as well as its ID.
        /// Used with the lesson completion API to
        /// specify which item was completed.
        /// 
        /// Example: r22
        /// </summary>
        public abstract string NamedID { get; }
    }
}
