using Electroform_Lite;

//TestBasicException();
TestCustomException();

static void TestCustomException()
{
    DateTime date = DateTime.UtcNow.Date;
    date = date.AddDays(1);
    try
    {
        ValidateBirthDateCustom(date);
        Console.WriteLine("Store birth date in database");
    }
    catch (BirthDateException ex)
    {
        Console.WriteLine($"ERROR: {ex.Message}");
    }
}

static void ValidateBirthDateCustom(DateTime birthDate)
{
    try
    {
        if (birthDate > DateTime.UtcNow.Date)
        {
            throw new BirthDateException("Birth date is in the future");
        }
    }
    catch (Exception)
    {
        throw;
    }
}

/*static void TestBasicException()
{
    DateTime date = DateTime.UtcNow.Date;
    date = date.AddDays(1);
    try
    {
        ValidateBirthDate(date);
        Console.WriteLine("Store birth date in database");
    }
    catch (Exception)
    {
        Console.WriteLine("ERROR: Birth date is in the future");
    }
}*/

/*static void ValidateBirthDate(DateTime birthDate)
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
}*/
