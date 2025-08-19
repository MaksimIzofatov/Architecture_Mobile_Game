using System;
using CodeBase.CameraLogic;
using CodeBase.Logic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag));

            _gameFactory.CreateHud();
            
            CameraFollow(hero);
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private static void CameraFollow(GameObject hero)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(hero);
        }
    }
}