using ZeroCombat.Data;

namespace ZeroCombat.Infrastructure.Services.PersistentProgress
{
    public class PersistantProgressService : IPersistantProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}