namespace Common
{
    public class TransactionResult<TResult>
    {
        public TransactionResult()
        {
        }

        public TransactionResult(TResult result, string message) : this()
        {
            Result = result;
            Message = message;
        }

        public TResult Result { get; }
        public string Message { get; }
    }
}
