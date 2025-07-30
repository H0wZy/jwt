# JWT Authentication API - .NET 9

A complete authentication API built with .NET 9, implementing JWT tokens, Repository Pattern, and SOLID principles for secure user management.

## 🚀 Features

- **JWT Authentication** - Secure token-based authentication
- **User Registration** - Create new user accounts with validation
- **User Login** - Authenticate with username or email
- **Protected Endpoints** - Secure routes requiring valid JWT tokens
- **Password Security** - PBKDF2 hashing with salt for password protection
- **Repository Pattern** - Clean data access layer abstraction
- **SOLID Principles** - Maintainable and extensible code architecture
- **Input Validation** - Comprehensive request data validation
- **Swagger Documentation** - Interactive API documentation with JWT support

## 🛠️ Technologies Used

- **.NET 9** - Latest .NET framework
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core** - Object-relational mapping
- **SQL Server** - Database management system
- **JWT Bearer Authentication** - JSON Web Token implementation
- **Swashbuckle (Swagger)** - API documentation
- **PBKDF2** - Password hashing algorithm

## 📋 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB or Express)
- [JetBrains Rider](https://www.jetbrains.com/rider/), [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) (optional)

## ⚙️ Setup & Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/H0wZy/jwt.git
   cd jwt
   ```

2. **Install dependencies**
   ```bash
   dotnet restore
   ```

3. **Update database connection** (if needed)
   - Update `appsettings.json` with your SQL Server connection string
   - Or create `appsettings.Development.json` for local settings

4. **Run database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access Swagger UI**
   - Navigate to `https://localhost:7229/swagger`
   - Interactive API documentation with authentication support

## 📚 API Endpoints

### Authentication

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/auth/register` | Register new user | ❌ |
| POST | `/api/auth/login` | User login | ❌ |
| GET | `/api/auth/profile` | Get user profile | ✅ |

### Example Requests

#### Register User
```json
POST /api/auth/register
{
  "firstname": "John",
  "lastname": "Doe",
  "username": "johndoe",
  "email": "john@example.com",
  "password": "SecurePass123",
  "confirmPassword": "SecurePass123",
  "cargo": 1
}
```

#### Login
```json
POST /api/auth/login
{
  "usernameOrEmail": "johndoe",
  "password": "SecurePass123"
}
```

#### Response (Login Success)
```json
{
  "data": {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "username": "johndoe",
    "email": "john@example.com",
    "firstname": "John",
    "lastname": "Doe",
    "cargo": 1
  },
  "message": "Login realizado com sucesso!",
  "success": true
}
```

## 🏗️ Project Structure

```
├── Controllers/
│   └── AuthController.cs          # Authentication endpoints
├── Data/
│   └── AppDbContext.cs           # Database context
├── Dtos/
│   ├── LoginDto.cs               # Login request model
│   ├── RegisterUserDto.cs        # Registration request model
│   ├── LoginResponseDto.cs       # Login response model
│   └── RegisterResponseDto.cs    # Registration response model
├── Enum/
│   └── Cargo.cs                  # User roles enumeration
├── Migrations/                   # EF Core migrations
├── Models/
│   ├── UserModel.cs              # User entity
│   └── ResponseModel.cs          # Generic API response wrapper
├── Repositories/
│   └── AuthRepository/
│       ├── IAuthRepository.cs    # Repository interface
│       └── AuthRepository.cs     # Repository implementation
├── Services/
│   └── AuthService/
│       ├── IAuthService.cs       # Service interface
│       └── AuthService.cs        # Business logic implementation
└── Utils/
    ├── PasswordHelper.cs         # Password hashing utilities
    └── JwtHelper.cs              # JWT token generation
```

## 🔐 Security Features

- **Password Hashing**: PBKDF2 with 100,000 iterations and random salt
- **JWT Tokens**: 30-minute expiration with secure claims
- **Input Validation**: Comprehensive validation on all endpoints
- **Authorization**: Protected endpoints require valid Bearer tokens

## 🧪 Testing with Swagger

1. **Register a new user** using `/api/auth/register`
2. **Login** with the created user via `/api/auth/login`
3. **Copy the JWT token** from the login response
4. **Click "Authorize"** button in Swagger UI
5. **Enter**: `Bearer YOUR_TOKEN_HERE`
6. **Test protected endpoints** like `/api/auth/profile`

## 🔧 Configuration

### JWT Settings (appsettings.json)
```json
{
  "Jwt": {
    "Key": "your-secret-key-here-must-be-256-bits-minimum",
    "Issuer": "jwt-api",
    "Audience": "jwt-users"
  }
}
```

### Database Connection
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=JwtApi;Integrated Security=true;TrustServerCertificate=true"
  }
}
```

## 🚀 Next Steps / Roadmap

- [ ] **Refresh Tokens** - Implement token refresh mechanism
- [ ] **Role-based Authorization** - Add granular permissions
- [ ] **Password Reset** - Email-based password recovery
- [ ] **User Management** - CRUD operations for users
- [ ] **Docker Support** - Containerization
- [ ] **Unit Tests** - Comprehensive test coverage
- [ ] **Logging** - Structured logging implementation

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Contact

- **GitHub**: [@H0wZy](https://github.com/H0wZy)
- **Email**: h0wzymarcos@gmail.com

---

⭐ **Star this repository if you found it helpful!**
