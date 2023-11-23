using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Guestbook
{
    public class GuestbookController
    {
        private List<GuestbookEntry> entries = new List<GuestbookEntry>();
        private string filePath = "guestbook.json"; // Filsökväg för att lagra meddelanden

        public void AddEntry()
        {
            Console.Write("Ange gästnamn: ");
            string guest = Console.ReadLine();

            Console.Write("Ange meddelandeinnehåll: ");
            string message = Console.ReadLine();

            if (!string.IsNullOrEmpty(guest) && !string.IsNullOrEmpty(message))
            {
                GuestbookEntry newEntry = new GuestbookEntry { Guest = guest, Message = message };
                entries.Add(newEntry);
                SaveEntriesToFile();

                Console.WriteLine("Meddelandet har lagts till i gästboken.");
            }
            else
            {
                Console.WriteLine("Varken gästnamn eller meddelandeinnehållet får vara tomt.");
            }

            Console.WriteLine("\nTryck på en tangent för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
        }

        public void RemoveEntry()
        {
            Console.WriteLine("Alla meddelanden:\n");
            for (int i = 0; i < entries.Count; i++)
            {
                entries[i].DisplayEntry(i); 
            }

            if (entries.Count > 0)
            {
                Console.Write("Ange meddelandeindexet som ska raderas: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < entries.Count)
                {
                    entries.RemoveAt(index);
                    SaveEntriesToFile();

                    Console.WriteLine("Meddelandet har tagits bort från gästboken.");
                }
                else
                {
                    Console.WriteLine("Ogiltigt index.");
                }
            }

            Console.WriteLine("\nTryck på en tangent för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayAllEntries()
        {
            Console.WriteLine("Alla meddelanden:\n");
            for (int i = 0; i < entries.Count; i++)
            {
                entries[i].DisplayEntry(i); // Skicka index till metoden DisplayEntry
            }

            Console.WriteLine("\nTryck på en tangent för att fortsätta...");
            Console.ReadKey();
            Console.Clear(); //
        }

        public void SaveEntriesToFile()
        {
            string json = JsonSerializer.Serialize(entries);
            File.WriteAllText(filePath, json);
        }

        public void LoadEntriesFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                entries = JsonSerializer.Deserialize<List<GuestbookEntry>>(json);
            }
        }
    }
}
