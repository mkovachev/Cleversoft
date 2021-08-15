using GuessANumber.Common;

namespace GuessANumber.Infrastructure.Interfaces
{
    public interface IGuard
    {
        bool AgainstNullOrEmpty(string value) => !string.IsNullOrEmpty(value);

        bool AgainstNullOrWhiteSpace(string value) => !string.IsNullOrWhiteSpace(value);

        bool AgainstNonDigits(string value) => !value.Any(x => !char.IsDigit(x));

        bool AgainstNegativeOrZero(string value) => int.Parse(value) > 0;

        bool AgainstNotInRange(string value) => (int.Parse(value) >= Constants.MinGuessNumber && int.Parse(value) <= Constants.MaxGuessNumber);

    }
}
