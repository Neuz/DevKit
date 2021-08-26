namespace Neuz.DevKit.Api.DNSPod
{
    public class DnsPodApi
    {
        public Info Info { get; }
        public User User { get; }
        public Domain Domain { get; }

        public DnsPodApi(DnsPodSettings settings)
        {
            Info   = new Info(settings);
            User   = new User(settings);
            Domain = new Domain(settings);
        }
    }

    public abstract class BaseApi
    {
        protected readonly DnsPodSettings Settings;

        protected BaseApi(DnsPodSettings settings)
        {
            Settings = settings;
        }
    }
}