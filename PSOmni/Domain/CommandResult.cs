using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Domain;

public class CommandResult
{
    public int ExitCode { get; init; }

    public string StandardOutput { get; init; } = "";

    public string StandardError { get; init; } = "";

    public bool Success => ExitCode == 0;
}