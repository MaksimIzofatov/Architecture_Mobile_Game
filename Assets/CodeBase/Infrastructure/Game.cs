using CodeBase.Services.Input;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;
        public static IInputService InputService;

        public Game(ICoroutineRunner runner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(runner));
        }

       
    }
}