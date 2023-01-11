using System.Collections.Specialized;
using System.Globalization;
using LaYumba.Functional;

namespace FunctionalProgramming.Exercises.Chapter03;

public class AppConfig
{
    private readonly NameValueCollection _source;

    public AppConfig(NameValueCollection source)
    {
        ArgumentNullException.ThrowIfNull(source);
        _source = source;
    }

    public Option<T> Get<T>(string key)
    {
        string? value = _source[key];
        return value is null
            ? F.None
            : F.Some((T)Convert.ChangeType(value, typeof(T), CultureInfo.DefaultThreadCurrentCulture));
    }

    public T Get<T>(string key, T defaultValue)
    {
        return Get<T>(key).Match(
            () => defaultValue,
            (value) => value);
    }
}