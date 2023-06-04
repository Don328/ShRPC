using Microsoft.AspNetCore.Components;
using ShRPC.Shared.Entities;

namespace ShRPC.Client.Components;

public partial class SampleDetails : ComponentBase
{
    [Parameter]
    public Sample Sample { get; set; } = Sample.Default();

}
