namespace GraphicalUserInterface
{
    public interface IView
    {
        void Show();
        void Close();
    }

    public static class Delegates
    {
        public delegate void CallLoginService(string login, string password);
    }
}