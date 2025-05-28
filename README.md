# Basic Chat Application

## Overview

This application is a WPF (Windows Presentation Foundation) chat interface designed to mimic the style of Instagram's chat feature. It allows users to send and receive messages in a visually appealing format, with customizable message bubbles and a user-friendly interface.

## Features

- **Chat Interface**: A clean and modern chat interface with message bubbles that change color based on the sender.
- **Message Input**: Users can type messages and send them using the Enter key or a send button.
- **Placeholder Text**: A placeholder text appears in the input field when it is empty, guiding users on what to do.
- **Dynamic Replies**: The application simulates a chat experience by generating replies based on user input.
- **Close Button**: A button to close the application.

## Technologies Used

- **C#**: The primary programming language for the application.
- **XAML**: Used for designing the user interface.
- **WPF**: Framework for building the desktop application.

## Installation

1. **Clone the Repository**: 
   ```bash
   git clone https://github.com/HChristopherNaoyuki/list-view-wpf-cs.git
   ```

2. **Open the Project**: Open the solution file (`.sln`) in Visual Studio.

3. **Build the Project**: Ensure that the project builds successfully without errors.

4. **Run the Application**: Start the application by pressing `F5` or clicking on the Start button in Visual Studio.

## Usage

- **Sending Messages**: Type your message in the input box and press Enter or click the send button to send it.
- **Receiving Messages**: The application will automatically generate replies based on the content of your message.
- **Closing the Application**: Click the close button (✕) in the top right corner to exit the application.

## Code Structure

### XAML (MainWindow.xaml)

- **Window Definition**: The main window is defined with properties such as size, style, and background.
- **Resources**: Custom converters and styles are defined for buttons and message bubbles.
- **Layout**: The layout consists of a header, message display area, and input area.

### C# (MainWindow.xaml.cs)

- **Initialization**: The chat is initialized with some default messages.
- **Message Handling**: Methods to send messages, handle key events, and update the UI based on user input.
- **Converters**: Custom value converters to manage the appearance of message bubbles based on the sender.

## Converters

- **BoolToAlignmentConverter**: Converts a boolean value to a `HorizontalAlignment` for message alignment.
- **BoolToBubbleColorConverter**: Converts a boolean value to a `Brush` for the message bubble color.
- **BoolToTextColorConverter**: Converts a boolean value to a `Brush` for the text color inside the message bubble.

## Troubleshooting

- **404 Client Error**: If you encounter a 404 error related to XAML namespaces, ensure that your internet connection is active, as some namespaces may require online access for validation.

---
