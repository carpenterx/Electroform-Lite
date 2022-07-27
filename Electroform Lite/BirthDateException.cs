namespace Electroform_Lite;

internal class BirthDateException : Exception
{
    public BirthDateException()
    {
    }

    public BirthDateException(string? message) : base(message)
    {
    }
}
