namespace Statify.Lib.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class HandleMessageAttribute: Attribute
    {
        public Type HandleType { get; set; }

        public HandleMessageAttribute(Type handleType)
        {
            HandleType = handleType;
        }
    }
}
