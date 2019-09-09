using JHSEngine.Interfaces;
using JHSEngine.Patterns.Observer;
using JHUI.Forms;

namespace JHSEngine.Patterns.Mediator
{
    public class JMediator : JFormNotfifier, IMediator, INotifier
    {
        public static string NAME = "Mediator";
        protected string mediatorName;

        public virtual string[] ListNotificationInterests()
        {
            return new string[0];
        }

        public virtual void HandleNotification(INotification notification)
        {
        }

        public virtual void OnRegister()
        {
        }

        public virtual void OnRemove()
        {
        }

        public virtual string MediatorName => Text;

        public virtual object ViewComponent => this;
    }
}
