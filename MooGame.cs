namespace Smells
{
    public class MooGame
    {
        public string Number { get; set; }
        Player player;

        public MooGame(Player player)
        {
            this.player = player;
        }

        public string CreateRandomNumber()
        {
            Random randomGenerator = new Random();

            Number = "";

            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (Number.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                Number = Number + randomDigit;
            }
            return Number;
        }


        public void SaveScore(string name, int nrOfGuesses)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(name + "#&#" + nrOfGuesses);
            output.Close();
        }


        public void showTopList()
        {
            StreamReader input = new StreamReader("result.txt");
            List<Player> results = new List<Player>();
            string line;

            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                Player playerData = new Player(name, guesses);

                int pos = results.IndexOf(playerData);

                if (pos < 0)
                {
                    results.Add(playerData);
                }
                else
                {
                    results[pos].UpdateScore(guesses);
                }


            }

            results.Sort((p1, p2) => p1.AverageScore().CompareTo(p2.AverageScore()));

            Console.WriteLine("Player   games average");

            foreach (Player p in results)
            {
                Console.WriteLine($"{p.Name,-9}{p.NrOfGames,5:D}{p.AverageScore(),8:F2}");
            }

            input.Close();
        }

        public string CheckScoreString(string goal, string guess)
        {
            player.NrOfGuesses++;

            int cows = 0, bulls = 0;
            guess += "   ";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return $"{"BBBB".Substring(0, bulls)},{"CCCC".Substring(0, cows)}\n";
        }


        public string NewGameString()
        {
            return $"New game:\n";
        }

        public string PracticeString()
        {
            return $"For practice, number is: {Number}\n";
        }

        public string ContinueString(int guesses)
        {
            return "Correct, it took " + guesses + " guesses\nContinue?";
        }
    }
}
