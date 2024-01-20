using UnityEngine;
using ZeroCombat.Bootstrapper;
using ZeroCombat.CameraLogic;
using ZeroCombat.Constants;
using ZeroCombat.Factory;
using ZeroCombat.Infrastructure.Services.PersistentProgress;
using ZeroCombat.Logic.UI;

namespace ZeroCombat.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistantProgressService _progressService;

        private static Camera _camera;
        
        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, IPersistantProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }
        
        public void Enter(string name)
        {
            _loadingCurtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(name, OnLoaded);
        }

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (var progressReader in _gameFactory.ProgressReaders)
            {
                progressReader.LoadProgress(_progressService.Progress);
            }
        }

        private void InitGameWorld()
        {
            var player = _gameFactory.CreatePlayer(GameObject.FindWithTag(Constant.Tags.InitialPoint));
            var hud = _gameFactory.CreateHud();
            CameraFollow(player.transform);
        }

        private static void SetCamera(Camera camera)
        {
            _camera = camera;
        }

        private static void CameraFollow(Transform player)
        {
            if (_camera == null)
            {
                SetCamera(Camera.main);
            } 
            
            _camera.GetComponent<CameraFollow>().Follow(player);
        }
    }
}