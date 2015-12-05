using System.Linq;
using DomainModel.Events;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace DomainModel.UnitTests
{
    public class DomainModelIsolationTests
    {
        [Test]
        public void ShouldNotHaveReferenceToMassTransit()
        {
            var domainModelAssembly = typeof (IDomainEvent).Assembly;
            var references = domainModelAssembly.GetReferencedAssemblies();

            Assert.That(references.Select(reference => reference.Name), DoesNotContainMassTransitAssembly());
        }

        private static IResolveConstraint DoesNotContainMassTransitAssembly()
        {
            return Is.Not.Contains("MassTransit");
        }
    }
}
