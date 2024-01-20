using ZeroCombat.Data;

namespace ZeroCombat.Infrastructure.Services.PersistentProgress
{
    public interface IPersistantProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}