using System;
using DomainModel.Events;

namespace DomainModel
{
    public class UserCreated : IDomainEvent
    {
        public UserCreated(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            User = user;
        }

        public User User { get; }
    }
}