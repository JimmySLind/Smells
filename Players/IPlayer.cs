namespace Smells.Players;

public interface IPlayer
{
    string Name { get; set; }
    int NrOfGames { get; set; }
    int NrOfGuesses { get; set; }
    void UpdateScore(int guesses);
    double AverageScore();
    void SaveScore(string name, int nrOfGuesses);
    bool Equals(object player);
    int GetHashCode();
    string NameString();
}