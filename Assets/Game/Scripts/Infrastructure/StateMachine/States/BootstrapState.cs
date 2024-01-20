using UnityEngine;
using ZeroCombat.AssetProvider;
using ZeroCombat.Bootstrapper;
using ZeroCombat.Constants;
using ZeroCombat.Factory;
using ZeroCombat.Infrastructure.Services;
using ZeroCombat.Infrastructure.Services.PersistentProgress;
using ZeroCombat.Services.Input;

namespace ZeroCombat.Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices allServices)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = allServices;
            
            RegisterServices();
        }

        public void Exit()
        {
        }
        
        public void Enter()
        {
            _sceneLoader.Load(Constant.Scenes.Initial, EnterLoadLevel);
        }
        
        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(Constant.Scenes.Main);
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(RegisterInputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider.AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IPersistantProgressService>(new PersistantProgressService());
        }

        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
            {
                return new StandaloneInputService();
            }
            
            return new MobileInputService();
        }
    }
}