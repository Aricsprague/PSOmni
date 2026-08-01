using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Domain;

/// <summary>Represents a memory card configuration used for synchronization.</summary>
public class MemoryCard
{
    /// <summary>Display name for the memory card.</summary>
    public string Name { get; set; } = "";

    /// <summary>File name (path) of the memory card on disk.</summary>
    public string FileName { get; set; } = "";

    /// <summary>Indicates whether this memory card is the default selection.</summary>
    public bool IsDefault { get; set; }

    /// <summary>Returns the display name for the memory card.</summary>
    public override string ToString()
    {
        return Name;
    }
}
