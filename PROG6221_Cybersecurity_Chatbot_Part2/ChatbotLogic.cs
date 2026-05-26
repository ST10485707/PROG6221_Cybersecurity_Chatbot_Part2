using System;

namespace PROG6221_Cybersecurity_Chatbot_Part2
{
    public class ChatbotLogic
    {
        // Random number generator
        private Random random = new Random();

        // Lists of random responses for different topics
        private string[] scamResponses = {
            "🚨 Scam alert! Never share your OTP or PIN with anyone. Banks will never ask for this.",
            "📞 Watch for fake calls! Scammers pretend to be from 'your bank'. Hang up and call the official number.",
            "📧 Email scams often have spelling mistakes. Check the sender's email address carefully!",
            "💰 'You won a prize!' is almost always a scam. Never pay money to receive 'winnings'."
        };

        private string[] privacyResponses = {
            "🔒 Review your privacy settings on social media at least once a month.",
            "🌐 Use private browsing (Incognito) when searching sensitive topics.",
            "📱 Check which apps have access to your location, camera, and microphone.",
            "🛡️ Two-factor authentication (2FA) adds an extra layer of privacy protection."
        };

        private string[] passwordResponses = {
            "🔐 Use at least 12 characters with uppercase, lowercase, numbers, and symbols.",
            "⚠️ Never reuse passwords across different accounts. Use a password manager!",
            "📅 Change important passwords every 3-6 months.",
            "🚫 Avoid using personal info like your name, birthday, or 'password123'."
        };

        private string[] phishingResponses = {
            "🎣 Phishing emails often create urgency: 'Your account will be closed!'",
            "✉️ Hover over links before clicking to see the real destination.",
            "🛑 Never download attachments from unknown senders.",
            "✅ Legitimate companies address you by name, not 'Dear Customer'."
        };

        private string[] browsingResponses = {
            "🌐 Look for 'https://' and a padlock icon in the address bar.",
            "📡 Avoid public Wi-Fi for banking or shopping. Use a VPN if needed.",
            "🔄 Keep your browser and extensions updated for security patches.",
            "🚫 Don't save passwords in your browser. Use a dedicated password manager."
        };

        private string[] defaultResponses = {
            "I can help with passwords, scams, privacy, phishing, or safe browsing. What would you like to know?",
            "Ask me about online safety! Topics: passwords, scams, privacy, phishing, or safe browsing.",
            "I'm here to help you stay safe online. Try asking about 'password', 'scam', or 'privacy'."
        };

        public string GetBotResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("password"))
            {
                int index = random.Next(passwordResponses.Length);
                return passwordResponses[index];
            }
            else if (input.Contains("scam"))
            {
                int index = random.Next(scamResponses.Length);
                return scamResponses[index];
            }
            else if (input.Contains("privacy"))
            {
                int index = random.Next(privacyResponses.Length);
                return privacyResponses[index];
            }
            else if (input.Contains("phish"))
            {
                int index = random.Next(phishingResponses.Length);
                return phishingResponses[index];
            }
            else if (input.Contains("safe browsing") || input.Contains("browse"))
            {
                int index = random.Next(browsingResponses.Length);
                return browsingResponses[index];
            }
            else
            {
                int index = random.Next(defaultResponses.Length);
                return defaultResponses[index];
            }
        }
    }
}