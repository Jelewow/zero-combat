using ZeroCombat.Constants;
using ZeroCombat.Data;
using ZeroCombat.Infrastructure.Services.PersistentProgress;

namespace ZeroCombat.Infrastructure
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistantProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        
        public LoadProgressState(GameStateMachine gameStateMachine, IPersistantProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Exit()
        { 
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.WorldData.PositionOnLevel.SceneName);
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress(Constant.Scenes.Main);
        }
    }
}