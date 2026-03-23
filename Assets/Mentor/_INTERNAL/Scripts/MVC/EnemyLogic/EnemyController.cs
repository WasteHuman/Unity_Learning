using Mentor.MVC.EnemyLogic;
using Mentor.MVC.Common.BaseMVC;
using Mentor.MVC.PlayerLogic;

namespace Mentor.MVC.EnemyLogic
{
    public class EnemyController : IController
    {
        private EnemyModel _model;
        private EnemyView _view;

        private readonly PlayerModel _playerModel;

        public EnemyController(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void BindModel(IModel model)
        {
            _model = model as EnemyModel;
            _model.EnemyDied += HandleEnemyDie;
        }

        public void BindView(IView view)
        {
            _view = view as EnemyView;

            _view.EnemyClicked += HandleEnemyClick;
        }

        public void Dispose()
        {
            _model.Dispose();
        }

        private void HandleEnemyClick()
        {
            _model.ApplyDamage(_playerModel.GetDamage());
        }

        private void HandleEnemyDie()
        {
            _playerModel.IncreasePlayerDamage();
        }
    }
}