namespace LeetCode.CSharp;

public class DestinationCity {
    string DestCity(IList<IList<string>> paths)
    {
        // dic< CITY, List of Out>
        var hashmap = new Dictionary<string, List<string>>();
        var citylist = new List<string>();

        foreach (var p in paths)
        {
            var from = p[0];
            var to = p[1];

            // Add city to cityList.
            if (!citylist.Contains(from))
                citylist.Add(from);
            if (!citylist.Contains(to))
                citylist.Add(to);

            // Register the path.
            if (hashmap.TryGetValue(from, out var destList))
            {
                if (destList.Contains(to)) continue;
                destList.Add(to);
                hashmap[from] = destList;
            }
            else
            {
                hashmap[from] = new List<string> { to };
            }
        }

        return citylist.Where(city => !hashmap.TryGetValue(city, out _)).FirstOrDefault() ?? "";
    }

    public void Test()
    {
        IList<IList<string>> input = new List<IList<string>>
        {
            new List<string> { "London", "New York" },
            new List<string> { "New York", "Lima" },
            new List<string> { "Lima", "Sao Paulo" }
        };

        Console.WriteLine(DestCity(input));
    }
}