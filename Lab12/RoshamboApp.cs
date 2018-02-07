using System;

namespace Lab12
{
    internal class RoshamboApp
    {
        public static UserPlayer userPlayer = GetUserPlayer();
        public static ComputerPlayer computerPlayer = GetComputerPlayer();

        public static void InitApp()
        {
            GetRPS(userPlayer, computerPlayer);
            FigureOutWhoWon(userPlayer, computerPlayer);
        }

        private static void GetRPS(UserPlayer userPlayer, ComputerPlayer computerPlayer)
        {
            userPlayer.GenerateRoshambo();
            computerPlayer.GenerateRoshambo();
        }

        private static void FigureOutWhoWon(UserPlayer userPlayer, ComputerPlayer computerPlayer)
        {
            switch (userPlayer.Roshambo)
            {
                case "Rock":
                    switch (computerPlayer.Roshambo)
                    {
                        case "Rock":
                            PrintResults("It is a draw.", userPlayer, computerPlayer);
                            break;
                        case "Paper":
                            PlayerRecord("npc", userPlayer, computerPlayer);
                            PrintResults(string.Format("{0} wins.", computerPlayer.Name), userPlayer, computerPlayer);
                            break;
                        case "Scissors":
                            PlayerRecord("user", userPlayer, computerPlayer);
                            PrintResults(string.Format("{0} wins.", userPlayer.Name), userPlayer, computerPlayer);
                            break;
                        default:
                            break;
                    }
                    break;
                case "Paper":
                    switch (computerPlayer.Roshambo)
                    {
                        case "Paper":
                            PrintResults("It is a draw.", userPlayer, computerPlayer);
                            break;
                        case "Scissors":
                            PlayerRecord("npc", userPlayer, computerPlayer);
                            PrintResults(string.Format("{0} wins.", computerPlayer.Name), userPlayer, computerPlayer);
                            break;
                        case "Rock":
                            PlayerRecord("user", userPlayer, computerPlayer);
                            PrintResults(string.Format("{0} wins.", userPlayer.Name), userPlayer, computerPlayer);
                            break;
                        default:
                            break;
                    }
                    break;
                case "Scissors":
                    switch (computerPlayer.Roshambo)
                    {
                        case "Scissors":
                            PrintResults("It is a draw.", userPlayer, computerPlayer);
                            break;
                        case "Paper":
                            PlayerRecord("npc", userPlayer, computerPlayer);
                            PrintResults(string.Format("{0} wins.", computerPlayer.Name), userPlayer, computerPlayer);
                            break;
                        case "Rock":
                            PlayerRecord("user", userPlayer, computerPlayer);
                            PrintResults(string.Format("{0} wins.", userPlayer.Name), userPlayer, computerPlayer);
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        private static void PlayerRecord(string winner, UserPlayer userPlayer, ComputerPlayer computerPlayer)
        {
            if (winner == "user")
            {
                userPlayer.Wins++;
                computerPlayer.Losses++;
            }
            else
            {
                userPlayer.Losses++;
                computerPlayer.Wins++;
            }
        }

        private static void PrintResults(string response, UserPlayer userPlayer, ComputerPlayer computerPlayer)
        {
            Console.WriteLine("{0}: {1}", userPlayer.Name, userPlayer.Roshambo);
            Console.WriteLine("{0}: {1}", computerPlayer.Name, computerPlayer.Roshambo);
            Console.WriteLine(response);
            Console.WriteLine("\n\n{0} win/loss record is {1}/{2}", userPlayer.Name, userPlayer.Wins, userPlayer.Losses);
            Console.WriteLine("\n\n{0} win/loss record is {1}/{2}", computerPlayer.Name, computerPlayer.Wins, computerPlayer.Losses);
            QuitConsoleApp();
        }

        private static UserPlayer GetUserPlayer()
        {
            Console.Write("Please enter your name: ");
            return SetUpUserPlayer(Console.ReadLine());
        }

        private static UserPlayer SetUpUserPlayer(string userName)
        {
            UserPlayer userPlayer = new UserPlayer(userName);
            return userPlayer;
        }

        private static ComputerPlayer GetComputerPlayer()
        {
            Console.WriteLine("\nWho would you like to play against? ");
            Console.Write("Dwayne TheRock Johnson (D) OR The Trickster (T)");
            return SetUpComputerPlayer(Console.ReadLine());
        }

        private static ComputerPlayer SetUpComputerPlayer(string npc)
        {
            string computerName = "";

            if (npc.ToLower() == "d")
            {
                computerName = "Dwayne TheRock Johnson";
                ComputerPlayer computPlayer = new ComputerPlayer(computerName);
                return computPlayer;
            }
            else if (npc.ToLower() == "t")
            {
                computerName = "The Trickster";
                ComputerPlayer computPlayer = new ComputerPlayer(computerName);
                return computPlayer;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your input was invalid. Please try again.");
                GetComputerPlayer();
                return null;
            }
        }

        private static void QuitConsoleApp()
        {
            Console.WriteLine("\n\nPress R to repeat or any other key to exit the app.");
            ConsoleKeyInfo quitKey = Console.ReadKey();

            if (quitKey.Key.ToString().ToLower() == "r")
            {
                Console.Clear();
                InitApp();
            }
            else
            {
                return;
            }
        }
    }
}