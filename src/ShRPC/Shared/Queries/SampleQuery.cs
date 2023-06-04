using ShRPC.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShRPC.Shared.Queries.SampleQuery;

namespace ShRPC.Shared.Queries;
public class SampleQuery
{
    public enum Query_Type
    {
        Invalid,
        GetAll,
        ById,
        ByName,
        ByValue,
        ByValue_GT,
        ByValue_LT,
        ByRange,
    }

    public SampleQuery(
        Query_Type queryType)
    {
        QueryType = queryType;
    }

    public Query_Type QueryType { get; }
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int? Value { get; set; }
    public int? GT_Value { get; set; }
    public int? LT_Value { get; set; }
    public string? ErrorMessage { get; set; }

    public Type GetResponseType()
    {
        return QueryType switch
        {
            Query_Type.Invalid => typeof(object),
            Query_Type.GetAll => typeof(IEnumerable<Sample>),
            Query_Type.ById => typeof(Sample),
            Query_Type.ByName => typeof(Sample),
            Query_Type.ByValue => typeof(IEnumerable<Sample>),
            Query_Type.ByValue_GT => typeof(IEnumerable<Sample>),
            Query_Type.ByValue_LT => typeof(IEnumerable<Sample>),
            Query_Type.ByRange => typeof(IEnumerable<Sample>),
            _ => typeof(object),
        };
    }
}
