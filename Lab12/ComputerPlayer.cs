using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab12
{
    internal class ComputerPlayer : Player
    {
        public ComputerPlayer(string computerName)
        {
            this.Name = computerName;
        }

        public override void GenerateRoshambo()
        {
            if (this.Name == "Dwayne TheRock Johnson")
                this.Roshambo = "Rock";
            else
            {
                List<string> options = new List<string>() { "Rock", "Paper", "Scissors" };
                string option = options.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                this.Roshambo = option;
            }
        }
    }
}