using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.PersistentProgress.SaveLoad;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService  persistentProgressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _persistentProgressService = persistentProgressService;
            _saveLoadService = saveLoadService;
        }


        public void Enter()
        {
            LoadProgressOrInitNew();
            
            _gameStateMachine.Enter<LoadLevelState, string>(_persistentProgressService.PlayerProgress.WorldData.PositionOnLevel.Level);
        }

        public void Exit()
        {
            
        }

        private void LoadProgressOrInitNew()
        {
            _persistentProgressService.PlayerProgress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            PlayerProgress playerProgress = new PlayerProgress("Main");

            playerProgress.HeroState.MaxHealth = 50;
            playerProgress.HeroState.ResetHealth();
            
            return playerProgress;
        }
    }
}