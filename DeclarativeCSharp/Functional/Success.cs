using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeCSharp.Functional
{
    public struct Success<T>
    {
        private readonly T value;
        public Success(T value) => this.value = value;
        public void Deconstruct(out T res) => res = value;
    }
}
