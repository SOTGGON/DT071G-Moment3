using System;

namespace Guestbook {
    class Program {
        static void Main(string[] args) {
            GuestbookEntry entry = new GuestbookEntry();
            entry.Guest = "John";
            entry.Message = "Hello, this is my entry.";

            Console.WriteLine($"Owner: {entry.Guest}, Message: {entry.Message}");
        }
    }
}