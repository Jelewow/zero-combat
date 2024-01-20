using ZeroCombat.Bootstrapper;
using ZeroCombat.Infrastructure.Services;
using ZeroCombat.Logic.UI;

namespace ZeroCombat.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
        }
    }
}