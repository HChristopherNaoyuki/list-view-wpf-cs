using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Data;
using System.Threading.Tasks;

namespace list_view_wpf_cs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeChat();
            this.MouseLeftButtonDown += (o, e) => DragMove();
            UpdatePlaceholderVisibility();
        }

        private void InitializeChat()
        {
            AddMessage("Hi there!", false);
            AddMessage("Hello! How are you?", true);
            AddMessage("I'm good, thanks for asking. What about you?", false);
        }

        private void AddMessage(string text, bool isFromMe)
        {
            MessagesContainer.Items.Add(new ChatMessage
            {
                Message = text,
                IsFromMe = isFromMe
            });
            MessagesScrollViewer.ScrollToBottom();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !Keyboard.IsKeyDown(Key.LeftShift))
            {
                SendMessage();
                e.Handled = true;
            }
        }

        private void MessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SendButton.IsEnabled = !string.IsNullOrWhiteSpace(MessageTextBox.Text);
            UpdatePlaceholderVisibility();
        }

        private void UpdatePlaceholderVisibility()
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(MessageTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void SendMessage()
        {
            string message = MessageTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(message))
            {
                AddMessage(message, true);
                MessageTextBox.Clear();
                UpdatePlaceholderVisibility();

                Task.Delay(500).ContinueWith(t =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        AddMessage(GenerateReply(message), false);
                    });
                });
            }
        }

        private string GenerateReply(string message)
        {
            message = message.ToLower();

            if (message.Contains("hi") || message.Contains("hello"))
                return "Hey there!";
            else if (message.Contains("how are you"))
                return "I'm doing great, thanks!";
            else if (message.Contains("?"))
                return "That's an interesting question!";
            else
                return "Got your message!";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class ChatMessage
    {
        public string Message { get; set; }
        public bool IsFromMe { get; set; }
    }

    [ValueConversion(typeof(bool), typeof(HorizontalAlignment))]
    public class BoolToAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(bool), typeof(Brush))]
    public class BoolToBubbleColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ?
                new SolidColorBrush(Color.FromRgb(0, 149, 246)) :
                new SolidColorBrush(Color.FromRgb(239, 239, 239));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(bool), typeof(Brush))]
    public class BoolToTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Brushes.White : Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}