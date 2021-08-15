using GuessANumber.Common;

namespace GuessANumber.Infrastructure.Interfaces
{
    public interface IRandomGenerator
    {
        int GenerateRandomNumber() => new Random().Next(Constants.MinGuessNumber, Constants.MaxGuessNumber);
    }
}
