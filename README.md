# E-Commerce Backend Project (TANZANITE WEBSITE)

## Project Overview

This project is a backend solution for an e-commerce platform dedicated to selling jewelry and gemstones, built using .NET 8. The project includes core functionalities such as user authentication, product management, category management, and order processing.

## Features

- **User Management**
  - Register new user
  - User Authentication with JWT token
  - Role-based access control (Admin, Customer)
  - Login user
  - View Profile Information and Update it
  - Update Password
  - Add Address Details, Update it and Delete it
  - Create Review, Update it and Delete it
- **Product Management**

  - Admin Create Gemstone & GemstoneShape & Jewelry
  - Admin Update Gemstone & GemstoneShape & Jewelry
  - Admin Delete Gemstone & GemstoneShape & Jewelry
  - Customer have a Filter Search By Name, Min Price, Max Price for both the Gemstone & GemstoneShape & Jewelry
  - Customer can Search with Pagination for both the Gemstone & Shape & Jewelry

- **Category Management**
  - Admin Create Category
  - Admin Update Category
  - Admin Delete Category
  - Customer can view all categories
- **Order Management**
  - Customer Make Order

## Technologies Used

- **.Net 8**: Web API Framework
- **Entity Framework Core**: ORM for database interactions
- **PostgreSQL**: Relational database for storing data
- **JWT**: For user authentication and authorization
- **Swagger**: API documentation

## Prerequisites

- .Net 8 SDK
- SQL Server
- VSCode

## Getting Started

### 1. Clone the repository

```bash
git clone git@github.com:R-1493/sda-3-online-Backend_Teamwork.git
```

### 2. Setup database

- Make sure PostgreSQL Server is running
- Create `appsettings.json` file
- Update the connection string in `appsettings.json`

```bash
  {
    "ConnectionStrings": {
      "Local": "Server=localhost;Database=ECommerceDb;Username=your_username;Password=your_password;"
    }
  }
```

- Run migrations to create database

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

- Run the application

```bash
dotnet watch
```

The API will be available at: `http://localhost:5125`

### Swagger

- Navigate to `http://localhost:5125/swagger/index.html` to explore the API endpoints.

## Project Structure

```bash
|-- Controllers: API controller with request and response
|-- Database # DbConext and Database Configurations
|-- DTOs # Data Transfer Objects
|-- Entities # Database Entities (User, Product, Category, Order)
|-- Middleware # Logging request, response and Error Handler
|-- Repositories # Repository Layer for database operations
|-- Services # Business Logic Layer
|-- Utils # Common Logics
|-- Migrations # Entity Framework Migrations
|-- Program.cs # Application Entry Point
```

## API Endpoints

### User

- **POST** `/api/v1/User/SignUp` - Register a new user.
- **POST** `/api/v1/User/LogIn` - Login and get JWT token.
- **GET** `/api/v1/User/Profile` - View Profile Details.
- **PUT** `/api/v1/User/UpdateProfile` - Update Profile Information.
- **PUT** `/api/v1/User/UpdatePassword` - Update the Password.
- **GET** `/api/v1/User` - View All Users.

### Address

- **POST** `/api/v1/Address` - Create a new Address.
- **GET** `/api/v1/Address` - View Address.
- **PUT** `/api/v1/Address` - Update Address.
- **GET** `/api/v1/Address/UserAddress` - View User Address Details.
- **DELETE** `/api/v1/Address/{id}` - Delete the Address.

### Categories

- **POST** `/api/v1/Categories` - Create a new Category.
- **GET** `/api/v1/Categories` - View Categories.
- **PUT** `/api/v1/Categories/{id}` - Update Category by Id.
- **GET** `/api/v1/Categories/{id}` - View Category by Id.
- **DELETE** `/api/v1/Categories/{id}` - Delete Category by Id.
- **GET** `/api/v1/Gemstone/Filter` - Filter for Categories by Name

### Gemstone

- **POST** `/api/v1/Gemstone` - Create a new Gemstone.
- **GET** `/api/v1/Gemstone` - View all Gemstones.
- **GET** `/api/v1/Gemstone/{GemstoneId}` - View Gemstone by Id.
- **Patch** `/api/v1/Gemstone/{GemstoneId}` - Update Gemstone by Id.
- **DELETE** `/api/v1/Gemstone/{GemstoneId}` - Delete Gemstone by Id.
- **GET** `/api/v1/Gemstone/Search` - Searsh with pagination for Gemstone.
- **GET** `/api/v1/Gemstone/Filter` - Filter for Gemstone by MinPrice/MaxPrice.

### Gemstone Shape

- **POST** `/api/v1/GemstoneShape` - Create a new Gemstone Shape.
- **GET** `/api/v1/GemstoneShape` - View all Gemstone Shape.
- **Patch** `/api/v1/GemstoneShape/{gemstoneShapeId}` - Update Gemstone Shape by Id.
- **DELETE** `/api/v1/GemstoneShape/{gemstoneShapeId}` - Delete Gemstone Shape by Id.
- **GET** `/api/v1/GemstoneShape/Search` - Searsh with pagination for Gemstone Shape.
- **GET** `/api/v1/GemstoneShape/Filter` - Filter for Gemstone Shape by MinPrice/MaxPrice.

### Jewelry

- **POST** `/api/v1/Jewelry` - Create a new Jewelry.
- **GET** `/api/v1/Jewelry` - View all Jewelry.
- **GET** `/api/v1/Jewelry/{JewelryId}` - View Jewelry by Id.
- **Patch** `/api/v1/Jewelry/{JewelryId}` - Update Jewelry by Id.
- **DELETE** `/api/v1/Jewelry/{JewelryId}` - Delete Jewelry by Id.
- **GET** `/api/v1/Jewelry/Search` - Searsh with pagination for Jewelry.
- **GET** `/api/v1/Jewelry/Filter` - Filter for Jewelry by MinPrice/MaxPrice.

### Order

- **POST** `/api/v1/Order` - Create a new Order.
- **GET** `/api/v1/Order` - View all Orders.

### Payment

- **POST** `/api/v1/Payment` - Create a new Payment.
- **GET** `/api/v1/Payment` - View Payment Details.
- **GET** `/api/v1/Payment/{id}` - View Payment by Id.

### Reviews

- **POST** `/api/v1/Reviews` - Create a new Review.
- **GET** `/api/v1/Reviews` - View all Reviews.
- **GET** `/api/v1/Reviews/{id}` - View Review by Id.
- **PUT** `/api/v1/Reviews/{id}` - Update Review by Id.
- **DELETE** `/api/v1/Reviews/{id}` - Delete Review by Id.

## Deployment

The application is deployed and can be accessed at: https://gemstonestore.onrender.com/

## License

This project is licensed under the MIT License.
