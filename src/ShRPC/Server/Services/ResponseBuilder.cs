using ShRPC.Shared.Queries;

namespace ShRPC.Server.Services;

public class ResponseBuilder<T> where T : class
{
    private readonly Response<T> _response;

    public ResponseBuilder(bool resultIsList)
    {
        _response = new Response<T>(resultIsList);
    }

    public Response<T> Build()
    {
        return _response;
    }

    public ResponseBuilder<T> WithValue(T value)
    {
        _response.Value = value;
        return this;
    }

    public ResponseBuilder<T> WithValues(IEnumerable<T> values)
    {
        _response.Values = values;
        return this;
    }
}
