using System;
using System.Collections.Generic;
using System.Text;
using PSOmni.Interfaces;

namespace PSOmni.Services;

// Performs application startup checks and attempts to establish a device connection when needed.
public class StartupService : IStartupService
{
    private readonly IAdbService _adbService;

    /// <summary>Creates a new <see cref="StartupService"/>.</summary>
    /// <param name="adbService">Service used to communicate with the device.</param>
    public StartupService(IAdbService adbService)
    {
        _adbService = adbService;
    }
    // Initializes components required at application startup and ensures a device connection is available. Returns true when initialization succeeds and a device is connected.
    public async Task<bool> InitializeAsync()
    {
        if (await _adbService.IsDeviceConnectedAsync())
            return true;

        bool connected = await _adbService.ConnectAsync(
            "192.168.40.227",
            5555);

        if (connected)
            return true;

        return false;
    }
}
