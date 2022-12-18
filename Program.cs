IUserInterface ui = new InputOutput();
Player player = new Player();
MooGame mooGame = new MooGame(player);

PlayerController play = new PlayerController(player, ui, mooGame);

play.Run();