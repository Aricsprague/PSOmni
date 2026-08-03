using System;
using System.Collections.Generic;
using System.Text;
using PSOmniSync.Domain;

namespace PSOmniSync.Interfaces;

// Executes external commands and returns their results.
public interface ICommandRunner
{
    // Runs a process asynchronously and returns the captured result.
    Task<CommandResult> RunAsync(
        string fileName,
        string arguments,
        CancellationToken cancellationToken = default);
}