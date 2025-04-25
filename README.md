# AI for IT Service Management (AIForITSM)

AIForITSM is a Blazor-based web application designed to assist IT support and management teams. It provides tools for managing company configurations, integrating with Azure OpenAI and Ollama APIs, and other IT service management functionalities.

## Features

- **Home Page**: Overview of the application and its purpose.
- **Company Manager**: Manage company details, including:
  - Adding new companies.
  - Configuring Azure OpenAI and Ollama API settings for each company.
  - Deleting existing companies.
- **Trending Page**: Placeholder for trending ITSM topics (future development).
- **ChatBot**: Placeholder for chatbot integration (future development).
- **Responsive Layout**: Includes a navigation bar and footer for easy navigation.

## Technologies Used

- **Blazor**: Interactive web UI framework.
- **.NET 9**: Target framework.
- **C# 13.0**: Programming language version.
- **Azure OpenAI**: Integration for AI-based services.
- **Ollama**: Integration for additional AI services.

## Project Structure

- **Pages**:
  - `Home.razor`: Displays the home page.
  - `CompanyManager.razor`: Provides a form to manage company configurations.
- **Layout**:
  - `NavBar.razor`: Navigation bar for the application.
  - `Footer.razor`: Footer with company branding and disclaimers.
- **Services**:
  - `ConfigurationService.cs`: Handles reading and writing company configurations from `appsettings.json`.

## Setup Instructions

1. **Clone the Repository**:
   git clone <repository-url> cd AIForITSM
2. **Install Dependencies**:
   Ensure you have the .NET 9 SDK installed. Restore dependencies using:
   dotnet restore

3. **Configure `appsettings.json`**:
   Add your company settings and API configurations in the `appsettings.json` file.

4. **Run the Application**:
   Start the Blazor server:
   dotnet run
   Open your browser and navigate to `http://localhost:5000`.

## Usage

- Navigate to the **Company Manager** page to manage company configurations.
- Add or update API keys, endpoints, and models for Azure OpenAI and Ollama.
- Use the **Home** page for an overview of the application.

## Future Enhancements

- Implement the **Trending** and **ChatBot** pages.
- Add authentication and authorization for secure access.
- Improve UI/UX for better user experience.

## Disclaimer

This application is for demonstration purposes only and is not intended for production use.

---

© 2025 CGI IT UK LTD | By Mason Kerr
