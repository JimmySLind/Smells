IUserInterface ui = new InputOutput();
Player player = new Player();
MooGame mooGame = new MooGame(player);

MooController play = new MooController(player, ui, mooGame);

play.Run();