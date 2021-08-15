using GuessANumber.Infrastructure.Interfaces;

namespace GuessANumber.Infrastructure
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
