using Mentor.MVVM.BaseMVVM;
using System;

namespace Mentor.MVVM.Enemy
{
    public class EnemyViewModel : IViewModel, IDisposable
    {
        private EnemyModel _model;

        public void BindModel(IModel model)
        {
            _model = model as EnemyModel;
        }

        public void Dispose()
        {
            _model.Dispose();
        }

        public void EnemyClicked() => _model.ApplyDamage();
    }
}