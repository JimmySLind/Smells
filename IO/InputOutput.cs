namespace Smells.IO
{
    public class InputOutput : IUserInterface
    {
        public void Exit()
        {
            Environment.Exit(0);
        }

        public string GetString()
        {
            return Console.ReadLine();
        }

        public void PutString(string text)
        {
            Console.WriteLine(text);
        }
    }
}
