using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShRPC.Shared.Entities;
public class Sample
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Value { get; set; }
    public bool IsDefault => Value < 0;

    public static Sample Default() => new Sample 
        { Id = 0, Name = "Empty", Value = -1 };
}
