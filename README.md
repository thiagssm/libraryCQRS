# 📚 LibraryCQRS - API de Biblioteca com CQRS e Clean Architecture

**LibraryCQRS** é uma API REST desenvolvida em **C# com .NET**, que aplica o padrão **CQRS (Command Query Responsibility Segregation)** aliado aos princípios da **Clean Architecture**, proporcionando uma base robusta, escalável e de fácil manutenção para gerenciamento de bibliotecas.

---

## ✨ Principais Funcionalidades

- 📖 Cadastro e consulta de livros.
- 👤 Gerenciamento de usuários (leitores).
- 🔄 Controle de empréstimos e devoluções.
- 🧠 Separação clara entre **comandos (Commands)** e **consultas (Queries)**.
- 🧪 Estrutura preparada para testes automatizados.

---

## 🧱 Arquitetura e Padrões Utilizados

- **CQRS**: separação de responsabilidade entre leitura e escrita.
- **Clean Architecture**: divisão clara em camadas: Domain, Application, Infrastructure, API.
- **MediatR**: para orquestração de comandos e queries.
- **Entity Framework Core**: acesso a dados com LINQ e suporte a banco relacional.
- **AutoMapper**: mapeamento entre entidades e DTOs.
- **Swagger**: documentação automática da API.

---

## 🚀 Objetivo do Projeto

Este repositório foi criado com o objetivo de estudar e aplicar o padrão **CQRS** em um contexto realista de gerenciamento de biblioteca, com ênfase em **boas práticas de arquitetura de software**, como:

- Princípios SOLID
- Separação de preocupações
- Testabilidade e manutenibilidade

---

## ▶️ Como Executar

```bash
# Restaurar pacotes
dotnet restore

# Executar migrações (se aplicável)
dotnet ef database update

# Rodar o projeto
dotnet run --project Library.API
```

---

## 📂 Estrutura das Pastas

```plaintext
LibraryCQRS/
│
├── Library.API/               → Camada de apresentação (controllers, endpoints)
├── Library.Application/       → Handlers de comandos e queries, DTOs, interfaces
├── Library.Domain/            → Entidades e regras de negócio
├── Library.Infrastructure/    → Implementação de repositórios e acesso a dados
└── Library.Tests/             → Testes automatizados
```

---

## 💡 Exemplos de Padrão CQRS

- **Query**:
  - `GetBooksQuery` → retorna lista de livros.
- **Command**:
  - `CreateBookCommand` → adiciona novo livro.
  - `UpdateBookCommand` → edita livro existente.

---

## 🔗 Contribuição e Contato

Sinta-se à vontade para sugerir melhorias ou abrir issues!  
📧 Contato: [thiago.cmarcel@gmail.com]  
⭐ Se achar útil, deixe uma estrela no repositório!
