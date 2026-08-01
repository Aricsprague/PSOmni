using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Domain;

/// <summary>Configuration for a synchronization profile including connection and folder information.</summary>
public class SyncProfile
{
    /// <summary>Profile name shown to the user.</summary>
    public string Name { get; set; } = "";

    /// <summary>Hostname or IP address of the remote device.</summary>
    public string Host { get; set; } = "";
    /// <summary>Port used for the remote connection.</summary>
    public int Port { get; set; }

    /// <summary>Local folder path used for synchronization.</summary>
    public string LocalFolder { get; set; } = "";
    /// <summary>Remote folder path used for synchronization on the device.</summary>
    public string RemoteFolder { get; set; } = "";

    /// <summary>Memory cards associated with this profile.</summary>
    public List<MemoryCard> MemoryCards { get; set; } = new();
}
