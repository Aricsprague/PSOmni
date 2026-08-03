using PSOmni.Domain;

namespace PSOmni.Interfaces
{
    public interface ISyncService
    {
        Task PullMemoryCardAsync(MemoryCard memoryCard);

        Task PushMemoryCardAsync(MemoryCard memoryCard);
    }
}