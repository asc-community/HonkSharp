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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override string ToString() => "Failure";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
    
    /// <summary>
    /// A type representing failure with
    /// a specified reason
    /// </summary>
    public readonly struct Failure<TReason>
    {
#pragma warning disable 1591
        public TReason Reason { get; }
        public Failure(TReason reason)
            => Reason = reason;

        public override string ToString() => $"Failure (reason: {Reason?.ToString() ?? "null"})";
#pragma warning restore 1591
    }
}
