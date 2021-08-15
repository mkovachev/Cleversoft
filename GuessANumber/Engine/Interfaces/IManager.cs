namespace GuessANumber.Engine.Interfaces
{
    public interface IManager
    {
        string ReadInput();

        bool IsValidateInput(string input);

        int ParseToNumber(string input) => int.Parse(input);

        public bool Handle(int numberToCheck, int numberInMind) => numberInMind == numberToCheck;
    }
}
