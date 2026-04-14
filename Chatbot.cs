using System;
using System.IO;
using System.Media;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        private ResponseHandler responseHandler;
        private string userName;
        private bool isRunning;

        public Chatbot()
        {
            responseHandler = new ResponseHandler();
            isRunning = true;
        }

        public void Start()
        {
            PlayVoiceGreeting();
            ShowHeader();
            GetUserName();
            RunConversationLoop();
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                // Look for greeting.wav in the program's folder
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");

                if (File.Exists(audioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.PlaySync(); // Plays and waits to finish
                    }
                }
                else
                {
                    Console.WriteLine("\n[Voice greeting file not found. Create 'greeting.wav' in the output folder]");
                    Thread.Sleep(1500);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio note: {ex.Message}]");
            }
        }

        private void ShowHeader()
        {
            Console.Clear();
            UIHelper.DisplayAsciiArt();
            UIHelper.DrawBorder();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" 🔒 CYBERSECURITY AWARENESS BOT 🔒");
            Console.WriteLine(" Your guide to staying safe online in South Africa");
            UIHelper.DrawBorder();
            Console.ResetColor();
        }

        private void GetUserName()
        {
            UIHelper.TypewriterEffect("\n📝 What's your name? ", 40);
            Console.ForegroundColor = ConsoleColor.Cyan;
            userName = Console.ReadLine();
            Console.ResetColor();

            // Keep asking until user enters a name
            while (string.IsNullOrWhiteSpace(userName))
            {
                UIHelper.TypewriterEffect("🤖 I didn't catch that. Please tell me your name: ", 40);
                Console.ForegroundColor = ConsoleColor.Cyan;
                userName = Console.ReadLine();
                Console.ResetColor();
            }

            UIHelper.TypewriterEffect($"\n✨ Hello, {userName}! ✨", 35);
            UIHelper.TypewriterEffect("\n👋 Welcome to your Cybersecurity Awareness Assistant.\n", 35);
        }

        private void RunConversationLoop()
        {
            UIHelper.DrawBorder();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("💡 TIP: Type 'help' to see what you can ask, or 'quit' to exit");
            Console.ResetColor();
            UIHelper.DrawBorder();

            while (isRunning)
            {
                // Get user input
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"\n{userName} > ");
                string userInput = Console.ReadLine();
                Console.ResetColor();

                // Check for empty input
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    UIHelper.TypewriterEffect("🤖 I didn't hear anything. Please type a question! 🗣️", 30);
                    continue;
                }

                // Check for exit command
                if (userInput.ToLower() == "quit" || userInput.ToLower() == "exit")
                {
                    UIHelper.TypewriterEffect($"\n🌟 Stay safe online, {userName}! 🌟", 40);
                    UIHelper.TypewriterEffect("\nRemember: Think before you click! 🔐\n", 40);
                    isRunning = false;
                    break;
                }

                // Check for help command
                if (userInput.ToLower() == "help")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n📚 Here's what you can ask me about:");
                    foreach (string topic in responseHandler.GetHelpTopics())
                    {
                        Console.WriteLine($" • {topic}");
                    }
                    Console.ResetColor();
                    continue;
                }

                // Get and display the bot's response
                string response = responseHandler.GetResponse(userInput);
                Console.Write("🤖 ");
                UIHelper.TypewriterEffect(response, 25);
                Console.WriteLine();
            }
        }
    }
}