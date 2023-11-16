namespace Dionysus.Server.Application.Common.Shared;

using System.Diagnostics;
using System.Reflection;

public static class ServiceConstants
{
    private static readonly FileVersionInfo FileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
    public static string ServiceName => FileVersionInfo.ProductName!;
    public static string ServiceVersion => FileVersionInfo.ProductVersion!;
}
