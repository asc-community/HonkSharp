using System;
using System.Collections.Generic;
using System.Text;

namespace HonkSharp.Functional
{
    /// <summary>
    /// The most basic type, extendable
    /// replacement for C#'s void.
    /// </summary>
    public struct Unit
    {
        /// <summary>
        /// Same as new Unit(). Starts a flow
        /// </summary>
        // ReSharper disable once UnassignedField.Global
        public static Unit Flow;

        /// <summary>
        /// Return this when nothing needs to be returned.
        /// </summary>
        public static Unit Void;
    }
}
