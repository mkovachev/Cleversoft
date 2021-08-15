using GuessANumber.Common;
using GuessANumber.Engine.Interfaces;
using GuessANumber.Infrastructure.Interfaces;

namespace GuessANumber.Engine
{
    public class GuessEngine : IEngine
    {
        private readonly IWriter writer;
        private readonly IManager guessManager;
        private readonly IRandomGenerator randomGenerator;

        public GuessEngine(IWriter writer, IManager guessManager, IRandomGenerator randomGenerator)
        {
            this.writer = writer;
            this.guessManager = guessManager;
            this.randomGenerator = randomGenerator;
        }

        public void Start()
        {
            bool isSuccess = false;
            var attempts = Constants.NumberOfAttempts;
            var tries = Constants.NumberOfTries;

            var numberInMind = this.randomGenerator.GenerateRandomNumber();

            while (attempts > 0)
            {
                try
                {
                    var input = this.guessManager.ReadInput();

                    var isValidInput = this.guessManager.IsValidateInput(input);

                    if (isValidInput)
                    {
                        var numberToCheck = this.guessManager.ParseToNumber(input);
                        isSuccess = this.guessManager.Handle(numberToCheck, numberInMind);
                    }
                    else
                    {
                        this.writer.WriteLine("Please provide valid input!");
                        continue;
                    }

                    if (isSuccess)
                    {
                        this.writer.WriteLine($"You did a great job. {input} is the correct number");
                        this.writer.WriteLine("--------------------------------------");
                        this.writer.WriteLine("Closing application...");
                        Thread.Sleep(5000);
                        break;
                    }
                    else
                    {
                        this.writer.WriteLine($"{input} is not the number we have in mind");
                    }

                }
                catch (Exception ex)
                {
                    this.writer.WriteLine($"{ex}");
                }

                attempts--;
                tries++;

                if (tries == Constants.NumberOfAttempts)
                {
                    this.writer.WriteLine("--------------------------------------");
                    this.writer.WriteLine("Sorry you don't have any attempts left");
                    this.writer.WriteLine("Closing application...");
                    Thread.Sleep(5000);
                    break;
                }

                this.writer.WriteLine("--------------------------------------");
                this.writer.WriteLine($"This is your {tries} try. PLease consider you have {attempts} try left");
                this.writer.WriteLine("--------------------------------------");
            }



        }
    }
}
