using Mentor.Configs;

using Mentor.MVC.Common.BaseMVC;
using Mentor.MVC.EnemyLogic;
using Mentor.MVC.PlayerLogic;

using Mentor.MVVM.Enemy;
using Mentor.MVVM.PlayerLogic;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace GameEntry
{
    public class MainEntryPoint : MonoBehaviour
    {
        [Header("Configs")]
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private EnemyComponentsConfig _enemyConfig;

        [Space(5), Header("Load setup")]
        [SerializeField] private bool _useMVVM = true;

        [Space(5), Header("Game Views")]
        [SerializeField] private PlayerInfoView _playerInfoView;

        private readonly List<IController> _controllers = new();
        private readonly List<IDisposable> _disposables = new();

        private void Start()
        {
            if(_playerConfig == null || _enemyConfig == null)
            {
                Debug.LogWarning("[Main Entry Point] The one of configs was miss!");
                return;
            }

            if(_useMVVM)
                CreateMVVMScene();
            else
                CreateMVCScene();
        }

        private void OnDestroy()
        {
            if(_controllers.Count > 0)
                for (int i = 0; i < _controllers.Count; i++)
                    _controllers[i].Dispose();

            if(_disposables.Count > 0)
                for(int i = 0; i < _disposables.Count; i++)
                    _disposables[i].Dispose();
        }

        private void CreateMVVMScene()
        {
            var enemyViewMVVMPrefab = Resources.Load<EnemyView>("Mentor/Prefabs/Enemy_MVVM");
            var enemyViewMVVM = Instantiate(enemyViewMVVMPrefab);

            Player player = new(_playerConfig);
            PlayerInfoViewModel playerInfoViewModel = new();

            playerInfoViewModel.BindModel(player);
            _playerInfoView.BindViewModel(playerInfoViewModel);

            EnemyModel enemyModel = new(_enemyConfig, player);

            EnemyViewModel enemyViewModel = new();
            enemyViewModel.BindModel(enemyModel);

            enemyViewMVVM.BindViewModel(enemyViewModel);

            _disposables.Add(enemyModel);
        }

        private void CreateMVCScene()
        {
            var enemyViewMVCPrefab = Resources.Load<EnemyViewMVC>("Mentor/Prefabs/Enemy_MVC");
            var enemyViewMVC = Instantiate(enemyViewMVCPrefab);

            PlayerModel playerModel = new(_playerConfig);
            EnemyModelMVC enemyModel = new(_enemyConfig);

            EnemyController enemyController = new(playerModel);
            enemyController.BindModel(enemyModel);
            enemyController.BindView(enemyViewMVC);

            _controllers.Add(enemyController);
        }
    }
}