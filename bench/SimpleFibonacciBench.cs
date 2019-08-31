using System.Numerics;

namespace bench
{
    public class SimpleFibonacciBench : AbstractBench
    {
        public override BenchResult<object> doBenchmark(params string[] args)
        {
            long maxInterations = long.Parse(args[0]);

            BigInteger result = calculateNext(BigInteger.Zero, BigInteger.One, maxInterations);

            return new BenchResult<object>(result);

        }

        private BigInteger calculateNext(BigInteger previous, BigInteger current, long maxInterations)
        {
            return calculateNext(previous, current, maxInterations, 1);
        }

        private BigInteger calculateNext(BigInteger previous, BigInteger current, long maxInterations, long currentInteration)
        {
            ++currentInteration;

            var result = BigInteger.Add(previous, current);

            if(currentInteration == maxInterations)
            {
                return result;
            }
            else
            {
                return calculateNext(current, result, maxInterations, currentInteration);
            }

        }

    }
}