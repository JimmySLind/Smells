namespace Smells.IO
{
    public interface IUserInterface
    {
        void PutString(string text);
        string GetString();
        void Exit();
    }
}