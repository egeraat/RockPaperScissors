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
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool continuePlaying = true;
            PlayerChoice player = new PlayerChoice();
            Computer computer = new Computer();

            while (continuePlaying)
            {
                int userChoice = player.GetUserChoice();
                int computerChoice = computer.GetChoice();
                string computerChoiceStr = computer.ChoiceResult(computerChoice);
                Console.WriteLine($"Computer koos: {computerChoiceStr}");
                Console.WriteLine("Klik [E] voor nog een ronde of klik een andere toets om af te sluiten");
                string response = Console.ReadLine();
                continuePlaying = response.Trim().ToLower() == "e";
            }
        }
    }
}
