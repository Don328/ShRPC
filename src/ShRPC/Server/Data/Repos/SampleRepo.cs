using ShRPC.Server.Data.Store;
using ShRPC.Shared.Entities;

namespace ShRPC.Server.Data.Repos;

public class SampleRepo
{
    private readonly IMockDb<Sample> samples;

    public SampleRepo()
    {
        samples = new MockDb<Sample>();
    }

    internal List<Sample> GetAll()
    {
        return SampleStore.GetValues();
    }

    internal Sample GetById(int id) 
    {
        return (from s in samples.Values
                where s.Id == id
                select s).FirstOrDefault()?? Sample.Default();
    }

    internal Sample GetByName(string name)
    {
        return (from s in samples.Values
                where s.Name == name
                select s).FirstOrDefault() ?? Sample.Default();
    }

    internal List<Sample> GetByValue(int value)
    {
        return (from s in samples.Values
                where s.Value == value
                select s).ToList();
    }

    internal List<Sample> GetByValue_GT(int value)
    {
        return (from s in samples.Values
                where s.Value > value
                select s).ToList();
    }

    internal List<Sample> GetByValue_LT(int value)
    {
        return (from s in samples.Values
                where s.Value < value
                select s).ToList();
    }

    internal List<Sample> GetInRange(int value_gt, int  value_lt)
    {
        return (from s in samples.Values
                where s.Value > value_gt
                && s.Value < value_lt
                select s).ToList();
    }
}
