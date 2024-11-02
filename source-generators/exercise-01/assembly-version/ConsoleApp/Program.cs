namespace ConsoleApp;

partial class Program
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060", Justification = "No args needed")]
    static void Main(string[] args)
    {
        GetAssemblyVersionFromReflection();
        GetAssemblyVersionFromSourceGenerator();
    }

    private static void GetAssemblyVersionFromReflection()
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
        Console.WriteLine($"Version from reflection: {fvi.FileVersion}");
    }

    static partial void GetAssemblyVersionFromSourceGenerator();
}