using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Interfaces;

/// <summary>Service responsible for application startup and initialization tasks.</summary>
public interface IStartupService
{
    /// <summary>Performs startup initialization and returns true when initialization succeeds.</summary>
    Task<bool> InitializeAsync();
}
