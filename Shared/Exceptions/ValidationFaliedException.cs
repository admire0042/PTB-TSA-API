namespace Shared.Exceptions
{

    public class ValidationFaliedException : Exception
    {
        public string Code { get; set; }
        public ValidationFaliedException()
        { }

        public ValidationFaliedException(string message, string code = "ArgumentIsNull")
            : base(message)
        {
            Code = code;
        }

        public ValidationFaliedException(string message, Exception innerException)
            : base(message, innerException)
        { }


    }
}