using System;
using System.Threading;

namespace CybersecurityChatbot
{
    public static class UIHelper
    {
        public static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string art = @"
    ╔════════════════════════════════════════════════════════════════════════════╗
    ║ ║
    ║ 🔐 CYBERSECURITY 🔐 ║
    ║ AWARENESS BOT ║
    ║ ║
    ╠════════════════════════════════════════════════════════════════════════════╣
    ║ ║
    ║ ╔═══╗ ╔════╗ ╔═══╗ ╔════╗ ╔═══╗ ╔════╗ ╔═══╗ ╔════╗ ║
    ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║
    ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║
    ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║
    ║ ╚═══╝ ╚════╝ ╚═══╝ ╚════╝ ╚═══╝ ╚════╝ ╚═══╝ ╚════╝ ║
    ║ ║
    ║ 'Stay Safe Online - South Africa' ║
    ║ ║
    ╚════════════════════════════════════════════════════════════════════════════╝";
            Console.WriteLine(art);
            Console.ResetColor();
        }

        public static void DrawBorder()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('═', 80));
            Console.ResetColor();
        }

        public static void TypewriterEffect(string message, int delayMs = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
        }
    }
}