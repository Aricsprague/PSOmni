using PSOmniSync.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmniSync.Interfaces;

// Defines operations for interacting with a device over adb.
public interface IAdbService
{
    // Determines whether a device is currently connected and visible to adb.
    Task<bool> IsDeviceConnectedAsync();

    // Attempts to connect to a device at the specified host and port. Returns true if a device becomes connected.
    Task<bool> ConnectAsync(string host, int port);

    // Gets the connected device's friendly name.
    Task<string> GetDeviceNameAsync();

    // Pulls a file from the device to the local filesystem.
    Task PullFileAsync(string remotePath, string localPath);

    // Pushes a file from the local filesystem to the device.
    Task PushFileAsync(string localPath, string remotePath);

    // Forces the specified package to stop on the connected device.
    Task ForceStopAsync(string packageName);

    //Lists files in a remote directory on the connected device. Returns a list of file names.
    Task<List<string>> ListFilesAsync(string remoteDirectory);

    // Retrieves a list of memory cards available on the connected device.
    Task<List<MemoryCard>> GetMemoryCardsAsync();
}