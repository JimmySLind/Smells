IUserInterface ui = new InputOutput();
Player player = new Player();
MooGame mooGame = new MooGame(player);

Controller play = new Controller(player, ui, mooGame);

play.Run();