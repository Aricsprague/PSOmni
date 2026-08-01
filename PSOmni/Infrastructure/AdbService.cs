using PSOmni.Configuration;
using PSOmni.Domain;
using PSOmni.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSOmni.Infrastructure;

/// <summary>Provides operations that use the adb command-line tool to communicate with an Android device.</summary>
public class AdbService : IAdbService
{
    private readonly ICommandRunner _commandRunner;
    private readonly AppSettings _settings;

    /// <summary>Creates a new instance of <see cref="AdbService"/>.</summary>
    /// <param name="commandRunner">Runner used to execute external commands.</param>
    /// <param name="settings">Application settings containing the adb path.</param>
    public AdbService(
    ICommandRunner commandRunner,
    AppSettings settings)
    {
        _commandRunner = commandRunner;
        _settings = settings;
    }

    /// <summary>Determines whether a device is currently connected and visible to adb.</summary>
    public async Task<bool> IsDeviceConnectedAsync()
    {
        CommandResult result = await _commandRunner.RunAsync(
            _settings.AdbPath,
            "devices");

        if (!result.Success)
            return false;

        string[] lines = result.StandardOutput.Split(
            Environment.NewLine,
            StringSplitOptions.RemoveEmptyEntries);

        return lines.Any(line =>
            line.EndsWith("\tdevice"));
    }

    /// <summary>Attempts to connect to a device at the specified host and port. Returns true if a device becomes connected.</summary>
    /// <param name="host">Device host or IP address.</param>
    /// <param name="port">Port used for the adb connection.</param>
    public async Task<bool> ConnectAsync(
    string host,
    int port)
    {
        CommandResult result =
            await _commandRunner.RunAsync(
                _settings.AdbPath,
                $"connect {host}:{port}");

        if (!result.Success)
            return false;

        return await IsDeviceConnectedAsync();
    }

    /// <summary>Gets the connected device's friendly name.</summary>
    public Task<string> GetDeviceNameAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>Pulls a file from the device to the local filesystem. Throws an exception if the operation fails.</summary>
    /// <param name="remotePath">Path to the file on the device.</param>
    /// <param name="localPath">Destination path on the local machine.</param>
    public async Task PullFileAsync(string remotePath, string localPath)
    {
        CommandResult result =
            await _commandRunner.RunAsync(
                _settings.AdbPath,
                $"pull \"{remotePath}\" \"{localPath}\"");

        if (!result.Success)
        {
            throw new Exception(result.StandardError);
        }
    }

    /// <summary>Pushes a file from the local filesystem to the device. Throws an exception if the operation fails.</summary>
    /// <param name="localPath">Path to the local file.</param>
    /// <param name="remotePath">Destination path on the device.</param>
    public async Task PushFileAsync(string localPath, string remotePath)
    {
        CommandResult result =
           await _commandRunner.RunAsync(
               _settings.AdbPath,
               $"push \"{localPath}\" \"{remotePath}\"");

        if (!result.Success)
        {
            throw new Exception(result.StandardError);
        }
    }

    /// <summary>Forces the specified package to stop on the connected device.</summary>
    /// <param name="packageName">Package identifier to stop.</param>
    public Task ForceStopAsync(string packageName)
    {
        throw new NotImplementedException();
    }
}
