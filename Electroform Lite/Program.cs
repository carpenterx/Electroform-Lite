TestBasicException();

static void TestBasicException()
{
    DateTime date = DateTime.UtcNow.Date;
    //date = date.AddDays(1);
    try
    {
        ValidateBirthDate(date);
        Console.WriteLine("Store birth date in database");
    }
    catch (Exception)
    {
        Console.WriteLine("ERROR: Birth date is in the future");
    }
}

static void ValidateBirthDate(DateTime birthDate)
{
    try
    {
        if (birthDate > DateTime.UtcNow.Date)
        {
            throw new Exception();
        }
    }
    catch (Exception)
    {
        throw;
    }
}
