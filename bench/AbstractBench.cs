using System.Diagnostics;

namespace bench
{
    public abstract class AbstractBench : IBench
    {
        public BenchResult<object> run(params string[] args)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            var result = doBenchmark(args);
            stopWatch.Stop();

            result.RunningMilliseconds = stopWatch.ElapsedMilliseconds;

            return result;
        }

        public abstract BenchResult<object> doBenchmark(params string[] args);
    }

}