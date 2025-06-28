# Vibes&Chill 💬💘

**A fun, university-focused dating and meetup web app.**  
Built with C# using ASP.NET Core, Blazor WebAssembly, and a modular architecture.

---

## 🚀 Project Overview

**Vibes&Chill** is a platform where young adults and university students can link up, chat, make plans, and vibe. It's a safe, simple, and mobile-friendly web application to connect students around campus or town.

---

## 🔥 Features (MVP)

- 🔐 **OAuth Authentication** (Google/Microsoft logins)
- 👤 **User Profiles** (bio, age, photo, interests)
- ❤️ **Like / Swipe Functionality**
- 💬 **1-on-1 Messaging**
- 🎯 **Smart Match Suggestions** (AI-assisted logic)
- 🎛️ **Filters** (location, age range, interests)
- 🛠️ **Profile Editing**
- 🧑‍💼 **Admin Dashboard**
- 📱 **Mobile Responsive UI** (Blazor WebAssembly)

---

## 🧠 Matching Algorithm (for AI/CoPilot)

```plaintext
- Match users based on shared interests and age proximity.
- Prefer matches in the same campus or city.
- Each user has a score based on profile completeness and activity.
- Suggested matches are ranked by compatibility score.
```

---

## 🧰 Tech Stack

| Layer       | Technology                      |
|-------------|----------------------------------|
| Frontend    | Blazor WebAssembly               |
| Backend     | ASP.NET Core Web API             |
| Database    | SQLite + EF Core                 |
| Authentication | OAuth 2.0 (Google, Microsoft) |
| Hosting     | Azure App Service                |
| Dev Tools   | Visual Studio / VS Code, GitHub  |

---

## 🧱 Modular Architecture

This project is structured into **modular layers** for clean separation of concerns and easier testing:

- `Client/` – Blazor WebAssembly project for UI
- `Server/` – ASP.NET Core project for APIs and services
- `Shared/` – DTOs and models shared between client and server
- `Data/` – Entity Framework Core context and migrations
- `Auth/` – OAuth logic, tokens, and claims

### Key Concepts

- **Dependency Injection (DI):** All services are registered using .NET Core’s built-in DI container.
- **Separation of Concerns:** UI, business logic, and data access are isolated.
- **DTO Mapping:** Automapper (optional) used for mapping between entities and DTOs.

---

## 📁 Folder Structure

```bash
vibes-and-chill/
├── Client/                 # Blazor WebAssembly frontend
│   ├── Pages/             # Razor pages (Home, Register, Match)
│   ├── Services/          # API services for data communication
│   └── Shared/            # Components shared across pages
│
├── Server/                 # ASP.NET Core backend
│   ├── Controllers/       # API endpoints
│   ├── Services/          # Business logic and helpers
│   ├── Data/              # DB context and seed logic
│   └── Models/            # EF Core data models
│
├── Shared/                 # Shared models between frontend/backend
│   └── DTOs/              # Data Transfer Objects
│
├── Auth/                   # OAuth and authentication configs
│   ├── ExternalProviders/ # Google, Microsoft auth
│   └── Middleware/        # Custom auth handlers
│
├── .github/                # GitHub workflows (future)
├── README.md               # You're here!
└── VibesAndChill.sln       # Visual Studio Solution file
```

---

## 🛠 Setup and Installation Guide

### 1. Clone the repository
```bash
git clone https://github.com/YOUR_USERNAME/vibes-and-chill.git
cd vibes-and-chill
```

### 2. Launch the solution
Open `VibesAndChill.sln` in Visual Studio or VS Code.

### 3. Run the Server
```bash
cd Server
 dotnet run
```

### 4. Run the Client
```bash
cd Client
 dotnet run
```

### 5. Database Initialization
```bash
cd Server
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 📈 Roadmap

- [ ] Add profile verification feature
- [ ] Group event invitations
- [ ] Real-time chat updates
- [ ] Push notifications
- [ ] Azure B2C support

---

## 🛡️ Security & Privacy

- OAuth 2.0 ensures secure authentication.
- Data is stored locally with SQLite; future support for secure cloud storage.
- Users can report and block others.
- Planned support for GDPR-compliant data removal.

---

## 👥 Contributors

- **@LanreAdetola** – Developer & Maintainer  
- Contributions welcome! See `CONTRIBUTING.md` for more info.

---

## 🔍 Suggested Additional Files

You can include these in the root for full project initialization:

- `.editorconfig` – Code style rules
- `.gitignore` – Ignore build/output/user-specific files
- `CONTRIBUTING.md` – Guidelines for contributing
- `LICENSE` – MIT or your preferred license
- `launchSettings.json` – Debug configuration
- `appsettings.json` – App-wide configuration
- `DbInitializer.cs` – Seed demo data on startup

---

## 🔧 Sample Prompt to Build with AI

> "Create a modular dating app called 'Vibes&Chill' using Blazor WebAssembly, ASP.NET Core API, SQLite, and OAuth login. Include user profiles, filters, messaging, match logic, and a responsive UI. Use the provided folder structure, implement clean DI, and follow EF Core practices."

---

## 🔒 License

MIT License. Use freely for educational and non-commercial purposes.

---
