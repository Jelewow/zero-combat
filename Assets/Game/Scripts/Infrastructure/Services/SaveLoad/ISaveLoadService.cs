using ZeroCombat.Data;
using ZeroCombat.Infrastructure.Services;

namespace ZeroCombat.Infrastructure
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        
        PlayerProgress LoadProgress();
    }
}