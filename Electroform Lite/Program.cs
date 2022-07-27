using Electroform_Lite;

//TestBasicException();
//TestCustomException();
TestRethrowCustomException();

static void TestRethrowCustomException()
{
    try
    {
        RethrowCustomException();
    }
    catch (BirthDateException ex)
    {
        Console.WriteLine($"ERROR: {ex.Message}");
        Console.WriteLine("No time travellers allowed");
    }
}

static void RethrowCustomException()
{
    DateTime date = DateTime.UtcNow.Date;
    date = date.AddDays(1);
    try
    {
        ValidateBirthDateCustom(date);
        Console.WriteLine("Store birth date in database");
    }
    catch (BirthDateException)
    {
        throw;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"EXCEPTION: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("Clean up input form");
    }
}

/*static void TestCustomException()
{
    DateTime date = DateTime.UtcNow.Date;
    //date = date.AddDays(1);
    try
    {
        ValidateBirthDateCustom(date);
        Console.WriteLine("Store birth date in database");
    }
    catch (BirthDateException ex)
    {
        Console.WriteLine($"ERROR: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"EXCEPTION: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("Clean up input form");
    }
}*/

static void ValidateBirthDateCustom(DateTime birthDate)
{
    try
    {
        if (birthDate > DateTime.UtcNow.Date)
        {
            throw new BirthDateException("Birth date is in the future");
        }
        else
        {
            if (DateTime.UtcNow.Year - birthDate.Year < 18)
            {
                throw new Exception("You are not old enough to create an account");
            }
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
