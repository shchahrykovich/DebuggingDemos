using System;
using System.Threading;
using Nancy;
using Nancy.Hosting.Self;

namespace NancyMemoryLeak
{
    static class Program
    {
        private static NancyHost _nancyHost;
        private static readonly CancellationTokenSource Source = new CancellationTokenSource();

        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                eventArgs.Cancel = true;
                Source.Cancel();
            };

            _nancyHost = new NancyHost(new Uri("http://localhost:5000"), new DefaultNancyBootstrapper(), new HostConfiguration
            {
                UrlReservations = new UrlReservations
                {
                    CreateAutomatically = true
                }
            });
            _nancyHost.Start();


            Console.WriteLine("Press Ctrl-C to exit.");
            WaitHandle.WaitAll(new[] {Source.Token.WaitHandle });
        }
    }
}
