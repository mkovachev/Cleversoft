using GuessANumber.Infrastructure.Interfaces;

namespace GuessANumber.Infrastructure
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);

        public void Write(string message) => Console.Write(message);
    }
}
