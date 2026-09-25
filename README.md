# StudentToDoList — API & Web App

A student to-do list application built with **ASP.NET Core (`.NET 10`)**. The solution consists of two projects:

- **`StudentToList-API`** — a REST API that manages students and their tasks, backed by an Entity Framework Core **in-memory database**, with OpenAPI (Swagger) support in development.
- **`StudentToDoList-WebApp`** — a front-end web application for viewing and managing the student to-do list.

##  Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (or newer)
- A code editor (e.g. [Visual Studio](https://visualstudio.microsoft.com/), [VS Code](https://code.visualstudio.com/))

## How to Run Locally

### 1. Clone the repository

```bash
git clone https://github.com/blessing-unlimited/Student-ToDo-List.git
cd StudentToList-API
```

### 2. Run the API

```bash
cd StudentToList-API
dotnet run
```

The API will start, listening on the configured ports (check the console output — typically something like `https://localhost:5001` and `http://localhost:5000`).

While running in development, you can browse the OpenAPI documentation at:

```
https://localhost:<port>/openapi/v1.json
```

### 3. Run the Web App

Open a **second terminal** (leave the API running):

```bash
cd StudentToDoList-WebApp
dotnet run
```

The web app will start on its own port (again, shown in the console output). Open the listed URL in your browser to use the app.

> **Tip:** Run the API first so the web app can communicate with it.

## Project Structure

```
├── StudentToList-API/
│   ├── Controllers/       # API controllers
│   ├── Models/            # Data models (Student, etc.)
│   ├── DTO/               # Data transfer objects
│   ├── Services/          # Business logic services
│   └── Program.cs         # App entry point & configuration
└── StudentToDoList-WebApp/
    └── ...                # Front-end web application
```

## Technologies Used

- ASP.NET Core (`.NET 10`)
- Entity Framework Core (In-Memory provider)
- OpenAPI / Swagger
- Razor / MVC front-end

## 🔮 Future Plans

- **Student account login** — add authentication so students can sign in to manage their own to-do lists. The likely approach is to learn and implement **Firebase Authentication** for this.
- **Deploy the API to [Render](https://render.com/)** — host the API in the cloud so it's accessible outside of local development.
- **Improve the front-end** — make the web app more polished and visually fancy (better styling, animations, and overall UX).

## Notes

- The database is currently **in-memory**, so all data is reset whenever the application restarts. A seeded sample student is added on startup.
- This is a learning project — expect changes as features are explored!
