using System;

namespace DomainModel
{
    public class User
    {
        public User(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }
        public string Name { get; }
    }
}