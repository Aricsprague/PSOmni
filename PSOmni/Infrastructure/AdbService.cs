using PSOmni.Configuration;
using PSOmni.Domain;
using PSOmni.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSOmni.Infrastructure;

public class AdbService : IAdbService
{
    private readonly ICommandRunner _commandRunner;
    private readonly AppSettings _settings;

    public AdbService(
    ICommandRunner commandRunner,
    AppSettings settings)
    {
        _commandRunner = commandRunner;
        _settings = settings;
    }

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
