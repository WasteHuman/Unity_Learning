using Mentor.Configs;
using Mentor.MVC.Common.BaseMVC;
using Mentor.MVC.EnemyLogic;
using Mentor.MVC.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;

namespace GameEntry
{
    public class MainEntryPoint : MonoBehaviour
    {
        [Header("Configs")]
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private EnemyComponentsConfig _enemyConfig;

        private readonly List<IController> _controllers = new();

        private void Start()
        {
            if(_playerConfig == null || _enemyConfig == null)
            {
                Debug.LogWarning("[Main Entry Point] The one of configs was miss!");
                return;
            }

            CreateScene();
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _controllers.Count; i++)
                _controllers[i].Dispose();
        }

        private void CreateScene()
        {
            var enemyViewPrefab = Resources.Load<EnemyView>("Mentor/Prefabs/Enemy");
            var enemyView = Instantiate(enemyViewPrefab);

            PlayerModel playerModel = new(_playerConfig);
            EnemyModel enemyModel = new(_enemyConfig);

            EnemyController enemyController = new(playerModel);
            enemyController.BindModel(enemyModel);
            enemyController.BindView(enemyView);

            _controllers.Add(enemyController);
        }
    }
}