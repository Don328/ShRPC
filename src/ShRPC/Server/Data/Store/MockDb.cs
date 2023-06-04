using ShRPC.Shared.Entities;

namespace ShRPC.Server.Data.Store;

internal class MockDb<T> : IMockDb<T> where T : class
{
    private Type _type = typeof(T);

    public MockDb()
    {
        if (_type == typeof(Sample))
        {
            Values = (IEnumerable<T>)SampleStore.GetValues().AsEnumerable();
        }
    }

    public IEnumerable<T>? Values { get; }
}
