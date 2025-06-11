LoanRateApi
A minimal .NET Core Web API that provides loan rates. This API is designed following SOLID principles, using a static data source for demonstration purposes.

Features
GET /api/rates: Retrieve loan rates, with optional filtering by loanType and term.

Static Mock Data: Serves predefined loan rate data.

SOLID Principles:

Single Responsibility Principle (SRP): Each class has a single, well-defined responsibility (e.g., RatesController handles HTTP requests, LoanRateService handles business logic, StaticLoanRateDataProvider provides data).

Open/Closed Principle (OCP): The service and data provider are designed to be extended (e.g., adding a new data source) without modifying existing code.

Interface Segregation Principle (ISP): Interfaces (ILoanRateService, ILoanRateDataProvider) are used to define distinct contracts.

Dependency Inversion Principle (DIP): Dependencies are injected via interfaces, promoting loose coupling.

Project Structure
LoanRateApi/
├── LoanRateApi.csproj          # Project file
├── Program.cs                  # Application entry point, DI setup
├── appsettings.json            # Configuration file
├── Properties/
│   └── launchSettings.json     # Launch profiles for debugging
├── Models/
│   ├── LoanRate.cs             # Represents a single loan rate
│   └── LoanRateResponse.cs     # API response structure
├── Services/
│   ├── ILoanRateService.cs     # Interface for business logic
│   └── LoanRateService.cs      # Implementation of business logic
├── Data/
│   ├── ILoanRateDataProvider.cs # Interface for data access
│   └── StaticLoanRateDataProvider.cs # Static mock data implementation
└── Controllers/
    └── RatesController.cs      # API controller for loan rates

Getting Started
Prerequisites
.NET 8.0 SDK (or newer)

A code editor (e.g., Visual Studio Code, Visual Studio)

Setup and Run
Create the project directory and files:
You can manually create the files as shown in the code block above, ensuring they are placed in the correct subdirectories (Models, Services, Data, Controllers).

Alternatively, a quicker way is to use the .NET CLI:

dotnet new webapi -n LoanRateApi
cd LoanRateApi

Then, create the Models, Services, and Data folders and populate them with the C# code provided. Update Program.cs and RatesController.cs accordingly.

Restore dependencies:
Navigate to the LoanRateApi directory in your terminal and run:

dotnet restore

Run the application:

dotnet run

The API will typically start on https://localhost:71xx (port number varies). The console output will show the exact URL.

API Endpoints
Once the API is running, you can access it via your browser or an API client (like Postman, curl).

GET /api/rates
Retrieves a list of loan rates.

Query Parameters:
loanType (optional): Filter by loan type. Accepted values: owner-occupied, investment.

term (optional): Filter by loan term in years. Accepted values: 15, 20, 30.

Examples:
Get all rates:
https://localhost:71xx/api/rates

Get owner-occupied 30-year rates:
https://localhost:71xx/api/rates?loanType=owner-occupied&term=30

Get all investment rates:
https://localhost:71xx/api/rates?loanType=investment

Invalid loanType (will return 400 Bad Request):
https://localhost:71xx/api/rates?loanType=commercial

Swagger UI
You can also access the Swagger UI for interactive API documentation at:
https://localhost:71xx/swagger

SOLID Principles in Practice
This project demonstrates the following SOLID principles:

SRP (Single Responsibility Principle):

RatesController: Handles HTTP requests and responses.

ILoanRateService / LoanRateService: Contains the business logic for filtering and retrieving rates.

ILoanRateDataProvider / StaticLoanRateDataProvider: Manages access to the raw loan rate data.

OCP (Open/Closed Principle):

The LoanRateService can be extended to use different data providers (e.g., a database provider) by simply implementing ILoanRateDataProvider without modifying LoanRateService itself.

ISP (Interface Segregation Principle):

ILoanRateService and ILoanRateDataProvider provide focused, client-specific interfaces.

DIP (Dependency Inversion Principle):

RatesController depends on ILoanRateService (an abstraction), not LoanRateService (a concrete implementation).

LoanRateService depends on ILoanRateDataProvider (an abstraction), not StaticLoanRateDataProvider.

Dependencies are injected through constructors (Program.cs handles the registration).
