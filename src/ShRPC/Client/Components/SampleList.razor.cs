using Microsoft.AspNetCore.Components;
using ShRPC.Shared.Entities;

namespace ShRPC.Client.Components;

public partial class SampleList : ComponentBase
{
    [Parameter]
    public IEnumerable<Sample> Samples { get; set; }
        = Enumerable.Empty<Sample>();


}
