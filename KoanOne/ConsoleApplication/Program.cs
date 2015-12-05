using System;
using DomainModel;
using MassTransit;
using MassTransit.Transports.InMemory;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var busControl = ConfigureBus();
            busControl.Start();

            var userCreated = new UserCreated(new User("John"));
            busControl.Publish(userCreated);

            Console.ReadKey();
        }

        private static IBusControl ConfigureBus()
        {
            var inMemoryTransportCache = new InMemoryTransportCache(Environment.ProcessorCount);

            return Bus.Factory.CreateUsingInMemory(cfg =>
            {
                cfg.SetTransportProvider(inMemoryTransportCache);
                cfg.ReceiveEndpoint("Test",
                    configurator =>
                    {
                        configurator.Consumer(() => new UserGreetings(new ConsoleGreetingSender()));
                    });
            });
        }
    }
}
