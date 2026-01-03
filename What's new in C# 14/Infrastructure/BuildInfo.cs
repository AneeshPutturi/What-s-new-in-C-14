using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace What_s_new_in_C__14.Infrastructure;

internal static class BuildInfo
{
    public static string TargetFramework =>
        Assembly.GetExecutingAssembly()
            .GetCustomAttributes<TargetFrameworkAttribute>()
            .FirstOrDefault()?.FrameworkName ?? "unknown";

    public static string LangVersion =>
        Assembly.GetExecutingAssembly()
            .GetCustomAttributes<AssemblyMetadataAttribute>()
            .FirstOrDefault(m => m.Key == "LangVersion")?.Value ?? "unknown";

    public static string RuntimeDescription => System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;

    public static string SdkVersion => TryReadSdkVersion();

    private static string TryReadSdkVersion()
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "--version",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var proc = Process.Start(psi)!;
            proc.WaitForExit(3000);
            if (proc.ExitCode == 0)
            {
                var output = proc.StandardOutput.ReadToEnd().Trim();
                return string.IsNullOrWhiteSpace(output) ? "unknown" : output;
            }

            return $"unknown (exit {proc.ExitCode})";
        }
        catch (Exception ex)
        {
            return $"unknown ({ex.GetType().Name})";
        }
    }
}

