namespace CW_2_s27864;

public class OverfillException : SystemException
{
    public OverfillException()
    {
    }

    public OverfillException(string message) 
        : base(message)
    {
    }

    public OverfillException(string message, System.Exception inner)
    : base(message, inner)
    {
    }
}