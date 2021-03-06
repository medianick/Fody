using System;
using System.IO;

public static class AssemblyLocation
{
    public static string CurrentDirectory()
    {
        //Use codebase because location fails for unit tests.
        var assembly = typeof(AssemblyLocation).Assembly;
        var uri = new UriBuilder(string.IsNullOrEmpty(assembly.CodeBase) ? assembly.Location : assembly.CodeBase);
        if (uri.ToString().Contains("#"))
        {
            throw new NotSupportedException("'#' character in path is not supported while building projects containing Fody.");
        }

        var path = Uri.UnescapeDataString(uri.Path);

        return Path.GetDirectoryName(path);
    }
}