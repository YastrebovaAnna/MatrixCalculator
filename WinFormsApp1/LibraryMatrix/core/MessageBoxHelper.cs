
namespace LibraryMatrix.core
{
    public static class MessageBoxHelper
    {
        public static ShowMessageDelegate ShowMessage;

        public static void Show(string message)
        {
            ShowMessage?.Invoke(message);
        }
    }
}
