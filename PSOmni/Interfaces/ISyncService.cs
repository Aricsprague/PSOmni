using PSOmniSync.Domain;

namespace PSOmniSync.Interfaces
{
    public interface ISyncService
    {
        Task PullMemoryCardAsync(MemoryCard memoryCard);

        Task PushMemoryCardAsync(MemoryCard memoryCard);
    }
}