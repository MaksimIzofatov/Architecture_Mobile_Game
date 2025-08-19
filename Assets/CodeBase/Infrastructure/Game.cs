using CodeBase.Logic;
using CodeBase.Services.Input;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;
        public static IInputService InputService;

        public Game(ICoroutineRunner runner, LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(runner), curtain);
        }

       
    }
}