using UnityEngine; 
using ZeroCombat.Constants;
using ZeroCombat.Data;
using ZeroCombat.Extensions;
using ZeroCombat.Factory;
using ZeroCombat.Infrastructure.Services.PersistentProgress;

namespace ZeroCombat.Infrastructure
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistantProgressService _persistantProgressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistantProgressService persistantProgressService, IGameFactory gameFactory)
        {
            _persistantProgressService = persistantProgressService;
            _gameFactory = gameFactory;
        }
        
        public void SaveProgress()
        {
            foreach (var progressWriter in _gameFactory.ProgressWriters)
            {
                progressWriter.UpdateProgress(_persistantProgressService.Progress);
            }
            
            PlayerPrefs.SetString(Constant.Prefs.Progress, _persistantProgressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(Constant.Prefs.Progress)?.ToDeserialized<PlayerProgress>();
        }
    }
}