using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace list_view_wpf_cs
{
    /// <summary>
    /// Main application window for the minimal chat interface
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitializeChatInterface();
        }

        /// <summary>
        /// Sets up the initial state of the chat interface
        /// </summary>
        private void InitializeChatInterface()
        {
            AddChatMessage("System", "Chat initialized. Type your message below.");
            MessageInput.Focus();
        }

        /// <summary>
        /// Handles the Send button click event
        /// </summary>
        private void OnSendClick(object sender, RoutedEventArgs e)
        {
            ProcessAndSendMessage();
        }

        /// <summary>
        /// Handles key presses in the message input box
        /// </summary>
        private void OnMessageInputKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !Keyboard.IsKeyDown(Key.LeftShift))
            {
                ProcessAndSendMessage();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Processes the current message and sends it to the chat
        /// </summary>
        private void ProcessAndSendMessage()
        {
            string userMessage = MessageInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return;
            }

            AddChatMessage("You", userMessage);
            string botResponse = GenerateBotResponse(userMessage);
            AddChatMessage("ChatBot", botResponse);

            MessageInput.Clear();
            MessageInput.Focus();
        }

        /// <summary>
        /// Generates an appropriate response based on the user's message
        /// </summary>
        /// <param name="userMessage">The message received from the user</param>
        /// <returns>A response string from the chatbot</returns>
        private string GenerateBotResponse(string userMessage)
        {
            userMessage = userMessage.ToLower();

            if (userMessage.Contains("hello") || userMessage.Contains("hi"))
            {
                return "Hello! How can I assist you today?";
            }
            else if (userMessage.Contains("password"))
            {
                return "For security reasons, I cannot discuss password matters.";
            }
            else if (userMessage.Contains("thank"))
            {
                return "You're welcome!";
            }
            else if (userMessage.Contains("?"))
            {
                return "That's an interesting question. Let me think about that...";
            }
            else
            {
                return "I'm a simple chatbot. Could you clarify or ask something else?";
            }
        }

        /// <summary>
        /// Adds a message to the chat display with sender identification
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="message">The message content</param>
        private void AddChatMessage(string sender, string message)
        {
            ChatDisplay.Items.Add($"{sender}: {message}");
            ScrollToLatestMessage();
        }

        /// <summary>
        /// Ensures the latest message is visible in the chat display
        /// </summary>
        private void ScrollToLatestMessage()
        {
            if (ChatDisplay.Items.Count > 0)
            {
                ChatDisplay.ScrollIntoView(ChatDisplay.Items[ChatDisplay.Items.Count - 1]);
            }
        }
    }
}