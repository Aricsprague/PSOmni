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

        /// <summary>Pulls the memory card file from the remote device to the local path.</summary>
        public async Task PullMemoryCardAsync()
        {
            await _adbService.PullFileAsync(
                _paths.RemoteMemoryCard,
                _paths.LocalMemoryCard);
        }

        /// <summary>Pushes the local memory card file to the remote device.</summary>
        public async Task PushMemoryCardAsync()
        {
            await _adbService.PushFileAsync(
                _paths.LocalMemoryCard,
                _paths.RemoteMemoryCard);
        }
    }
    /// <summary>
    /// Holds configured paths used by the synchronization service.
    /// </summary>
    public class SyncPaths
    {
        /// <summary>Local filesystem path for the memory card file.</summary>
        public string LocalMemoryCard { get; set; } = "";

        /// <summary>Remote device path for the memory card file.</summary>
        public string RemoteMemoryCard { get; set; } = "";
    }
}
