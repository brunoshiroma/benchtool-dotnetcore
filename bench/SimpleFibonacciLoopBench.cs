using System.Numerics;

namespace bench
{
    public class SimpleFibonacciLoopBench : AbstractBench
    {
        public override BenchResult<object> doBenchmark(params string[] args)
        {
            long maxInterations = long.Parse(args[0]);

            BigInteger result = Calculate(maxInterations);

            return new BenchResult<object>(result);
        }

        private BigInteger Calculate(long maxInterations)
        {
            var currentValue = new BigInteger(0);
            var nextValue = new BigInteger(1);
            var resultSum = new BigInteger();

            for(var i = 1; i < maxInterations; i++)
            {
                resultSum = currentValue + nextValue;

                currentValue = nextValue;
                nextValue = resultSum;
            }

            return resultSum;
        }


    }
}