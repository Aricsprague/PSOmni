using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PSOmniSync.Domain;
using PSOmniSync.Interfaces;

namespace PSOmniSync.Infrastructure;

// Executes external processes and captures their output.
public class CommandRunner : ICommandRunner
{
    /// <summary>Runs a process asynchronously and returns the result including exit code and captured output.</summary>
    /// <param name="fileName">Path to the executable to run.</param>
    /// <param name="arguments">Arguments passed to the executable.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    public async Task<CommandResult> RunAsync(
        string fileName,
        string arguments,
        CancellationToken cancellationToken = default)
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = fileName,
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using Process process = new()
        {
            StartInfo = startInfo
        };

        StringBuilder stdout = new();
        StringBuilder stderr = new();

        process.OutputDataReceived += (_, e) =>
        {
            if (e.Data is not null)
                stdout.AppendLine(e.Data);
        };

        process.ErrorDataReceived += (_, e) =>
        {
            if (e.Data is not null)
                stderr.AppendLine(e.Data);
        };

        process.Start();

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        await process.WaitForExitAsync(cancellationToken);

        return new CommandResult
        {
            ExitCode = process.ExitCode,
            StandardOutput = stdout.ToString(),
            StandardError = stderr.ToString()
        };
    }
}