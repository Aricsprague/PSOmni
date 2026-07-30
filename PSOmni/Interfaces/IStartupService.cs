using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Interfaces;

public interface IStartupService
{
    Task<bool> InitializeAsync();
}
