using JHSEngine.Interfaces;
using JHSEngine.Patterns.Observer;

namespace JHSEngine.Patterns.Mediator
{
    public class Mediator : Notifier, IMediator, INotifier
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

        public virtual string MediatorName { get; set; }

        public virtual object ViewComponent { get; set; }
    }
}
