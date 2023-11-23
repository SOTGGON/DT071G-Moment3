using System;

namespace Guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            GuestbookController guestbookcontoller = new GuestbookController();
            guestbookcontoller.LoadEntriesFromFile();

            while (true)
            {
                Console.WriteLine("GUESTBOOK");
                Console.WriteLine("1. Skriv i gästboken\n2. Ta bort inlägg\n3. Visa alla meddelanden\n4. Avsluta");
                Console.Write("Välj en åtgärd: ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            guestbookcontoller.AddEntry();
                            Console.Clear();
                            break;
                        case 2:
                            guestbookcontoller.RemoveEntry();
                            Console.Clear();
                            break;
                        case 3:
                            guestbookcontoller.DisplayAllEntries();
                            Console.Clear();
                            break;
                        case 4:
                            guestbookcontoller.SaveEntriesToFile();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Ogiltigt alternativ.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning, vänligen ange ett nummer.");
                }
            }
        }
    }
}