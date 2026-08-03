using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmniSync.Domain;

// Configuration for a synchronization profile including connection and folder information.
public class SyncProfile
{
    // Profile name shown to the user.
    public string Name { get; set; } = "";

    // Hostname or IP address of the remote device.
    public string Host { get; set; } = "";
    // Port used for the remote connection.
    public int Port { get; set; }

    // Local folder path used for synchronization.
    public string LocalFolder { get; set; } = "";
    // Remote folder path used for synchronization on the device.
    public string RemoteFolder { get; set; } = "";

    // Memory cards associated with this profile.
    public List<MemoryCard> MemoryCards { get; set; } = new();
}