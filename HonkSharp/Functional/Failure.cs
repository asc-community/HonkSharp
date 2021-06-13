using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonkSharp.Functional
{
    public readonly struct Failure
    {
        
    }
    
    public readonly struct Failure<TReason>
    {
        public TReason Reason { get; }

        public Failure(TReason reason)
            => Reason = reason;
    }
}
