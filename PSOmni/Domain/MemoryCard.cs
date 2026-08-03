using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmniSync.Domain;

/// <summary>
/// Represents a PlayStation 2 memory card available for synchronization.
/// </summary>
public class MemoryCard
{
    /// <summary>
    /// File name of the memory card.
    /// </summary>
    public string FileName { get; set; } = "";

    /// <summary>
    /// Full path to the memory card on the Android device.
    /// </summary>
    public string RemotePath { get; set; } = "";

    /// <summary>
    /// Full path to the corresponding memory card on the local PC.
    /// </summary>
    public string LocalPath { get; set; } = "";

    public override string ToString()
    {
        return FileName;
    }
}