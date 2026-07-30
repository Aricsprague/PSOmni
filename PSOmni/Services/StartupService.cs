using System;
using System.Collections.Generic;
using System.Text;
using PSOmni.Interfaces;

namespace PSOmni.Services;

public class StartupService : IStartupService
{
    private readonly IAdbService _adbService;

    public StartupService(IAdbService adbService)
    {
        _adbService = adbService;
    }

    public async Task<bool> InitializeAsync()
    {
        if (await _adbService.IsDeviceConnectedAsync())
            return true;

        bool connected = await _adbService.ConnectAsync(
            "192.168.40.227",
            42123);

        if (connected)
            return true;

        return false;
    }
}
