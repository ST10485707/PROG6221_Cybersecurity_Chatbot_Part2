using System;

namespace PROG6221_Cybersecurity_Chatbot_Part2
{
    public class ChatbotLogic
    {
        // Random number generator
        private Random random = new Random();

        // Track the last topic the user asked about
        private string lastTopic = "";

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

            // ========== CONVERSATION FLOW ==========
            // Check if user wants more information on the same topic
            if (input.Contains("tell me more") || input.Contains("another tip") ||
                input.Contains("explain more") || input.Contains("more tips") ||
                input.Contains("continue"))
            {
                if (!string.IsNullOrEmpty(lastTopic))
                {
                    // Return a new random response on the last topic
                    return GetResponseByTopic(lastTopic);
                }
                else
                {
                    return "I don't have a current topic. Please ask me about passwords, scams, privacy, phishing, or safe browsing first.";
                }
            }

            // Normal keyword detection
            if (input.Contains("password"))
            {
                lastTopic = "password";
                return GetRandomResponse(passwordResponses);
            }
            else if (input.Contains("scam"))
            {
                lastTopic = "scam";
                return GetRandomResponse(scamResponses);
            }
            else if (input.Contains("privacy"))
            {
                lastTopic = "privacy";
                return GetRandomResponse(privacyResponses);
            }
            else if (input.Contains("phish"))
            {
                lastTopic = "phishing";
                return GetRandomResponse(phishingResponses);
            }
            else if (input.Contains("safe browsing") || input.Contains("browse"))
            {
                lastTopic = "browsing";
                return GetRandomResponse(browsingResponses);
            }
            else
            {
                // Default response - don't change lastTopic
                return GetRandomResponse(defaultResponses);
            }
        }

        // Helper method to get random response from any array
        private string GetRandomResponse(string[] responses)
        {
            int index = random.Next(responses.Length);
            return responses[index];
        }

        // Helper method to get response based on stored topic
        private string GetResponseByTopic(string topic)
        {
            switch (topic)
            {
                case "password":
                    return GetRandomResponse(passwordResponses);
                case "scam":
                    return GetRandomResponse(scamResponses);
                case "privacy":
                    return GetRandomResponse(privacyResponses);
                case "phishing":
                    return GetRandomResponse(phishingResponses);
                case "browsing":
                    return GetRandomResponse(browsingResponses);
                default:
                    return GetRandomResponse(defaultResponses);
            }
        }
    }
}