
# ECOMMERCE-API

*Empowering Commerce Through Seamless, Secure Innovation*

![last commit](https://img.shields.io/github/last-commit/Hugo19S/ECommerce-API)
![C#](https://img.shields.io/badge/C%23-99.7%25-239120?style=flat&logo=c-sharp&logoColor=white)
![languages](https://img.shields.io/github/languages/count/Hugo19S/ECommerce-API)
![.NET 8](https://img.shields.io/badge/.NET-8.0-blueviolet)

---

*Built with the tools and technologies:*

![JSON](https://img.shields.io/badge/JSON-000000?style=flat&logo=json&logoColor=white)
![Markdown](https://img.shields.io/badge/Markdown-000000?style=flat&logo=markdown&logoColor=white)
![Keycloak](https://img.shields.io/badge/Keycloak-354052?style=flat&logo=keycloak&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white)
![NuGet](https://img.shields.io/badge/NuGet-004880?style=flat&logo=nuget&logoColor=white)

---

## 📸 Visão Geral do Projeto

![Diagrama ER do banco de dados](Ecommerce.Service/Assets/Database_Modeling.png)
*Modelo de dados completo da aplicação (ERD)*

---

## 📚 Table of Content
- [Overview](#overview)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Usage](#usage)
  - [Testing](#testing)

 ---
## Overview
ECommerce-API is a powerful backend framework tailored for building scalable and secure e-commerce platforms. It emphasizes modular architecture, containerized deployment, and robust testing to streamline development and maintenance.

#### Why ECommerce-API?

This project helps developers create reliable, maintainable online store backends with features like:

- 🧩 **Modular Design**: Supports domain-driven development for scalable and organized codebases.
- 🐳 **Containerized Deployment**: Uses Docker Compose for consistent environments across development, testing, and production.
- 🔐 **Secure Authentication**: Integrates Keycloak for seamless user authentication and role management.
- 🧪 **Comprehensive Testing**: Includes extensive unit tests to ensure application robustness.
- ⚙️ **Config & Seeding**: Facilitates reliable data management with detailed configuration and seed data.

---

## Getting Started

### Prerequisites
This project requires the following dependencies:

- **Programming Language**: CSharp
- **Package Manager**: Nuget
- **Container Runtime**: Docker

### Installation
Build ECommerce-API from the source and install dependencies:

#### 1. Clone the repository:
```bash
git clone https://github.com/Hugo19S/ECommerce-API
```

#### 2. Navigate to the project directory:
```bash
cd ECommerce-API
```

#### 3. Install the dependencies:
**Using** docker:
```bash
docker build -t Hugo19S/ECommerce-API .
```

**Using** nuget:
```bash
dotnet restore
```

### Usage
Run the project with:

**Using** docker:
```bash
docker run -it {image_name}
```

**Using** nuget:
```bash
dotnet run
```

### Testing
Ecommerce-api uses the {test_framework} test framework. Run the test suite with:

**Using** docker:
```bash
echo 'INSERT-TEST-COMMAND-HERE'
```

**Using** nuget:
```bash
dotnet test
```

[⬆ Return](#-table-of-content)
