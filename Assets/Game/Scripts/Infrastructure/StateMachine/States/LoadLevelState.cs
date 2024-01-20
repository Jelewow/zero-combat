using UnityEngine;
using ZeroCombat.Bootstrapper;
using ZeroCombat.CameraLogic;
using ZeroCombat.Constants;
using ZeroCombat.Factory;
using ZeroCombat.Logic.UI;

namespace ZeroCombat.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        private static Camera _camera;
        
        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }
        
        public void Enter(string name)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(name, OnLoaded);
        }

        private void OnLoaded()
        {
            var player = _gameFactory.CreatePlayer(GameObject.FindWithTag(Constant.Tags.InitialPoint));
            var hud = _gameFactory.CreateHud();
            CameraFollow(player.transform);
            
            _gameStateMachine.Enter<GameLoopState>();
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