using CodeBase.CameraLogic;
using CodeBase.Hero;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using CodeBase.StaticData;
using CodeBase.UI;
using CodeBase.UI.Elements;
using CodeBase.UI.Services.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string EnemySpawnerTag = "EnemySpawner";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private IStaticDataService _staticData;
        private readonly IUIFactory _uiFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory, IPersistentProgressService progressService, IStaticDataService staticData, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _staticData = staticData;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            
            _gameFactory.Cleanup();
            
            _sceneLoader.Load(sceneName, OnLoaded);
        }   

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            InitUIRoot();
            InitGameWorld();
            InformProgressReaders();

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitUIRoot() => _uiFactory.CreateUIRoot();

        private void InformProgressReaders()
        {
            foreach (var reader in _gameFactory.ProgressReaders)
            {
                reader.LoadProgress(_progressService.PlayerProgress);
            }
        }

        private void InitGameWorld()
        {
            InitSpawners();
            
            GameObject hero = InitHero();

            InitHud(hero);
            
            CameraFollow(hero);
        }

        private void InitSpawners()
        {
           string sceneKey = SceneManager.GetActiveScene().name;
           LevelStaticData levelData = _staticData.ForLevel(sceneKey);

           foreach (EnemySpawnerData enemySpawner in levelData.EnemySpawners)
           {
               _gameFactory.CreateSpawner(enemySpawner.Id, enemySpawner.Position, enemySpawner.MonsterTypeId);
           }
        }

        private GameObject InitHero()
        {
            return _gameFactory.CreateHero(GameObject.FindGameObjectWithTag(InitialPointTag));
        }

        private void InitHud(GameObject hero)
        {
            var hud = _gameFactory.CreateHud();
            hud.GetComponentInChildren<ActorUI>().Constructor(hero.GetComponent<HeroHealth>());
        }

        private static void CameraFollow(GameObject hero)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(hero);
        }
    }
}