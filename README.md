# Employee Management System

## Objective
Develop a .NET 8 API and an Angular application for managing employee data with CRUD operations.

## Requirements

### Backend (.NET 8 API)

#### Project Setup
- Create a .NET 8 Web API project.
- Use Entity Framework Core with a SQLite database.

#### Employee Object
- **Properties**:
  - `Id` (GUID)
  - `FirstName`
  - `LastName`
  - `Email`
  - `PhoneNumber`
  - `Position`
  - `Department`

#### API Endpoints
Create Restful endpoints to manage employees:
- **GET** /api/employees: Retrieve all employees.
- **GET** /api/employees/{id}: Retrieve an employee by ID.
- **POST** /api/employees: Create a new employee.
- **PUT** /api/employees/{id}: Update an existing employee.
- **DELETE** /api/employees/{id}: Delete an employee.

### Frontend (Angular Application)

#### Project Setup
- Create an Angular project using Angular CLI.

#### Employee Management
- Develop a service to communicate with the API.
- Create components for:
  - Listing employees.
  - Viewing employee details.
  - Adding a new employee.
  - Editing an existing employee.

#### CRUD Operations
- Implement forms and views for Create, Read, Update, and Delete operations.

#### Routing
- Set up Angular routing for navigation between views.

### Bonus Points
- Use CQRS (Command Query Responsibility Segregation) and MediatR (Mediator Pattern).

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) and [Angular CLI](https://angular.io/cli)
- SQLite

### Backend Setup

1. Clone the repository:
    ```sh
    git clone https://github.com/zkousama/employee-management-system.git
    cd employee-management-system/EmployeeManagementApi
    ```

2. Install dependencies:
    ```sh
    dotnet restore
    ```

3. Update the database:
    ```sh
    dotnet ef database update
    ```

4. Run the API:
    ```sh
    dotnet run
    ```

### Frontend Setup

1. Navigate to the frontend project directory:
    ```sh
    cd ../employee-management-app
    ```

2. Install dependencies:
    ```sh
    npm install
    ```

3. Run the Angular application:
    ```sh
    ng serve
    ```

## Usage

- Access the API at `http://localhost:5012/api/employees`.
- Access the Angular application at `http://localhost:4200`.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature-name`).
3. Commit your changes (`git commit -am 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature-name`).
5. Create a new Pull Request.

## License
This project is licensed under the MIT License.

