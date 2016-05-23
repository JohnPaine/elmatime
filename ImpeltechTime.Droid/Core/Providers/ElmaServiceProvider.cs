namespace ImpeltechTime.Droid.Core.Model.Providers
{
    public class ElmaServiceProvider : IElmaServiceProvider
    {
        public IElmaWcfService ElmaWcfService { get; }

        public ElmaServiceProvider (IElmaWcfService wcfService) {
            ElmaWcfService = wcfService;
        }
    }
}