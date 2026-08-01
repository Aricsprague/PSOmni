using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Interfaces
{
    /// <summary>Provides operations to synchronize memory card data between device and local storage.</summary>
    public interface ISyncService
    {
        /// <summary>Pulls the configured memory card from the device to local storage.</summary>
        Task PullMemoryCardAsync();

        /// <summary>Pushes the configured memory card from local storage to the device.</summary>
        Task PushMemoryCardAsync();
    }
}
