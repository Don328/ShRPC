using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShRPC.Shared.Queries.Builders;
public class SampleQueryBuilder
{
    private SampleQuery _query;

    public SampleQueryBuilder(
        SampleQuery.Query_Type queryType)
    {
        _query = new SampleQuery(queryType);
    }

    public SampleQuery Build(out bool success)
    {
        if (_query == null)
        {
            success = false;
            return new SampleQuery(0);
        }

        success = IsValid(_query);
        return _query;
    }

    public SampleQueryBuilder GetAll()
    {
        return this;
    }

    public SampleQueryBuilder ById(int id)
    {
        _query.Id = id;
        return this;
    }

    public SampleQueryBuilder ByName(string name)
    {
        _query.Name = name;
        return this;
    }

    public SampleQueryBuilder ByValue(int value)
    {
        _query.Value = value;
        return this;
    }

    public SampleQueryBuilder ByValue_GT(int value)
    {
        _query.GT_Value = value;
        return this;
    }

    public SampleQueryBuilder ByValue_LT(int value)
    {
        _query.LT_Value = value;
        return this;
    }

    public SampleQueryBuilder ByRange(int greaterThan, int lessThan)
    {
        _query.GT_Value = greaterThan;
        _query.LT_Value = lessThan;
        return this;
    }

    private static bool IsValid(SampleQuery query)
    {
        switch (query.QueryType)
        {
            case SampleQuery.Query_Type.Invalid:
                return false;
            case SampleQuery.Query_Type.GetAll:
                return true;
            case SampleQuery.Query_Type.ById:
                if (query.Id < 1)
                {
                    query.ErrorMessage = "Get by Id attempted. Id must not be null";
                    return false;
                }
                return true;
            case SampleQuery.Query_Type.ByName:
                if (string.IsNullOrEmpty(query.Name))
                {
                    query.ErrorMessage = "Get by Name attempted. Name must not be null";
                    return false;
                }
                return true;
            case SampleQuery.Query_Type.ByValue:
                if (query.Value is null)
                {
                    query.ErrorMessage = "Get by Value attempted. Value must not be null";
                    return false;
                }
                return true;
            case SampleQuery.Query_Type.ByValue_GT:
                if (query.GT_Value is null)
                {
                    query.ErrorMessage = "Get greater than attempted. Greater than value must not be null";
                    return false;
                }
                return true;
            case SampleQuery.Query_Type.ByValue_LT:
                if (query.LT_Value is null)
                {
                    query.ErrorMessage = "Get less than attempted. Less than value must not be null";
                    return false;
                }
                return true;
            case SampleQuery.Query_Type.ByRange:
                if (query.GT_Value is null || query.LT_Value is null)
                {
                    query.ErrorMessage = "Get in range attempted. Greater than and less than values must not be null";
                    return false;
                }
                return true;
        }

        return false;
    }
}
