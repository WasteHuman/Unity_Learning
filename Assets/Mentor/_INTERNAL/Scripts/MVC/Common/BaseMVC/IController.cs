namespace Mentor.MVC.Common.BaseMVC
{
    public interface IController
    {
        void BindModel(IModel model);
        void BindView(IView view);
        void Dispose();
    }
}
