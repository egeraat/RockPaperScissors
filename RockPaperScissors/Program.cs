using System;

namespace RockPaperScissors
{
    class PlayerChoice
    {
        public int GetUserChoice()
        {
            Console.WriteLine("Kies steen (1), papier (2) of schaar (3): ");
            return int.Parse(Console.ReadLine());
        }
    }

    class Computer
    {
        static Random random = new Random();

        public int GetChoice()
        {
            return random.Next(1, 4); //random nummer tussen 1 tot 3
        }

        public string ChoiceResult(int choice)
        {
            switch (choice)
            {
                case 1:
                    return "steen";
                case 2:
                    return "papier";
                case 3:
                    return "schaar";
                default:
                    return "ongeldige keuze";
            }
        }

        public string DetermineWinner(int playerChoice, int computerChoice) //berekent wie wint
        {
            if (playerChoice == computerChoice) //als beide hetzelfde antwoord geven
                return "Gelijkspel";

            if ((playerChoice == 1 && computerChoice == 3) ||//steen (1) verslaat schaar (3)
                (playerChoice == 2 && computerChoice == 1) ||//papier (2) verslaat steen (1)
                (playerChoice == 3 && computerChoice == 2))//schaar (3) verslaat papier (2)
                return "Win";

            return "Verlies";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool continuePlaying = true;
            PlayerChoice player = new PlayerChoice();
            Computer computer = new Computer();

            int playerScore = 0;
            int computerScore = 0;

            while (continuePlaying)
            {
                int userChoice = player.GetUserChoice();
                int computerChoice = computer.GetChoice();
                string computerChoiceStr = computer.ChoiceResult(computerChoice);
                string result = computer.DetermineWinner(userChoice, computerChoice);

                Console.WriteLine($"Computer koos: {computerChoiceStr}");
                Console.WriteLine($"Resultaat: {result}");

                if (result == "Win")
                    playerScore++;
                else if (result == "Verlies")
                    computerScore++;

                Console.WriteLine($"Score - Speler: {playerScore}, Computer: {computerScore}");
                Console.WriteLine("Klik [E] voor nog een ronde of klik een andere toets om af te sluiten");
                string response = Console.ReadLine();
                continuePlaying = response.Trim().ToLower() == "e";
            }
        }
    }
}
