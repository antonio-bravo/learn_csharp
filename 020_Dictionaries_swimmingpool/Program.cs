using System;
using System.Collections.Generic;
using System.Linq;

public enum PoolTypeEnum
{
    RECREATION,
    COMPETITION,
    THERMAL,
    KIDS
};

class Program
{
    private static Random random = new Random();

    private static bool GetRandomBoolean()
    {
        return random.Next(2) == 1;
    }

    static void Main(string[] args)
    {
        Dictionary<PoolTypeEnum, HashSet<int>> tickets =
            new Dictionary<PoolTypeEnum, HashSet<int>>()
            {
                { PoolTypeEnum.RECREATION, new HashSet<int>() },
                { PoolTypeEnum.COMPETITION, new HashSet<int>() },
                { PoolTypeEnum.THERMAL, new HashSet<int>() },
                { PoolTypeEnum.KIDS, new HashSet<int>() }
            };

        for (int i = 1; i < 100; i++)
        {
            foreach (KeyValuePair<PoolTypeEnum, HashSet<int>> type in tickets)
            {
                if (GetRandomBoolean())
                {
                    type.Value.Add(i);
                }
            }
        }

        Console.WriteLine("Number of visitors by pool type:");
        foreach (KeyValuePair<PoolTypeEnum, HashSet<int>> type in tickets)
        {
            Console.WriteLine($" - {type.Key.ToString().ToLower()}: {type.Value.Count}");
        }

        PoolTypeEnum maxVisitors = tickets
            .OrderByDescending(t => t.Value.Count)
            .Select(t => t.Key)
            .FirstOrDefault();
        Console.WriteLine($"Pool '{maxVisitors.ToString().ToLower()}' was the most popular.");

        HashSet<int> any =
            new HashSet<int>(tickets[PoolTypeEnum.RECREATION]);
        any.UnionWith(tickets[PoolTypeEnum.COMPETITION]);
        any.UnionWith(tickets[PoolTypeEnum.THERMAL]);
        any.UnionWith(tickets[PoolTypeEnum.KIDS]);
        Console.WriteLine($"{any.Count} people visited at least one pool.");

        HashSet<int> all =
            new HashSet<int>(tickets[PoolTypeEnum.RECREATION]);
        all.IntersectWith(tickets[PoolTypeEnum.COMPETITION]);
        all.IntersectWith(tickets[PoolTypeEnum.THERMAL]);
        all.IntersectWith(tickets[PoolTypeEnum.KIDS]);
        Console.WriteLine($"{all.Count} people visited all pools.");
    }
}
