using System;
using System.Collections.Generic;
using System.Text;
using PSOmni.Interfaces;

namespace PSOmni.Infrastructure;

public class AdbService : IAdbService
{
    public Task<bool> IsDeviceConnectedAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetDeviceNameAsync()
    {
        throw new NotImplementedException();
    }

    public Task PullFileAsync(string remotePath, string localPath)
    {
        throw new NotImplementedException();
    }

    public Task PushFileAsync(string localPath, string remotePath)
    {
        throw new NotImplementedException();
    }

    public Task ForceStopAsync(string packageName)
    {
        throw new NotImplementedException();
    }
}
