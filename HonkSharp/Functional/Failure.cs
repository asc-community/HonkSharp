using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonkSharp.Functional
{
    /// <summary>
    /// A type representing failure with
    /// no visible reason.
    /// </summary>
    public readonly struct Failure
    {
        
    }
    
    /// <summary>
    /// A type representing failure with
    /// a specified reason
    /// </summary>
    public readonly struct Failure<TReason>
    {
#pragma warning disable 1591
        public TReason Reason { get; }
#pragma warning restore 1591

#pragma warning disable 1591
        public Failure(TReason reason)
#pragma warning restore 1591
            => Reason = reason;
    }
}
