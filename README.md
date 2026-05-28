# PROG6221 Cybersecurity Chatbot - Part 2 (WPF GUI)

## Student Information
- **Name:** Mila Mpengesi
- **Student Number:** ST10485707
- **Module:** Programming 2A (PROG6221)

---

## Project Overview

This is a **WPF GUI version** of the Cybersecurity Awareness Chatbot. It teaches users about online safety through conversation. The bot can:

- Recognise cybersecurity keywords (password, scam, privacy, phishing, safe browsing)
- Give random responses from lists (different tip each time)
- Handle follow-up questions like "tell me more" or "another tip"
- Remember the user's name and interests
- Detect user emotions (worried, curious, frustrated) and respond with empathy

---

## How to Run the Program

### Prerequisites
- Windows operating system
- Visual Studio 2022 or later
- .NET 10.0 SDK

### Steps to Run
1. Clone or download this repository
2. Open `PROG6221_Cybersecurity_Chatbot_Part2.slnx` in Visual Studio
3. Press `F5` or click the green **Play** button
4. The chatbot window will open
5. Enter your name when prompted
6. Ask about cybersecurity topics
7. Type `exit` to quit

---

## Features Implemented

| Task | Feature | Status |
|------|---------|--------|
| Task 2 | Keyword Recognition (password, scam, privacy, phish, browse) | ✅ |
| Task 3 | Random Responses from Arrays/Lists | ✅ |
| Task 4 | Conversation Flow ("tell me more", "another tip") | ✅ |
| Task 5 | Memory & Recall (remembers name and interests) | ✅ |
| Task 6 | Sentiment Detection (worried, curious, frustrated) | ✅ |
| Task 7 | WPF GUI with Colours (Cyan, Green, Magenta) | ✅ |

---

## How to Use the Chatbot

### Example Conversation
User: Mila
Bot: Nice to meet you, Mila! 😊

User: I am interested in privacy
Bot: Great! I'll remember that you're interested in privacy...

User: privacy
Bot: Mila, 🔒 Review your privacy settings on social media...

User: tell me more
Bot: For you, Mila, who's interested in privacy: 🌐 Use private browsing...

User: I am worried about scams
Bot: I understand your concern. Let me help you stay safe. 🚨 Scam alert!...

User: exit
Bot: Goodbye, Mila! Stay safe online! 😊


---

## Screenshots

### Chatbot Main Window

<img width="1907" height="1008" alt="image" src="https://github.com/user-attachments/assets/cccbd191-8bfb-47c3-adfe-c018e62706b8" />


### CI Workflow Passing

<img width="1887" height="921" alt="image" src="https://github.com/user-attachments/assets/7998d99e-7816-40d7-b200-ab0680561efd" />


---

## GitHub Requirements

- ✅ Minimum 6 commits (7+ commits completed)
- ✅ GitHub Actions CI workflow passing (green check mark)
- ✅ Release with tag: [v1.0](https://github.com/ST10485707/PROG6221_Cybersecurity_Chatbot_Part2/releases/tag/v1.0)

---

## Project Structure
PROG6221_Cybersecurity_Chatbot_Part2/
├── MainWindow.xaml # GUI design (colours, layout)
├── MainWindow.xaml.cs # UI event handlers
├── ChatbotLogic.cs # All response logic
├── App.xaml # Application settings
└── PROG6221_Cybersecurity_Chatbot_Part2.csproj


---

## Code Explanation

### ChatbotLogic.cs

This class contains all the chatbot's "brain":

| Method | Purpose |
|--------|---------|
| `GetBotResponse()` | Main method - processes user input |
| `DetectSentiment()` | Checks for worried/curious/frustrated keywords |
| `ProcessKeywordResponse()` | Detects keywords (password, scam, privacy, etc.) |
| `GetRandomResponse()` | Picks random response from arrays |
| `GetResponseByTopic()` | Used for "tell me more" feature |
| `SetUserName()` / `GetUserName()` | Memory & recall |

### MainWindow.xaml.cs

This handles the GUI:

| Method | Purpose |
|--------|---------|
| `AddToChat()` | Displays messages with colours |
| `ProcessUserInput()` | Gets user input, validates, calls chatbot |
| `GetBrush()` | Converts colour names to WPF brushes |

---

## Video Presentation

[YouTube Link - Part 2 Demonstration](https://youtu.be/8TrVcbjqWsE)

---

## References

- Pieterse, H. 2021. The Cyber Threat Landscape in South Africa: A 10-Year Review.
- Microsoft WPF Documentation

---

## Declaration

I confirm that this is my own original work and my own voice is used in the video presentation.

**Signature:** Mila Mpengesi  
**Date:** 26 May 2026
