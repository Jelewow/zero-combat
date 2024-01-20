using UnityEngine;
using ZeroCombat.Infrastructure;
using ZeroCombat.Logic.UI;

namespace ZeroCombat.Bootstrapper
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        
        private Infrastructure.Game _game;
        
        private void Awake()
        {
            _game = new Infrastructure.Game(this, _loadingCurtain);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}