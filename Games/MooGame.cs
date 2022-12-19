namespace Smells.Games;

public class MooGame : IMooGame
{
    private Player player;
    public string Number { get; set; }

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
            Number += randomDigit;
        }
        return Number;
    }

    public void showTopList()
    {
        StreamReader savedData = new StreamReader("result.txt");
        List<Player> players = new List<Player>();

        string line;

        while ((line = savedData.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            Player playerData = new Player(name, guesses);

            int pos = players.IndexOf(playerData);

            if (pos < 0)
            {
                players.Add(playerData);
            }
            else
            {
                players[pos].UpdateScore(guesses);
            }
        }

        players.Sort((player1, player2) => player1.AverageScore().CompareTo(player2.AverageScore()));

        Console.WriteLine("Player   games average");

        foreach (var player in players)
        {
            Console.WriteLine($"{player.Name,-9}{player.NrOfGames,5:D}{player.AverageScore(),8:F2}");
        }

        savedData.Close();
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
        return "New game:\n";
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