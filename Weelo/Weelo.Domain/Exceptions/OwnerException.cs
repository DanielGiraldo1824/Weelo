namespace Weelo.Domain.Exception
{
    [System.Serializable]
    public class OwnerException : AppException
    {
        public OwnerException() { }
        public OwnerException(string message) : base(message) { }
        public OwnerException(string message, System.Exception inner) : base(message, inner) { }
        protected OwnerException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
