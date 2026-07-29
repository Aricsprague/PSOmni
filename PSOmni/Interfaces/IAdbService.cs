using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Interfaces;

public interface IAdbService
{
    Task<bool> IsDeviceConnectedAsync();

    Task<string> GetDeviceNameAsync();

    Task PullFileAsync(string remotePath, string localPath);

    Task PushFileAsync(string localPath, string remotePath);

    Task ForceStopAsync(string packageName);
}
