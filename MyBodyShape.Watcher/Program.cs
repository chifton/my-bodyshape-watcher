// ===============================
// *******************************
// The program class.
// ===============================
// *******************************

namespace MyBodyShape.Watcher
{
    using MyBodyShape.Watcher.Services;
    using Topshelf;

    /// <summary>
    /// The program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        public static void Main(string[] args)
        {
            // Run as a service
            HostFactory.Run(x =>
            {
                x.Service<WatcherService>(s =>
                {
                    s.ConstructUsing(name => new WatcherService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(gr => gr.Stop());
                });
                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.SetDescription("Watches users generations on MyBodyShape apps and website");
                x.SetDisplayName("MyBodyShape Watcher");
                x.SetServiceName("MyBodyShapeWatcher");
            });
        } 
    }
}
