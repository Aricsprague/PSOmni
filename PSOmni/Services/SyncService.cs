using PSOmni.Domain;
using PSOmni.Interfaces;

namespace PSOmni.Services
{
    internal class SyncService : ISyncService
    {
        private readonly IAdbService _adbService;

        public SyncService(IAdbService adbService)
        {
            _adbService = adbService;
        }

        public async Task PullMemoryCardAsync(MemoryCard memoryCard)
        {
            await _adbService.PullFileAsync(
                memoryCard.RemotePath,
                memoryCard.LocalPath);
        }

        public async Task PushMemoryCardAsync(MemoryCard memoryCard)
        {
            await _adbService.PushFileAsync(
                memoryCard.LocalPath,
                memoryCard.RemotePath);
        }
    }
}