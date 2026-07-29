using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Domain;

public class SyncProfile
{
    public string Name { get; set; } = "";

    public string LocalFolder { get; set; } = "";

    public string RemoteFolder { get; set; } = "";

    public List<MemoryCard> MemoryCards { get; } = new();
}