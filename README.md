![.NET 8](https://img.shields.io/badge/.NET-8.0-blueviolet)
![Keycloak](https://img.shields.io/badge/Auth-Keycloak-red)
![Docker](https://img.shields.io/badge/Docker-Ready-blue)

# 🛒 ECommerce-API | Backend em .NET 8 com DDD, Keycloak e Docker

Backend de um sistema de e-commerce, com autenticação segura via Keycloak, arquitetura baseada em DDD, e serviços conteinerizados com Docker.

---

## 📸 Visão Geral do Projeto

![Diagrama ER do banco de dados](Ecommerce.Service/Assets/Database_Modeling.png)
*Modelo de dados completo da aplicação (ERD)*

---

## 📚 Índice

- [🚀 Funcionalidades](#-funcionalidades)
- [🛠️ Tecnologias Utilizadas](#️-tecnologias-utilizadas)
- [⚙️ Como Executar Localmente](#️-como-executar-localmente)
- [📐 Arquitetura](#-arquitetura)
- [🧪 Testes](#-testes)
- [🔐 Autenticação com Keycloak](#-autenticação-com-keycloak)
- [👨‍💻 Autor](#-autor)

---

## 🚀 Funcionalidades

- 📦 CRUD de produtos, categorias, fabricantes e vendedores
- 🧾 Gestão de carrinho de compras e pedidos
- 💳 Gestão de pagamentos e histórico de status
- 🧑 Gestão de utilizadores
- 🔐 Autenticação e autorização com Keycloak (roles via JWT)
- ⚡ Cache em memória para acelerar as respostas
- 📄 Paginação em listagens de usuários e produtos
- 🔬 Testes unitários com xUnit e Moq

---

## 🛠️ Tecnologias Utilizadas

- **.NET 8**
- **Entity Framework Core**
- **PostgreSQL**
- **Keycloak**
- **Docker & Docker Compose**
- **xUnit + Moq**

---

## ⚙️ Como Executar Localmente

> Certifique-se de ter o Docker e o .NET SDK instalados.

```bash
# 1. Clone o repositório
git clone https://github.com/Hugo19S/ECommerce-API.git
cd ECommerce-API

# 2. Levante os serviços com Docker Compose
docker-compose up --build

# 3. A API estará disponível em:
http://localhost:5001

# 4. O painel do keycloak estará disponível em:
http://localhost:8080

```

---

## 📐 Arquitetura

O projeto está dividido nas seguintes camadas:

ECommerce.Domain → Entidades, ValueObjects. Contém também tabelas dedicadas para rastrear preços e descontos historicamente.

ECommerce.Application → Casos de uso da aplicação e interfaces dos repositórios.

ECommerce.Infrastructure → 
  - Configurações das entidades e suas relações
  - Implementações de repositórios
  - Seeders e migrações
  - Lógica de cache e autenticação (Keycloak)

ECommerce.API → Controllers, configuração de middlewares e endpoints.

📦 A arquitetura segue os princípios de Domain-Driven Design (DDD) e utiliza injeção de dependência nativa do .NET.

---

## 🧪 Testes

> Execute os testes com o seguinte comando:
cd .\ECommerce-API\Ecommerce.Test\
dotnet test

Utilizei xUnit com Moq para testar os principais serviços da camada de aplicação.

---

## 🔐 Autenticação com Keycloak
A autenticação é feita via JWT, e o Keycloak valida os tokens e roles de acesso. Os usuários são divididos por papéis, e os endpoints têm proteção via [Authorize(Roles = "Admin")], por exemplo.

---

## 👨‍💻 Autor
Feito com ❤️ por Hugo Furtado
🔗 [Conecte-se comigo no LinkedIn](https://www.linkedin.com/in/hugo-furtado)