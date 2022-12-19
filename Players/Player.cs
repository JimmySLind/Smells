namespace Smells.Players;

public class Player : IPlayer
{
    public string Name { get; set; }
    public int NrOfGames { get; set; }
    public int NrOfGuesses { get; set; }

    public Player()
    {
    }

    public Player(string name, int nrOfGuesses)
    {
        Name = name;
        NrOfGuesses = nrOfGuesses;
        NrOfGames = 1;
    }

    public void UpdateScore(int guesses)
    {
        NrOfGuesses += guesses;
        NrOfGames++;
    }

    public double AverageScore()
    {
        return (double)NrOfGuesses / NrOfGames;
    }

    public void SaveScore(string name, int nrOfGuesses)
    {
        StreamWriter output = new StreamWriter("result.txt", append: true);
        output.WriteLine(name + "#&#" + nrOfGuesses);
        output.Close();
    }

    public override bool Equals(object player)
    {
        return Name.Equals(((Player)player).Name);
    }


    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public string NameString()
    {
        return "Enter your user name:\n";
    }
}