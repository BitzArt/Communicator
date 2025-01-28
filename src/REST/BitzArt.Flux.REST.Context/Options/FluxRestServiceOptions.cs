using System.Text.Json;

namespace BitzArt.Flux.REST;

internal class FluxRestServiceOptions(string? baseUrl)
{
    public string? BaseUrl { get; set; } = baseUrl;

    public JsonSerializerOptions SerializerOptions { get; set; } = new();

    // TODO: review method name
    public string GetFullPath(string path)
    {
        if (BaseUrl is null) return path;
        return $"{BaseUrl.TrimEnd('/')}/{path.TrimStart('/')}";
    }
}
