using System;
using System.Collections;
using System.Dynamic;

internal class Program
{
    static void Main(string[] args)
    {
        var friends = new List<string> { "a", "b", "c" };
        // var partyFriends = 1;

        string message = "hi";
        SendMessage(out message);
    }

    static public void SendMessage(out string message)
    {
        message = "Hello";
        Console.WriteLine(message);
    }
}
