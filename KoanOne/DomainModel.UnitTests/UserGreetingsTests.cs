using System;
using DomainModel.Events;
using MassTransit;
using NSubstitute;
using NUnit.Framework;

namespace DomainModel.UnitTests
{
    [TestFixture]
    public class UserGreetingsTests
    {
        private IGreetingSender greetingSender;
        private UserGreetings sut;

        [SetUp]
        public void PerTestSetup()
        {
            greetingSender = Substitute.For<IGreetingSender>();
            sut = new UserGreetings(greetingSender);
        }

        [Test]
        public void GuardsConstructorArguments()
        {
            Assert.Throws<ArgumentNullException>(() => new UserGreetings(null));
        }
        
        [Test]
        public void HandleUserCreated()
        {
            Assert.That(sut, Is.AssignableTo<IEventHandler<UserCreated>>());
        }

        [Test]
        public void SendsEmailWhenHandlingUserCreatedEvent()
        {
            var userName = "John";
            sut.Handle(UserCreatedEventFor(userName));

            greetingSender.Received(1).SendFor(userName);
        }

        [Test]
        public void DoesNotImplementAnyMassTransitSpecificInterface()
        {
            Assert.That(sut, Is.Not.AssignableTo<IConsumer<UserCreated>>());
        }

        private static UserCreated UserCreatedEventFor(string userName)
        {
            return new UserCreated(new User(userName));
        }
    }
}