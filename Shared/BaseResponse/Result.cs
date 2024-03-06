namespace Shared.BaseResponse
{
    public class Result
    {
        public bool IsSuccessful { get; set; }
        //public string Error { get; set; }
        public string ResponseStatus { get; set; }
        public string StatusCode { get; set; }
        public object Message { get; set; }

        public Result(bool isSuccess, string message, string responseStatus, string statusCode)
        {
            IsSuccessful = isSuccess;
            Message = message;
            ResponseStatus = responseStatus;
            StatusCode = statusCode;
        }

        public static Result Response(bool isSuccess, string message, string responseStatus, string statusCode) 
        {
            return new Result
            (
                isSuccess,
                message,
                statusCode,
                responseStatus
            );
        }

        protected Result(bool isSuccess, string error)
        {
            if (isSuccess && !string.IsNullOrEmpty(error))
                throw new InvalidOperationException();
            IsSuccessful = isSuccess;
            //Error = error;
            Message = error;
            ResponseStatus = error;
        }

        protected Result(bool isSuccess, string error, string responseCode)
        {
            if (isSuccess && !string.IsNullOrEmpty(error))
                throw new InvalidOperationException();
            IsSuccessful = isSuccess;
            //Error = error;
            StatusCode = responseCode;
            Message = error;
            ResponseStatus = error;
        }

        public static Result Fail(string message)
        {
            return new Result(false, message) { StatusCode = "300" };
        }

        public static Result Fail(string message, string code)
        {
            return new Result(false, message) { StatusCode = code };
        }

        public static Result<T> Fail<T>(string message, T t)
        {
            return new Result<T>(t, false, string.Empty) { ResponseStatus = message, StatusCode = "400" };
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default(T), false, message) { StatusCode = "300" };
        }

        public static Result<T> Fail<T>(string message, string responseCode)
        {
            var response = new Result<T>(default(T), false, message, responseCode);
            response.ResponseStatus = message;
            return response;
        }

        public static Result<T> Fail<T>(T value, string message, string responseCode)
        {
            var response = new Result<T>(value, false, message, responseCode);
            response.ResponseStatus = message;
            return response;
        }

        public static Result Ok()
        {
            return new Result(true, string.Empty) { StatusCode = "200" };
        }

        public static Result Ok(string message)
        {
            return new Result(true, string.Empty) { ResponseStatus = message, StatusCode = "200", Message = message};
        }

        public static Result Ok(object value, string message)
        {
            return new Result<object>(value, true, string.Empty) { ResponseStatus = message, StatusCode = "200"};
        }
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, string.Empty) { StatusCode = "200" };
        }

        public static Result<T> Ok<T>(T value, string message)
        {
            return new Result<T>(value, true, string.Empty) { ResponseStatus = message, StatusCode = "200", Message = message };
        }
        public static Result Combine(params Result[] results)
        {
            foreach (var result in results)
            {
                if (!result.IsSuccessful)
                    return result;
            }
            return Ok();
        }
    }

    public class Result<T> : Result
    {
        private readonly T _value;

        public new object Message
        {
            get
            {
                return _value;
            }

            set { }

        }

        protected internal Result(T value, bool isSuccess, string error) : base(isSuccess, error)
        {
            _value = value;
        }

        protected internal Result(T value, bool isSuccess, string error, string responseCode) : base(isSuccess, error, responseCode)
        {
            _value = value;
        }
    }
}
