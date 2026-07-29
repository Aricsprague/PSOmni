using System;
using System.Collections.Generic;
using System.Text;
using PSOmni.Domain;

namespace PSOmni.Interfaces;

public interface ICommandRunner
{
    Task<CommandResult> RunAsync(
        string fileName,
        string arguments,
        CancellationToken cancellationToken = default);
}