using System;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set console window properties
            Console.Title = "Cybersecurity Awareness Bot";
            Console.WindowWidth = 100;
            Console.WindowHeight = 40;

            try
            {
                // Create and start the chatbot
                Chatbot bot = new Chatbot();
                bot.Start();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n⚠️ An error occurred: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}