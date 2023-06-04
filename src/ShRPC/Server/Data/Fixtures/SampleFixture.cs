using ShRPC.Server.Data.Repos;
using ShRPC.Shared.Entities;
using ShRPC.Shared.Queries;

namespace ShRPC.Server.Data.Fixtures;

internal static class SampleFixture
{
    internal static Sample GetSingle(
        SampleRepo repo,
        SampleQuery query)
    {
        return query.QueryType switch
        {
            SampleQuery.Query_Type.ById => repo.GetById(query.Id),
            SampleQuery.Query_Type.ByName => repo.GetByName(query.Name),
            _ => Sample.Default(),
        };
    }

    internal static IEnumerable<Sample> GetEnumerable(
        SampleRepo repo,
        SampleQuery query)
    {
        return query.QueryType switch
        {
            SampleQuery.Query_Type.GetAll => repo.GetAll(),    
            SampleQuery.Query_Type.ByValue => repo.GetByValue(
                query.Value ?? -1),
            SampleQuery.Query_Type.ByValue_GT => repo.GetByValue_GT(
                query.GT_Value ?? -1),
            SampleQuery.Query_Type.ByValue_LT => repo.GetByValue_LT(
                query.LT_Value ?? int.MaxValue),
            SampleQuery.Query_Type.ByRange => repo.GetInRange(
                query.GT_Value ?? -1,
                query.LT_Value ?? int.MaxValue),
            _ => Enumerable.Empty<Sample>()
        };
    }
}
