using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmniSync.Domain;

// Result information produced by running an external command.
public class CommandResult
{
    // Process exit code returned by the executed command.
    public int ExitCode { get; init; }

    // Captured standard output from the command.
    public string StandardOutput { get; init; } = "";

    // Captured standard error output from the command.
    public string StandardError { get; init; } = "";

    // Indicates whether the command completed successfully (exit code 0).
    public bool Success => ExitCode == 0;
}