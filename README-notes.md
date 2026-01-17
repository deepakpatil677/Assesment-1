# Avalpha Technologies – Commission Calculator

A simple full-stack commission calculator web application built with **React** and **ASP.NET Core (.NET 8)**.  
The application calculates and compares commission earnings for Avalpha Technologies versus competitors based on provided sales data.

---

## 📦 Tech Stack

| Layer | Technology |
|-------|-------------|
| Frontend | React (CRA), JavaScript |
| Backend | ASP.NET Core Web API (.NET 8, C#) |
| Tests | xUnit (Backend) |

---

## 🚀 How to Run the Application

### **Backend (.NET API)**

1. Navigate to the API folder  
   ```bash
   cd api
   ```

2. Restore dependencies  
   ```bash
   dotnet restore
   ```

3. Build and run  
   ```bash
   dotnet run
   ```
   The API will start at:  
   👉 `https://localhost:5000`  
   Swagger UI available at:  
   👉 `https://localhost:5000/swagger`

---
### **Frontend (React App)**

1. Navigate to the UI folder  
   ```bash
   cd ui
   ```

2. Install dependencies  
   ```bash
   npm install
   ```

3. Run the app  
   ```bash
   npm start
   ```

4. Open your browser at  
   👉 `http://localhost:3000`

---

## 🧪 How to Run Tests

### **Backend Tests (xUnit)**

1. Go to the test project folder (e.g., `AvalphaTechnologies.CommissionCalculator.Tests`)  
   ```bash
   cd api.tests
   ```
2. Run tests  
   ```bash
   dotnet test
   ```

---
## 🧠 Design Decisions
Backend
   - Implemented using ASP.NET Core MVC Controller for simplicity and clarity.
   - Business logic for commission calculation is handled in the controller as per the assignment scope.
   - Uses decimal for monetary calculations to ensure accuracy.
   - Input validation ensures all numeric values are non-negative.
   - API returns a strongly typed DTO containing Avalpha and competitor commission totals.
   - CORS enabled to allow requests from the local React application.

Frontend
   - Built using Create React App.
   - Uses React Hooks (useState) for form state management.
   - All business logic is delegated to the backend; frontend only handles data input and display.
   - Fetch API used for backend communication.
   - Displays commission results with clear labels and currency formatting (£).

Testing
Backend: xUnit tests cover:
   - Valid commission calculation
   - Invalid (negative) input handling

Frontend: UI tests were intentionally omitted due to timebox constraints and prioritization of backend business logic.

---
## 📁 Folder Structure

Assesment-1/
│
├── api/
│   ├── Controllers/
│   │   └── CommisionController.cs
│   ├── AvalphaTechnologies.CommissionCalculator.csproj
│   └── Program.cs
│
├── api.tests/
│   ├── CommisionControllerTests.cs
│   └── AvalphaTechnologies.CommissionCalculator.Tests.csproj
│
├── ui/
│   ├── src/
│   │   ├── App.js
│   │   └── App.css
│   └── package.json
│
├── README.md
└── README-notes.md
