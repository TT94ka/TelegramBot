🤖 TelegramBot
A lightweight and extensible Telegram bot built with ASP.NET Core Web API. This project demonstrates a layered architecture, command handling, and a solid foundation for future expansion.

📦 Overview
TelegramBot is designed to process Telegram commands via webhook or polling, interact with external APIs, and serve as a base for more advanced bot features. The architecture follows separation of concerns and SOLID principles.

🛠️ Tech Stack
.NET 9.0

ASP.NET Core Web API

Telegram.Bot SDK

Dependency Injection

RESTful API

C#

📁 Project Structure
Code
TelegramBot/
├── Controllers/         // Entry point for Telegram updates
├── Services/            // Business logic and command handling
├── Interfaces/          // Service contracts
├── Models/              // Domain models
├── DTOs/                // Data transfer objects
├── Program.cs           // Application configuration
├── appsettings.json     // Bot settings and secrets
└── TelegramBot.http     // Sample HTTP requests for testing
🚀 Getting Started
Install .NET 9.0 SDK

Configure your bot token in appsettings.json:

json
{
  "TelegramBot": {
    "Token": "YOUR_BOT_TOKEN"
  }
}
Run the project:

bash
dotnet run
Set up webhook or use polling (default behavior).

💬 Supported Commands
/start — Welcome message

/help — List of available commands

/info — Sample integration with external API

📈 Roadmap
Database integration

User authentication

Logging and monitoring

Docker containerization

Swagger documentation

🤝 Contributions