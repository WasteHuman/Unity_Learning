using Mentor.MVVM.BaseMVVM;

namespace Mentor.MVVM.Enemy
{
    public class EnemyViewModel : IViewModel
    {
        private EnemyModel _model;

        public void BindModel(IModel model)
        {
            _model = model as EnemyModel;
        }

        public void EnemyClicked() => _model.ApplyDamage();
    }
}