namespace Statify.Lib.Messages
{
    public enum MessageHandleResult : byte
    {
        Handled = 0,
        WrongReciever = 1,
        InvalidState = 2,
    }
}
