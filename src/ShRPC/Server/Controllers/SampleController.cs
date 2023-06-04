using Microsoft.AspNetCore.Mvc;
using ShRPC.Server.Data.Fixtures;
using ShRPC.Server.Data.Repos;
using ShRPC.Server.Services;
using ShRPC.Shared.Entities;
using ShRPC.Shared.Queries;

namespace ShRPC.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly SampleRepo _repo;

    public SampleController(SampleRepo repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public Response<Sample> Post(SampleQuery query)
    {
        bool isList = 
            query.GetResponseType() 
            == typeof(IEnumerable<Sample>);

        var builder = new ResponseBuilder<Sample>(isList);
        
        if (isList)
        {
            return builder
                .WithValues(
                    SampleFixture.GetEnumerable(
                        _repo, query)).Build();
        }
        else
        {
            return builder
                .WithValue(
                    SampleFixture.GetSingle(
                        _repo, query)).Build();
        }
    }
}
