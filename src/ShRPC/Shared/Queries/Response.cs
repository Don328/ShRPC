using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShRPC.Shared.Queries;
public class Response<T> where T : class
{
    private readonly bool _isList;
    private T? _value;
    private IEnumerable<T>? _values;

    public Response(bool isList)
    {
        _isList = isList;
    }

    public bool IsList { get => _isList; }
    
    public T? Value { 
        get
        {
            return _value;
        }
        set 
        {
            if (!_isList)
            {
                _value = value;
            }
        }
            }
    
    public IEnumerable<T>? Values 
    { 
        get
        {
            return _values;
        }
        set
        {
            if (_isList)
            {
                _values = value;
            }
        }
    }

    public static Response<T> Fail()
    {
        return new Response<T>(false);
    }
}
