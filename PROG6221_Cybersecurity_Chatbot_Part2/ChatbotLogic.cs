using System;

namespace PROG6221_Cybersecurity_Chatbot_Part2
{
    public class ChatbotLogic
    {
        public string GetBotResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("password"))
            {
                return "Use strong passwords! Make them at least 12 characters with uppercase, lowercase, numbers, and symbols. Never reuse passwords across different sites.";
            }
            else if (input.Contains("scam"))
            {
                return "Watch out for scams! Never share personal information with unknown callers or emails. Legitimate companies won't ask for your password or OTP.";
            }
            else if (input.Contains("privacy"))
            {
                return "Protect your privacy! Review your social media settings, use private browsing when needed, and be careful what personal info you share online.";
            }
            else if (input.Contains("phish"))
            {
                return "Watch for phishing emails! Check the sender's email address, don't click suspicious links, and never share personal information via email.";
            }
            else if (input.Contains("safe browsing") || input.Contains("browse"))
            {
                return "For safe browsing, look for 'https://' in the URL, avoid public Wi-Fi for sensitive transactions, and keep your browser updated.";
            }
            else
            {
                return "I can help with password safety, phishing emails, safe browsing, scams, or privacy. What would you like to know?";
            }
        }
    }
}