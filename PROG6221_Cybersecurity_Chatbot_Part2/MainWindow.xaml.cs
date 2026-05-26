using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PROG6221_Cybersecurity_Chatbot_Part2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddWelcomeMessage();
        }

        private void AddWelcomeMessage()
        {
            AddToChat("Bot", "Hello! Welcome to the Cybersecurity Awareness Bot!", "Green");
            AddToChat("Bot", "I'm here to help you stay safe online.", "Green");
            AddToChat("Bot", "Please enter your name to begin.", "Green");
        }

        private void AddToChat(string sender, string message, string color)
        {
            string formattedMessage = $"[{sender}] {message}";

            ChatDisplay.Items.Add(new ListBoxItem
            {
                Content = formattedMessage,
                Foreground = GetBrush(color)
            });

            // Auto-scroll to bottom
            ChatDisplay.ScrollIntoView(ChatDisplay.Items[ChatDisplay.Items.Count - 1]);
        }

        private System.Windows.Media.Brush GetBrush(string color)
        {
            switch (color.ToLower())
            {
                case "green": return System.Windows.Media.Brushes.LightGreen;
                case "magenta": return System.Windows.Media.Brushes.Magenta;
                case "cyan": return System.Windows.Media.Brushes.Cyan;
                case "yellow": return System.Windows.Media.Brushes.Yellow;
                default: return System.Windows.Media.Brushes.White;
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessUserInput();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessUserInput();
            }
        }

        private void ProcessUserInput()
        {
            string userMessage = UserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                AddToChat("System", "Please type something!", "Yellow");
                UserInput.Clear();
                UserInput.Focus();
                return;
            }

            AddToChat("You", userMessage, "Magenta");

            // For now, just echo back - we'll add real responses later
            AddToChat("Bot", $"You said: {userMessage}", "Green");

            UserInput.Clear();
            UserInput.Focus();
        }
    }
}