using PSOmniSync.Configuration;
using PSOmniSync.Domain;
using PSOmniSync.Interfaces;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSOmniSync.Infrastructure;

// Provides operations that use the adb command-line tool to communicate with an Android device.
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

    // Determines whether a device is currently connected and visible to adb.
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

    // Gets the connected device's friendly name.
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

    public async Task<List<string>> ListFilesAsync(string remoteDirectory)
    {
        CommandResult result =
            await _commandRunner.RunAsync(
                _settings.AdbPath,
                $"shell ls -1 \"{remoteDirectory}\"");

        if (!result.Success)
            throw new Exception(result.StandardError);

        return result.StandardOutput
            .Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }

    public async Task<List<MemoryCard>> GetMemoryCardsAsync()
    {
        CommandResult result =
            await _commandRunner.RunAsync(
                _settings.AdbPath,
                "shell ls \"/sdcard/Android/data/xyz.aethersx2.android/files/memcards\"");

        if (!result.Success)
            throw new Exception(result.StandardError);

        List<MemoryCard> cards = new();

        string[] lines =
            result.StandardOutput.Split(
                Environment.NewLine,
                StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
            if (!line.EndsWith(".ps2"))
                continue;

            string fileName = line.Trim();

            cards.Add(new MemoryCard
            {
                FileName = fileName,

                RemotePath =
                    $"/sdcard/Android/data/xyz.aethersx2.android/files/memcards/{fileName}",

                LocalPath =
                    Path.Combine(
                           @"C:\Emulation\PCSX2\memcards",
                            fileName)
            });
        }

        return cards;
    }

}
