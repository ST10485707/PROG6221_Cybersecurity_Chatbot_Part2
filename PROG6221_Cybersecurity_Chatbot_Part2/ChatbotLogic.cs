using System;

namespace PROG6221_Cybersecurity_Chatbot_Part2
{
    public class ChatbotLogic
    {
        // Random number generator
        private Random random = new Random();

        // Track the last topic the user asked about
        private string lastTopic = "";

        // ========== MEMORY & RECALL ==========
        // Store user's name
        private string userName = "";

        // Store user's favourite cybersecurity topic
        private string userInterest = "";

        // Check if user has shared an interest
        private bool hasInterest = false;

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

        // Set user's name (called from MainWindow)
        public void SetUserName(string name)
        {
            userName = name;
        }

        // Get user's name
        public string GetUserName()
        {
            return userName;
        }

        public string GetBotResponse(string input)
        {
            input = input.ToLower();

            // ========== MEMORY & RECALL: Check if user is sharing an interest ==========
            if (input.Contains("interested in") || input.Contains("i like") || input.Contains("my favourite"))
            {
                if (input.Contains("privacy"))
                {
                    userInterest = "privacy";
                    hasInterest = true;
                    return $"Great! I'll remember that you're interested in privacy. As someone who cares about privacy, you might want to review your app permissions regularly. 🔒";
                }
                else if (input.Contains("password"))
                {
                    userInterest = "passwords";
                    hasInterest = true;
                    return $"Excellent! I'll remember that you're interested in password safety. Strong passwords are the first line of defense! 🔐";
                }
                else if (input.Contains("scam"))
                {
                    userInterest = "scams";
                    hasInterest = true;
                    return $"Good to know! I'll remember you want to learn about scams. Staying informed is the best protection! 🚨";
                }
            }

            // ========== CONVERSATION FLOW ==========
            // Check if user wants more information on the same topic
            if (input.Contains("tell me more") || input.Contains("another tip") ||
                input.Contains("explain more") || input.Contains("more tips") ||
                input.Contains("continue"))
            {
                if (!string.IsNullOrEmpty(lastTopic))
                {
                    string response = GetResponseByTopic(lastTopic);

                    // Add personalised recall if user has interest
                    if (hasInterest && !string.IsNullOrEmpty(userName))
                    {
                        return $"For you, {userName}, who's interested in {userInterest}: {response}";
                    }
                    else if (!string.IsNullOrEmpty(userName))
                    {
                        return $"{userName}, here's another tip: {response}";
                    }
                    return response;
                }
                else
                {
                    return "I don't have a current topic. Please ask me about passwords, scams, privacy, phishing, or safe browsing first.";
                }
            }

            // Normal keyword detection with personalisation
            if (input.Contains("password"))
            {
                lastTopic = "password";
                string response = GetRandomResponse(passwordResponses);

                // Add personalised recall
                if (hasInterest && userInterest == "passwords")
                {
                    return $"Since you're interested in passwords, {userName}: {response}";
                }
                else if (!string.IsNullOrEmpty(userName))
                {
                    return $"{userName}, {response}";
                }
                return response;
            }
            else if (input.Contains("scam"))
            {
                lastTopic = "scam";
                string response = GetRandomResponse(scamResponses);
                if (!string.IsNullOrEmpty(userName))
                {
                    return $"{userName}, {response}";
                }
                return response;
            }
            else if (input.Contains("privacy"))
            {
                lastTopic = "privacy";
                string response = GetRandomResponse(privacyResponses);
                if (!string.IsNullOrEmpty(userName))
                {
                    return $"{userName}, {response}";
                }
                return response;
            }
            else if (input.Contains("phish"))
            {
                lastTopic = "phishing";
                string response = GetRandomResponse(phishingResponses);
                if (!string.IsNullOrEmpty(userName))
                {
                    return $"{userName}, {response}";
                }
                return response;
            }
            else if (input.Contains("safe browsing") || input.Contains("browse"))
            {
                lastTopic = "browsing";
                string response = GetRandomResponse(browsingResponses);
                if (!string.IsNullOrEmpty(userName))
                {
                    return $"{userName}, {response}";
                }
                return response;
            }
            else
            {
                // Default response - don't change lastTopic
                string response = GetRandomResponse(defaultResponses);
                if (!string.IsNullOrEmpty(userName))
                {
                    return $"{userName}, {response}";
                }
                return response;
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