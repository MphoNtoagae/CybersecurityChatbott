using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class ResponseHandler
    {
        private Dictionary<string, string> responses;

        public ResponseHandler()
        {
            responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // Add all responses (Question keyword → Answer)
            responses.Add("how are you", "I'm doing great, thank you for asking! 😊 Ready to help you learn about cybersecurity.");

            responses.Add("purpose", "My purpose is to educate South African citizens about cybersecurity threats like phishing scams, weak passwords, and unsafe browsing habits.");

            responses.Add("what can i ask", "You can ask me about:\n 🔑 Password safety\n 🎣 Phishing emails\n 🌐 Safe browsing\n 📱 General cybersecurity advice");

            responses.Add("password", "✅ PASSWORD SAFETY:\n • Use 12+ characters\n • Mix uppercase, lowercase, numbers, and symbols\n • Never reuse passwords\n • Use a password manager");

            responses.Add("phishing", "⚠️ PHISHING WARNING!\n • Check sender email address\n • Don't click suspicious links\n • Look for spelling errors\n • Never share personal info via email");

            responses.Add("safe browsing", "🌐 SAFE BROWSING TIPS:\n • Look for 'https://' and padlock 🔒\n • Avoid public WiFi for banking\n • Keep browser updated\n • Don't download from untrusted sites");

            responses.Add("help", "Type 'quit' to exit, or ask about: passwords, phishing, safe browsing");
        }

        public string GetResponse(string userInput)
        {
            // Check for empty input
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "I didn't catch that. Could you please say something? 🗣️";
            }

            // Convert to lowercase for matching
            string lowerInput = userInput.ToLower().Trim();

            // Check each keyword
            foreach (var kvp in responses)
            {
                if (lowerInput.Contains(kvp.Key))
                {
                    return kvp.Value;
                }
            }

            // Default response for unknown questions
            return "I didn't quite understand that. Could you rephrase? 🤔 Try asking about 'password', 'phishing', or 'safe browsing'.";
        }

        public List<string> GetHelpTopics()
        {
            return new List<string>
            {
                "🔐 Password Safety",
                "🎣 Phishing Emails",
                "🌐 Safe Browsing",
                "💬 General Questions"
            };
        }
    }
}
