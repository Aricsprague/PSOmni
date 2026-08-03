using System;
using System.Collections.Generic;
using System.Text;
using PSOmniSync.Domain;

namespace PSOmniSync.Configuration;

// Application-level configuration values used by services and components.
public class AppSettings
{
    // Path to the adb executable used to communicate with the device.
    public string AdbPath { get; set; } = @"C:\Emulation\Sync\platform-tools\adb.exe";

    // Available synchronization profiles.
    public List<SyncProfile> Profiles { get; set; } = new();

    // Name of the default synchronization profile.
    public string DefaultProfile { get; set; } = "";

    // Directory on the device where memory card files are stored.
    public string MemoryCardDirectory { get; set; } =
    "/sdcard/Android/data/xyz.aethersx2.android/files/memcards";
}