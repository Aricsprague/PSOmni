using System;
using System.Collections.Generic;
using System.Text;
using PSOmni.Domain;

namespace PSOmni.Configuration;

public class AppSettings
{
    public string AdbPath { get; set; } = "adb";

    public List<SyncProfile> Profiles { get; set; } = new();

    public string DefaultProfile { get; set; } = "";
}