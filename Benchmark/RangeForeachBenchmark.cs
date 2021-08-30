using BenchmarkDotNet.Attributes;
using HonkSharp.Fluency;
using System.Linq;

namespace Benchmark
{
    [DisassemblyDiagnoser(exportHtml: true, printSource: true)]
    public class RangeForeachBenchmark
    {
        [Params(10, 100, 1000)]
        public int N { get; set; } = 10;

        public int Inc { get; set; } = 1;


        [Benchmark(Baseline = true)]
        public int LoopFor()
        {
            var a = 0;
            var n = N;
            var inc = Inc;
            for (int i = 0; i < n; i += Inc)
                a += i;
            return a;
        }
        
        [Benchmark]
        public int LoopForeachEnumerable()
        {
            var a = 0;
            var n = N;
            foreach (var i in Enumerable.Range(0, n))
                a += i;
            return a;
        }

        [Benchmark]
        public int LoopForeachHonkRange()
        {
            var a = 0;
            var n = N;
            foreach (var i in 0..(n - 1))
                a += i;
            return a;
        }

        [Benchmark]
        public int LoopForeachHonkRangeRaw()
        {
            var a = 0;
            var n = N;
            var enumerator = (0..(n - 1)).GetEnumerator();
            while (enumerator.MoveNext())
                a += enumerator.Current;
            return a;
        }
    }
}
