using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Domain;

// Represents a memory card configuration used for synchronization.
public class MemoryCard
{
    // Display name for the memory card.
    public string Name { get; set; } = "";

    // File name (path) of the memory card on disk.
    public string FileName { get; set; } = "";

    // Indicates whether this memory card is the default selection.
    public bool IsDefault { get; set; }

    // Returns the display name for the memory card.
    public override string ToString()
    {
        return Name;
    }
}