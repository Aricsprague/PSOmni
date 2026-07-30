using System;
using System.Collections.Generic;
using System.Text;
using PSOmni.Domain;

namespace PSOmni.Configuration;

public class AppSettings
{
    public string AdbPath { get; set; } = @"C:\Emulation\Sync\platform-tools\adb.exe";

    public List<SyncProfile> Profiles { get; set; } = new();

    public string DefaultProfile { get; set; } = "";
}