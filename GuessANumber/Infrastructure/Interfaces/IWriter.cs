namespace GuessANumber.Infrastructure.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string message);

        void Write(string message);
    }
}
