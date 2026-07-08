using HtmlAgilityPack;
using Microsoft.AspNetCore.WebUtilities;

class AnimeResult
{
    public string Name { get; set; } = "";
    public string Url { get; set; } = "";
}

public class Program
{
    private static HttpClient sharedClient = new() { BaseAddress = new Uri("https://hianime.ms/") };

    private static async Task<List<AnimeResult>> SearchAnime(string anime)
    {
        var queryParams = new Dictionary<string, string?> { { "q", @anime } };

        string fullUrl = QueryHelpers.AddQueryString(
            $"{sharedClient.BaseAddress}search",
            queryParams
        );

        using HttpResponseMessage response = await sharedClient.GetAsync(fullUrl);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();

        HtmlDocument doc = new();
        doc.LoadHtml(content);
        var itemList = doc.DocumentNode.SelectNodes("//div[@class='film-detail']"); // Returns an enumerable

        // Parse html
        List<AnimeResult> animeList = new();
        foreach (var item in itemList)
        {
            // NOTE: MUST add the "." prefix, otherwise the function will search the entire document, rather than relative the current node
            var link = item.SelectSingleNode(@".//a[@class='dynamic-name']");

            if (link != null)
            {
                animeList.Add(
                    new AnimeResult
                    {
                        Name = link.InnerText.Trim(),
                        Url = link.GetAttributeValue("href", ""),
                    }
                );
            }
        }

        return animeList;
    }

    public static async Task Main(string[] args)
    {
        List<AnimeResult> animeList = await SearchAnime("dan da dan");

        foreach (var anime in animeList)
        {
            Console.WriteLine($"Anime: {anime.Name}\nURL: {anime.Url}");
        }
    }
}
