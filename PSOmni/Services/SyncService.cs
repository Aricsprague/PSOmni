using PSOmni.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSOmni.Services
{
    internal class SyncService
    {
        private readonly IAdbService _adbService;
        private readonly SyncPaths _paths;

        public SyncService(
            IAdbService adbService,
            SyncPaths paths)
        {
            _adbService = adbService;
            _paths = paths;
        }

        // Pulls the memory card file from the remote device to the local path.
        public async Task PullMemoryCardAsync()
        {
            await _adbService.PullFileAsync(
                _paths.RemoteMemoryCard,
                _paths.LocalMemoryCard);
        }

        // Pushes the local memory card file to the remote device.
        public async Task PushMemoryCardAsync()
        {
            await _adbService.PushFileAsync(
                _paths.LocalMemoryCard,
                _paths.RemoteMemoryCard);
        }
    }
    
    // Holds configured paths used by the synchronization service.
    public class SyncPaths
    {
        // Local filesystem path for the memory card file.
        public string LocalMemoryCard { get; set; } = "";

        // Remote device path for the memory card file.
        public string RemoteMemoryCard { get; set; } = "";
    }
}
