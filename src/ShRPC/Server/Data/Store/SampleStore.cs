using ShRPC.Shared.Entities;

namespace ShRPC.Server.Data.Store;

internal static class SampleStore
{

    internal static List<Sample>  GetValues()
    {
        return new()
        {
            new Sample
            {
                Id = 1,
                Name = "Object 1",
                Value = 11
            },
            new Sample
            {
                Id = 2,
                Name = "Object 2",
                Value = 7
            },
            new Sample
            {
                Id = 3,
                Name = "Object 3",
                Value = 59
            },
            new Sample
            {
                Id = 4,
                Name = "Object 4",
                Value = 37
            },
            new Sample
            {
                Id = 5,
                Name = "Object 5",
                Value = 71
            },
            new Sample
            {
                Id = 6,
                Name = "Object 6",
                Value = 5
            },
            new Sample
            {
                Id = 7,
                Name = "Object 7",
                Value = 21
            },
            new Sample
            {
                Id = 8,
                Name = "Object 8",
                Value = 42
            },
            new Sample
            {
                Id = 9,
                Name = "Object 9",
                Value = 69
            },
            new Sample
            {
                Id = 10,
                Name = "Object 10",
                Value = 36
            },
            new Sample
            {
                Id = 11,
                Name = "Object 11",
                Value = 21
            },
            new Sample
            {
                Id = 12,
                Name = "Object 12",
                Value = 59
            },
            new Sample
            {
                Id = 13,
                Name = "Object 13",
                Value = 36
            },
            new Sample
            {
                Id = 14,
                Name = "Object 14",
                Value = 21
            },
            new Sample
            {
                Id = 15,
                Name = "Object 15",
                Value = 11
            }
        };
    }
}
