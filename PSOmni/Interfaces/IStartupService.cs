using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmniSync.Interfaces;

// Service responsible for application startup and initialization tasks.
public interface IStartupService
{
    // Performs startup initialization and returns true when initialization succeeds.
    Task<bool> InitializeAsync();
}
