using System;
using DomainModel;

namespace ConsoleApplication
{
    public class ConsoleGreetingSender : IGreetingSender
    {
        public void SendFor(string name)
        {
            Console.WriteLine($"Greetings for {name}");
        }
    }
}