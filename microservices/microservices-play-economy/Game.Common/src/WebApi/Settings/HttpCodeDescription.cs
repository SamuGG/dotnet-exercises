namespace Game.Common.WebApi.Settings;

public class HttpCodeDescription
{
    #pragma warning disable CS8618
    public Uri ServiceUrl { get; set; }
    #pragma warning restore CS8618

    public string? Http500InternalServerError { get; set; }
    public string? Http400BadRequest { get; set; }
    public string? Http404NotFound { get; set; }
}