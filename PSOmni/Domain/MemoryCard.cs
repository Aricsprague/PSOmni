using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Domain;

public class MemoryCard
{
    public string Name { get; set; } = "";

    public string FileName { get; set; } = "";

    public bool IsDefault { get; set; }

    public override string ToString()
    {
        return Name;
    }
}