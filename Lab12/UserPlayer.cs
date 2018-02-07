using System;
namespace Lab12
{
    internal class UserPlayer : Player
    {
        public UserPlayer(string userName)
        {
            base.Name = userName;
        }

        public override void GenerateRoshambo()
        {
            Console.Write("\nRock / Paper / Scissors? (R/P/S): ");
            string userInput = Console.ReadLine();

            if(userInput.ToLower() == "r")
                this.Roshambo = "Rock";
            else if (userInput.ToLower() == "p")
                this.Roshambo = "Paper";
            else if (userInput.ToLower() == "s")
                this.Roshambo = "Scissors";
            else
            {
                Console.Clear();
                Console.WriteLine("Your input was invalid.");
                GenerateRoshambo();
            }
        }
    }
}