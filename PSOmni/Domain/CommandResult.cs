using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Domain;

/// <summary>Result information produced by running an external command.</summary>
public class CommandResult
{
    /// <summary>Process exit code returned by the executed command.</summary>
    public int ExitCode { get; init; }

    /// <summary>Captured standard output from the command.</summary>
    public string StandardOutput { get; init; } = "";

    /// <summary>Captured standard error output from the command.</summary>
    public string StandardError { get; init; } = "";

    /// <summary>Indicates whether the command completed successfully (exit code 0).</summary>
    public bool Success => ExitCode == 0;
}
