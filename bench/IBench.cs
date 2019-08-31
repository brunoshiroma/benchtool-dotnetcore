namespace bench
{

public interface IBench
{
    BenchResult<object> run(params string[] args);


    BenchResult<object> doBenchmark(params string[] args);
}

}