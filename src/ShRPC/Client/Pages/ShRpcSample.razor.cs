using Microsoft.AspNetCore.Components;
using ShRPC.Shared.Entities;
using ShRPC.Shared.Queries;
using ShRPC.Shared.Queries.Builders;
using System.Net.Http.Json;

namespace ShRPC.Client.Pages;

public partial class ShRpcSample : ComponentBase
{
    [Inject]
    public HttpClient? Http { get; set; }

    private IEnumerable<Sample>? _samples = null;
    private Sample _sample = Sample.Default();
    private SampleQuery _queryModel = new(0);
    private bool _retainValues = false;

    protected override async Task OnInitializedAsync()
    {
        await OnSelectAll();
    }

    private async Task OnSelectAll()
    {
        var query = new SampleQueryBuilder(
            SampleQuery.Query_Type.GetAll)
            .Build(out bool success);
        if (success)
        {
            await PostQuery(query);
            _sample = Sample.Default();
        }
    }

    private async Task OnSelectId()
    {
        var query = new SampleQueryBuilder(
            SampleQuery.Query_Type.ById)
                .ById(_queryModel.Id)
                .Build(out bool success);

        if (success)
        {
            await PostQuery(query);
            _samples = Enumerable.Empty<Sample>();
        }
    }

    private async Task OnSelectName()
    {
        var query = new SampleQueryBuilder(
            SampleQuery.Query_Type.ByName)
                .ByName(_queryModel.Name)
                .Build(out bool success);

        if (success)
        {
            await (PostQuery(query));
            _samples = Enumerable.Empty<Sample>();
        }
    }

    private async Task OnSelectByValue()
    {
        var query = new SampleQueryBuilder(
            SampleQuery.Query_Type.ByValue)
                .ByValue(_queryModel.Value ?? 0)
                .Build(out bool success);

        if (success)
        {
            await (PostQuery(query));
            _sample = Sample.Default();
        }
    }

    private async Task OnSelectGreaterThan()
    {
        var query = new SampleQueryBuilder(
            SampleQuery.Query_Type.ByValue_GT)
                .ByValue_GT(
                    _queryModel.GT_Value ?? int.MinValue)
                .Build(out bool success);

        if (success)
        {
            await (PostQuery(query));
            _sample = Sample.Default();
        }
    }
    private async Task OnSelectLessThan()
    {
        var query = new SampleQueryBuilder(
            SampleQuery.Query_Type.ByValue_LT)
                .ByValue_LT(
                    _queryModel.LT_Value ?? int.MaxValue)
                .Build(out bool success);

        if (success)
        {
            await (PostQuery(query));
            _sample = Sample.Default();
        }
    }

    private async Task OnSelectRange()
    {
        var query = new SampleQueryBuilder(
            SampleQuery.Query_Type.ByRange)
                .ByRange(
                    greaterThan: _queryModel.GT_Value ?? int.MinValue,
                    lessThan: _queryModel.LT_Value ?? int.MaxValue)
                .Build(out bool success);

        if (success)
        {
            await (PostQuery(query));
            _sample = Sample.Default();
        }
    }

    private async Task PostQuery(SampleQuery query)
    {
        if (Http is not null)
        {
            var httpResult = await Http.PostAsJsonAsync<SampleQuery>("sample", query);

            if (httpResult.IsSuccessStatusCode)
            {
                var result = await httpResult.Content.ReadFromJsonAsync(typeof(Response<Sample>));
                if (result != null)
                {
                    var response = (Response<Sample>)result;

                    if (response.IsList)
                    {
                        _samples = response.Values;
                    }

                    if (!response.IsList)
                    {
                        _sample = response.Value?? Sample.Default();
                    }
                }
            }

            RefreshQueryModel();
        }
    }

    private void ToggleRetainValues()
    {
        _retainValues = !_retainValues;
    }

    private void RefreshQueryModel()
    {
        var newQuery = new SampleQuery(0);
        if (_retainValues)
        {
            RetainQueryValues(newQuery);
        }

        _queryModel = newQuery;
    }

    private void RetainQueryValues(
    SampleQuery query)
    {
        query.Id = _queryModel.Id;
        query.Name = _queryModel.Name;
        query.Value = _queryModel.Value;
        query.GT_Value = _queryModel.GT_Value;
        query.LT_Value = _queryModel.LT_Value;
    }
}
