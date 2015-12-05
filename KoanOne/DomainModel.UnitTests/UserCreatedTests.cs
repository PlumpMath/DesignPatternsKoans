using System;
using System.Reflection;
using DomainModel.Events;
using NUnit.Framework;

namespace DomainModel.UnitTests
{
    [TestFixture]
    public class UserCreatedTests
    {
        private UserCreated sut;

        [SetUp]
        public void PerTestSetup()
        {
            sut = new UserCreated(new User("user"));
        }

        [Test]
        public void GuardsConstructorArguments()
        {
            Assert.Throws<ArgumentNullException>(() => new UserCreated(null));
        }

        [Test]
        public void IsDomainEvent()
        {
            Assert.That(sut, Is.AssignableTo<IDomainEvent>());
        }
    }
}