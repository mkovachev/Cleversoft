using GuessANumber.Engine.Interfaces;
using GuessANumber.Infrastructure.Interfaces;
using GuessANumber.Common;

namespace GuessANumber.Engine
{
    public class GuessManager : IManager
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IGuard guard;

        public GuessManager(IReader reader, IWriter writer, IGuard guard)
        {
            this.reader = reader;
            this.writer = writer;
            this.guard = guard;
        }

        public string ReadInput()
        {
            string input = string.Empty;
            try
            {
                this.writer.Write($"Please type in your guess number in the range {Constants.MinGuessNumber} to {Constants.MaxGuessNumber}: ");

                input = this.reader.ReadLine().ToLower().Trim();
            }
            catch (Exception ex)
            {
                this.writer.WriteLine($"{ex.Message}");
            }

            return input;
        }

        public bool IsValidateInput(string input)
        {
            var isValidInput = ValidateInput(input);

            return isValidInput;
        }

        private bool ValidateInput(string value)
        {
            return this.guard.AgainstNullOrEmpty(value)
                && this.guard.AgainstNullOrWhiteSpace(value)
                && this.guard.AgainstNonDigits(value)
                && this.guard.AgainstNegativeOrZero(value)
                && this.guard.AgainstNotInRange(value);
        }
    }
}
