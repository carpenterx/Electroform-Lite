using Electroform_Lite.Models;

GenericArray<string> genericArray = new(4);

genericArray.Push("a");
genericArray.Push("b");
genericArray.Push("c");
genericArray.Push("d");

Console.WriteLine(genericArray.GetItemAt(0));
genericArray.SetItemAt(0, "A");
Console.WriteLine(genericArray.GetItemAt(0));

Console.WriteLine($"arr[0] = {genericArray.GetItemAt(0)}, arr[1] = {genericArray.GetItemAt(1)}");
//genericArray.SwapItems(0, 1);
//genericArray.SwapItems("A", "b");
//genericArray.SwapItems(0, "b");
genericArray.SwapItems("A", 1);
Console.WriteLine($"arr[0] = {genericArray.GetItemAt(0)}, arr[1] = {genericArray.GetItemAt(1)}");