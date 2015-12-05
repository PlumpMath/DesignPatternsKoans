using System;
using System.Threading.Tasks;
using DomainModel.Events;
using MassTransit;
using MassTransit.Util;

namespace DomainModel
{
    public class UserGreetings : IEventHandler<UserCreated>
    {
        private readonly IGreetingSender greetingSender;

        public UserGreetings(IGreetingSender greetingSender)
        {
            if (greetingSender == null)
            {
                throw new ArgumentNullException(nameof(greetingSender));
            }
            this.greetingSender = greetingSender;
        }

        public void Handle(UserCreated userCreatedEvent)
        {
            greetingSender.SendFor(userCreatedEvent.User.Name);
        }

        public Task Consume(ConsumeContext<UserCreated> context)
        {
            Handle(context.Message);
            return TaskUtil.Completed;
        }
    }
}