using System;
using System.Collections.Generic;
using System.Text;
using PSOmni.Domain;

namespace PSOmni.Interfaces;

/// <summary>Executes external commands and returns their results.</summary>
public interface ICommandRunner
{
    /// <summary>Runs a process asynchronously and returns the captured result.</summary>
    Task<CommandResult> RunAsync(
        string fileName,
        string arguments,
        CancellationToken cancellationToken = default);
}
