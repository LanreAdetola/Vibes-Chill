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

## 🏭 Production Setup

- Use `appsettings.Production.json` for production secrets and connection strings.
- Set `ASPNETCORE_ENVIRONMENT=Production` when deploying.
- Set real OAuth credentials and a strong `TokenKey`.
- Restrict CORS to your production client domain in `ClientUrl`.
- Run EF Core migrations before first launch:
  ```bash
  dotnet ef database update --project src/VibesAndChill.API
  ```
- For Azure or cloud hosting, update connection strings and storage paths as needed.

---

## 🧱 Folder Structure

```bash
Vibes-Chill/
├── src/
│   ├── VibesAndChill.Client/   # Blazor WebAssembly frontend
│   ├── VibesAndChill.API/      # ASP.NET Core backend
│   └── VibesAndChill.Shared/   # Shared models and DTOs
├── .gitignore
├── README.md
└── VibesAndChill.sln
```

---

## 🛡️ Security & Privacy

- OAuth 2.0 ensures secure authentication.
- Never commit secrets or production keys to source control.
- Use HTTPS in production.
- Data is stored locally with SQLite; future support for secure cloud storage.
- Users can report and block others.
- Planned support for GDPR-compliant data removal.

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
cd src/VibesAndChill.API
 dotnet run
```

### 4. Run the Client
```bash
cd src/VibesAndChill.Client
 dotnet run
```

### 5. Database Initialization
```bash
cd src/VibesAndChill.API
dotnet ef migrations add InitialCreate # Only once
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

## 👥 Contributors

- **@LanreAdetola** – Developer & Maintainer  
- Contributions welcome! See `CONTRIBUTING.md` for more info.

---

## 🔧 Sample Prompt to Build with AI

> "Create a modular dating app called 'Vibes&Chill' using Blazor WebAssembly, ASP.NET Core API, SQLite, and OAuth login. Include user profiles, filters, messaging, match logic, and a responsive UI. Use the provided folder structure, implement clean DI, and follow EF Core practices."

---

## 🔒 License

MIT License. Use freely for educational and non-commercial purposes.

---
