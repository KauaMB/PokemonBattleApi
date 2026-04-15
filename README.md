
**🇺🇸 Version: English**
<div align="center">

# 🎮 Pokemon Battle API
**Nível: Junior Backend Developer Portfolio**

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512bd4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/)
[![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)](https://swagger.io/)

<p align="center">
  <a href="#-about">About</a> •
  <a href="#-tech-stack">Tech Stack</a> •
  <a href="#-features">Features</a> •
  <a href="#-how-to-run">How to Run</a> •
  <a href="#-português">Português</a>
</p>

---

</div>

## 📑 About

This is a robust REST API for simulating Pokémon battles. Developed with **.NET 10**, it focuses on Object-Oriented Programming (OOP) and structural principles, incorporating Clean Architecture and SOLID patterns to separate the complex battle logic from the infrastructure.

> **Key Learning:** Implementation of complex damage calculation algorithms, external data consumption from PokeAPI, and PostgreSQL persistence using Entity Framework Core within a Dockerized environment.

---

## 🛠 Tech Stack

* **Framework:** .NET 10 (Web API)
* **ORM:** Entity Framework Core
* **Database:** PostgreSQL
* **Containerization:** Docker & Docker Compose
* **Documentation:** Swagger / OpenAPI

---

## 🚀 Features

- [x] **Data Load**: Fetch and store Pokémon and Move data from the external PokeAPI to populate the local database.
- [x] **Battle Simulator**: Execute battle logic considering Speed priorities, Attack/Defense stats, and Type effectiveness multipliers (STAB, weaknesses).
- [x] **Relational Modeling**: N:N mapping between Pokémons and their learned Moves.
- [x] **Docker Integration**: Automated database and API setup via Docker Compose.

---

## ⚙️ How to Run

### Prerequisites
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* [Docker Desktop](https://www.docker.com/products/docker-desktop/)

### Installation
```bash
# 1. Clone the repository
git clone https://github.com/seu-usuario/pokemon-battle-api.git

# 2. Go to project folder
cd pokemon-battle-api/PokemonBattle.Api

# 3. Start the containers (API + Database)
docker-compose up -d

# 4. Run database migrations (if running locally without Docker)
dotnet ef database update

# 5. Run the project (if running locally without Docker)
dotnet run
```

### 🌐 Accessing the API (Swagger UI)
Once the application is running, you can access the Swagger documentation via your browser:
* **Running via Docker:** `http://localhost:8080/swagger`
* **Running locally (`dotnet run`):** `http://localhost:5032/swagger` (or `https://localhost:7114/swagger`)

---

**🇧🇷 Versão: Português**

<div align="center">

# 🎮 API de Batalha Pokémon
**Portfólio: Desenvolvedor Backend Júnior**

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512bd4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/)
[![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)](https://swagger.io/)

<p align="center">
  <a href="#-sobre-o-projeto">Sobre</a> •
  <a href="#-tecnologias">Tecnologias</a> •
  <a href="#-funcionalidades">Funcionalidades</a> •
  <a href="#-como-executar">Como Executar</a>
</p>

---

</div>

## 📑 Sobre o Projeto

Esta é uma API REST robusta para simulação de batalhas Pokémon. Desenvolvida com **.NET 10**, o foco principal foi aplicar Programação Orientada a Objetos (POO) e princípios estruturais, incorporando padrões de Clean Architecture e SOLID para separar a complexa lógica de batalha da infraestrutura.

> **Destaque técnico:** Implementação de algoritmos complexos para cálculo de dano, consumo de API externa (PokeAPI) e persistência de dados com PostgreSQL usando Entity Framework Core em um ambiente Docker.

---

## 🛠 Tecnologias

* **Framework:** .NET 10 (Web API)
* **ORM:** Entity Framework Core
* **Banco de Dados:** PostgreSQL
* **Containerização:** Docker & Docker Compose
* **Documentação:** Swagger / OpenAPI

---

## 🚀 Funcionalidades

- [x] **Carga de Dados**: Buscar e armazenar dados de Pokémons e Movimentos da PokeAPI externa para popular o banco local.
- [x] **Simulador de Batalha**: Executar a lógica de batalha considerando prioridade de Velocidade, status de Ataque/Defesa e multiplicadores de efetividade de Tipo (STAB, fraquezas).
- [x] **Modelagem Relacional**: Mapeamento N:N entre Pokémons e os Movimentos aprendidos.
- [x] **Integração com Docker**: Configuração automatizada da API e banco de dados via Docker Compose.

---

## ⚙️ Como Executar

### Pré-requisitos
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* [Docker Desktop](https://www.docker.com/products/docker-desktop/)

### Instalação e Execução
```bash
# 1. Clone o repositório
git clone https://github.com/seu-usuario/pokemon-battle-api.git

# 2. Acesse a pasta do projeto
cd pokemon-battle-api/PokemonBattle.Api

# 3. Suba os containers (API + Banco de Dados)
docker-compose up -d

# 4. Atualize o Banco de Dados (caso rode localmente sem o Docker)
dotnet ef database update

# 5. Execute a aplicação (caso rode localmente sem o Docker)
dotnet run
```

### 🌐 Acessando a API (Swagger UI)
Com a aplicação em execução, você pode acessar a documentação do Swagger pelo navegador:
* **Rodando via Docker:** `http://localhost:8080/swagger`
* **Rodando localmente (`dotnet run`):** `http://localhost:5032/swagger` (ou `https://localhost:7114/swagger`)
