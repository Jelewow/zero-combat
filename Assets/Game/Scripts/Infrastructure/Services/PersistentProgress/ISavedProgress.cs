using ZeroCombat.Data;

namespace ZeroCombat.Player
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
    
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}