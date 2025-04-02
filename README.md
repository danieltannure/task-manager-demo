# TaskManager

  

Sistema web para **gestão de tarefas**, construído com ASP.NET Core + Blazor + SQL Server, pensado para registrar, organizar e acompanhar tarefas de maneira colaborativa. A inspiração veio de um ambiente acadêmico onde professores delegam tarefas a grupos, monitoram prazos e acompanham o progresso com clareza.

  

---

  

## 📌 Objetivo

  

Criar um portal estilo **To-Do colaborativo**, com rastreabilidade completa das tarefas, focado em:

- Delegação de tarefas com diferentes níveis de dificuldade;

- Atribuição a usuários específicos;

- Marcação de tarefas como concluídas com data registrada;

- Edição e exclusão com permissões diferenciadas entre **usuários comuns** e **administradores**.

  

---

  

## 🧩 Estrutura do Projeto

  

Este repositório é composto por três subprojetos organizados na solução Visual Studio 2022:

  

### `TaskManager.API`

Camada de backend da aplicação:

  

- Construída em **ASP.NET Core Web API**;

- Responsável por expor endpoints RESTful;

- Integrada ao **Microsoft SQL Server** via EF Core;

- Contém controllers como `AuthController` e `TarefasController`;

- Gerencia autenticação e operações CRUD sobre tarefas.

  

### `TaskManager.Shared`

Biblioteca de classes compartilhadas:

  

- Contém as **entidades principais** (`Tarefa`, `Usuario`);

- DTOs e objetos auxiliares como `LoginRequest`, `TarefaDto`;

- Utilizado tanto pela API quanto pelo frontend Blazor.

  

### `TaskManager.UI`

Frontend da aplicação:

  

- Construído com **Blazor Server**;

- Com navegação reativa e design responsivo baseado em **Bootstrap 5**;

- Permite login, criação e edição de tarefas, filtros por dificuldade/status/responsável, além de ações condicionais a permissões;

- Interface moderna e centralizada com foco em usabilidade.

  

---

  

## 🛠️ Tecnologias Utilizadas

  

-  **ASP.NET Core 8**

-  **Blazor Server**

-  **Entity Framework Core**

-  **Microsoft SQL Server**

-  **C#**

-  **Bootstrap 5**

-  **Visual Studio 2022**

  

---

  

## 📸 Principais Funcionalidades

  

- ✅ Login com controle de sessão

- 🧾 Criação de novas tarefas com título, descrição, data, dificuldade e responsável

- 🔍 Filtros por status, dificuldade e usuário

- 📅 Registro automático da conclusão com data

- 🔒 Permissões de acesso diferenciadas (usuário vs admin)

- 🖱️ Edição e exclusão com interface visual moderna

- 📋 Feedback visual com alertas e atualizações em tempo real

  

---

  

## 🧪 Como Rodar Localmente

  

1. Clone o repositório:

  

```bash

git clone https://github.com/seu-usuario/taskmanager.git

```

  

2. Abra a solução `.sln` no **Visual Studio 2022**

  

3. Certifique-se de:

- Ter o **SQL Server** rodando localmente com uma base compatível.

- O `appsettings.json` da `TaskManager.API` contém sua `ConnectionString`.

  

4. Rode o projeto com a opção **“Iniciar Múltiplos Projetos”** (API + UI).

  

---

  

## 📁 Estrutura de Pastas (resumida)

  

```

TaskManager/ 
├── TaskManager.API/ 
│   ├── Controllers 
│   ├── Data 
│   └── DTOs 
├── TaskManager.UI/ 
│   ├── wwwroots 
│   ├── Services 
│   └── Components/ 
│       ├── Layout 
│       ├── Pages 
│       └── Shared 
└── TaskManager.Shared

```

  

---

  


