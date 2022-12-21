
namespace Smells.Controllers;

public class MooController
{
    public bool gameOn = true;
    public bool roundOn;
    public string input;
    private string goal;

    private IUserInterface ui;
    private IPlayer player;
    private IMooGame mooGame;

    public MooController(IPlayer player, IUserInterface ui, IMooGame moo)
    {
        this.player = player;
        this.ui = ui;
        mooGame = moo;
    }

    public void Run()
    {
        ui.PutString(player.NameString());
        player.Name = ui.GetString();

        do
        {
            goal = mooGame.CreateRandomNumber();
            Display();
            WhilePlaying(goal);
            Continue(player.NrOfGuesses);

        } while (gameOn);
    }

    private void Display()
    {
        ui.PutString(mooGame.NewGameString());
        ui.PutString(mooGame.PracticeString());
    }

    public void WhilePlaying(string goal)
    {
        do
        {
            roundOn = true;
            input = ui.GetString();
            ui.PutString(mooGame.CheckScoreString(goal, input));

            if (goal == input)
            {
                player.SaveScore(player.Name, player.NrOfGuesses);
                mooGame.showTopList();
                roundOn = false;
            }

        } while (roundOn);
    }

    public bool Continue(int guesses)
    {
        ui.PutString(mooGame.ContinueString(guesses));

        input = ui.GetString();

        if (input != null && input != "" && input.Substring(0, 1) == "n")
        {
            return gameOn = false;
        }

        player.NrOfGuesses = 0;

        return gameOn;
    }
}