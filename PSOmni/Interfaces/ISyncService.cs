using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Interfaces
{
    // Provides operations to synchronize memory card data between device and local storage.
    public interface ISyncService
    {
        // Pulls the configured memory card from the device to local storage.
        Task PullMemoryCardAsync();

        // Pushes the configured memory card from local storage to the device.
        Task PushMemoryCardAsync();
    }
}
