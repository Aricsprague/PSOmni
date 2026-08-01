using System;
using System.Collections.Generic;
using System.Text;
using PSOmni.Domain;

namespace PSOmni.Configuration;

/// <summary>Application-level configuration values used by services and components.</summary>
public class AppSettings
{
    /// <summary>Path to the adb executable used to communicate with the device.</summary>
    public string AdbPath { get; set; } = @"C:\Emulation\Sync\platform-tools\adb.exe";

    /// <summary>Available synchronization profiles.</summary>
    public List<SyncProfile> Profiles { get; set; } = new();

    /// <summary>Name of the default synchronization profile.</summary>
    public string DefaultProfile { get; set; } = "";
}
