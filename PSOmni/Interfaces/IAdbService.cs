using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Interfaces;

/// <summary>Defines operations for interacting with a device over adb.</summary>
public interface IAdbService
{
    /// <summary>Determines whether a device is currently connected and visible to adb.</summary>
    Task<bool> IsDeviceConnectedAsync();

    /// <summary>Attempts to connect to a device at the specified host and port. Returns true if a device becomes connected.</summary>
    Task<bool> ConnectAsync(string host, int port);

    /// <summary>Gets the connected device's friendly name.</summary>
    Task<string> GetDeviceNameAsync();

    /// <summary>Pulls a file from the device to the local filesystem.</summary>
    Task PullFileAsync(string remotePath, string localPath);

    /// <summary>Pushes a file from the local filesystem to the device.</summary>
    Task PushFileAsync(string localPath, string remotePath);

    /// <summary>Forces the specified package to stop on the connected device.</summary>
    Task ForceStopAsync(string packageName);
}
