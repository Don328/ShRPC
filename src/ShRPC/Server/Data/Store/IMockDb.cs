namespace ShRPC.Server.Data.Store;

public interface IMockDb<T> where T : class
{
    public IEnumerable<T>? Values { get; }
}
