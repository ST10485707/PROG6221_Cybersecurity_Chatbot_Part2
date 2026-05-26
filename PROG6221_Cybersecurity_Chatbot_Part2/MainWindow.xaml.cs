using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

// ============================================================
// PROG6221 - Cybersecurity Chatbot - Part 2 (WPF GUI)
// Student: ST10485707
// Description: WPF GUI version of the Cybersecurity Awareness Chatbot
//              This file handles the user interface and chat display
// ============================================================

namespace PROG6221_Cybersecurity_Chatbot_Part2
{
    public partial class MainWindow : Window
    {
        // ========== CLASS VARIABLES ==========
        // Creates an instance of ChatbotLogic which contains all the response logic
        // This separates the UI code from the business logic (clean code practice)
        private ChatbotLogic chatbot = new ChatbotLogic();

        // Stores the user's name for personalisation throughout the conversation
        private string userName = "";

        // ========== CONSTRUCTOR ==========
        // Runs when the window first opens
        public MainWindow()
        {
            InitializeComponent();      // Loads the XAML design
            AddWelcomeMessage();        // Displays the initial bot greeting
        }

        // ========== TASK 4: WELCOME MESSAGE ==========
        // Displays the bot's opening messages when the application starts
        private void AddWelcomeMessage()
        {
            AddToChat("Bot", "Hello! Welcome to the Cybersecurity Awareness Bot!", "Green");
            AddToChat("Bot", "I'm here to help you stay safe online.", "Green");
            AddToChat("Bot", "What is your name?", "Green");
        }

        // ========== TASK 7: ADD MESSAGE TO CHAT DISPLAY ==========
        // This method adds a message to the chat list box with the specified color
        // Parameters:
        //   - sender: Who is speaking ("Bot", "You", or "System")
        //   - message: The text content to display
        //   - color: The text color (Green for bot, Magenta for user, etc.)
        private void AddToChat(string sender, string message, string color)
        {
            // Format the message with brackets around the sender's name
            // Example: "[Bot] Hello!"
            string formattedMessage = $"[{sender}] {message}";

            // Add the message to the chat display list box
            ChatDisplay.Items.Add(new ListBoxItem
            {
                Content = formattedMessage,
                Foreground = GetBrush(color)  // Apply the specified color
            });

            // Auto-scroll to the bottom to show the newest message
            ChatDisplay.ScrollIntoView(ChatDisplay.Items[ChatDisplay.Items.Count - 1]);
        }

        // ========== TASK 7: COLOR HELPER METHOD ==========
        // Converts a color name string to a WPF Brush object
        // This allows dynamic coloring of chat messages
        private System.Windows.Media.Brush GetBrush(string color)
        {
            switch (color.ToLower())
            {
                case "green": return System.Windows.Media.Brushes.LightGreen;   // Bot messages
                case "magenta": return System.Windows.Media.Brushes.Magenta;   // User messages
                case "cyan": return System.Windows.Media.Brushes.Cyan;         // Header/title
                case "yellow": return System.Windows.Media.Brushes.Yellow;     // System alerts
                default: return System.Windows.Media.Brushes.White;            // Default fallback
            }
        }

        // ========== SEND BUTTON CLICK HANDLER ==========
        // Triggered when the user clicks the "Send" button
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessUserInput();
        }

        // ========== ENTER KEY HANDLER ==========
        // Allows the user to press Enter instead of clicking the Send button
        // This creates a more natural chat experience
        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessUserInput();
            }
        }

        // ========== MAIN PROCESSING METHOD ==========
        // This is the core method that handles user input and generates responses
        // It validates input, stores the user's name, and calls the chatbot logic
        private void ProcessUserInput()
        {
            // Get the user's message and remove any leading/trailing spaces
            string userMessage = UserInput.Text.Trim();

            // ========== TASK 6: INPUT VALIDATION ==========
            // Check if the user typed nothing or just spaces
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                AddToChat("System", "Please type something!", "Yellow");
                UserInput.Clear();
                UserInput.Focus();
                return;  // Exit the method - don't process empty input
            }

            // Display the user's message in the chat (Magenta color)
            AddToChat("You", userMessage, "Magenta");

            // ========== TASK 4: GET USER'S NAME ==========
            // First time interaction - capture the user's name
            if (string.IsNullOrEmpty(userName))
            {
                userName = userMessage;

                // ========== TASK 5: MEMORY & RECALL ==========
                // Pass the user's name to the ChatbotLogic class so it can remember it
                // This enables personalised responses throughout the conversation
                chatbot.SetUserName(userName);

                // Display personalised welcome message using the user's name
                AddToChat("Bot", $"Nice to meet you, {userName}! ", "Green");
                AddToChat("Bot", "You can ask me about passwords, scams, privacy, phishing, or safe browsing.", "Green");
                AddToChat("Bot", "Type 'exit' to quit.", "Green");

                // Clear input box and refocus for next message
                UserInput.Clear();
                UserInput.Focus();
                return;
            }

            // ========== CHECK FOR EXIT COMMAND ==========
            // Allow user to end the conversation gracefully
            if (userMessage.ToLower() == "exit")
            {
                AddToChat("Bot", $"Goodbye, {userName}! Stay safe online!", "Green");

                // Disable input controls so user cannot type after exit
                UserInput.IsEnabled = false;
                SendButton.IsEnabled = false;
                return;
            }

            // ========== TASKS 3, 4, 5, 6: GET BOT RESPONSE ==========
            // Pass the user's message to ChatbotLogic which handles:
            //   - Keyword recognition (password, scam, privacy, phish, browse)
            //   - Random responses from lists
            //   - Conversation flow ("tell me more", "another tip")
            //   - Memory & recall (remembers user name and interests)
            string response = chatbot.GetBotResponse(userMessage);

            // Display the bot's response in Green
            AddToChat("Bot", response, "Green");

            // Clear the input box and refocus for the next message
            UserInput.Clear();
            UserInput.Focus();
        }
    }
}