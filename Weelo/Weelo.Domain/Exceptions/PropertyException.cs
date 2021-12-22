namespace Weelo.Domain.Exception
{
    [System.Serializable]
    public class PropertyException  : AppException
    {
        public PropertyException () { }
        public PropertyException (string message) : base(message) { }
        public PropertyException (string message, System.Exception inner) : base(message, inner) { }
        protected PropertyException (
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
