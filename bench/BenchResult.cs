namespace bench
{
public class BenchResult<T>{

    public T value { get; set; }

    public BenchResult(T value)
    {
        this.value = value;
    }

    public long RunningMilliseconds { get; set; }

}
}