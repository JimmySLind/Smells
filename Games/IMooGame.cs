namespace Smells.Games;

public interface IMooGame
{
    string Number { get; set; }
    string CreateRandomNumber();
    void showTopList();
    string CheckScoreString(string goal, string guess);
    string NewGameString();
    string PracticeString();
    string ContinueString(int guesses);
}