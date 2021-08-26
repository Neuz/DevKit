namespace Neuz.DevKit.Api.DNSPod
{
    public class DnsPodApi
    {
        public Info Info { get; }
        public User User { get; }

        public DnsPodApi(DnsPodSettings settings)
        {
            Info = new Info(settings);
            User = new User(settings);
        }
    }

    public abstract class BaseApi
    {
        protected readonly DnsPodSettings _settings;

        protected BaseApi(DnsPodSettings settings)
        {
            _settings = settings;
        }
    }
}