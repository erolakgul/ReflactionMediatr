namespace ReflactionMediatr.Lib.Helper
{
    public class ServiceProvider
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider Provider => _serviceProvider;

        public static void SetInstanse(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
