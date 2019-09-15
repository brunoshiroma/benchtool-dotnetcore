using System;
using bench;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace benchtool_dotnetcore
{
    class Program
    {
        static void Main(string[] args)
        {

            var loopCount = "99999";

            IBench bench = null;

            Thread runnerThread = null;

            BenchResult<Object> result = null;

            int executionCount = 5;

            List<BenchResult<Object>> results = new List<BenchResult<object>>();

            if(args?.Length >= 2){
                loopCount = args[1];
                int benchType = int.Parse(args[0]);

                if(args?.Length >= 3 )
                {
                    executionCount = int.Parse(args[2]);
                }

                switch(benchType){
                    case 1:
                        bench = new SimpleFibonacciLoopBench();
                        runnerThread = new Thread(()=>{
                            for(int i = 0; i < executionCount; i++){
                                result = bench.run(loopCount);
                                results.Add(result);
                            }
                        });
                        break;
                    default:    
                        bench = new SimpleFibonacciBench();
                        runnerThread = new Thread(()=>{
                            for(int i = 0; i < executionCount; i++){
                                result = bench.run(loopCount);
                                results.Add(result);
                            }
                        }, 1024 * 1024 * 1024);//changes the thread stack size for the recursive
                        break;
                }

            }
            else
            {
                bench = new SimpleFibonacciLoopBench();

                runnerThread = new Thread(()=>{
                    for(int i = 0; i < executionCount; i++){
                        result = bench.run(loopCount);
                        results.Add(result);
                    }
                });
            }

            runnerThread.Start();
            runnerThread.Join();

            var totalMs = results
                .Sum( r => r.RunningMilliseconds);

            long averageMs = totalMs / executionCount;

            object rawResult = results[0].value;
            bool resultsOk = results.All( r => rawResult.ToString().Equals(r.value.ToString()));

            if(!resultsOk)
            {
                Console.WriteLine("Execution problem, not all results are ok ='(");
                Environment.Exit(-1);
            }

            Console.Write($"{averageMs} {rawResult.ToString()}");

        }
    }
}
