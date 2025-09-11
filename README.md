# Library CQRS

Uma implementação de uma biblioteca utilizando o padrão CQRS (Command Query Responsibility Segregation) para separação clara entre operações de leitura e escrita.

## 📋 Sobre o Projeto

Este projeto é uma evolução da implementação original da biblioteca, agora utilizando o padrão CQRS para melhorar a escalabilidade, manutenibilidade e desempenho do sistema.

## ✨ Funcionalidades

- ✅ Cadastro de livros e autores
- ✅ Empréstimo e devolução de livros
- ✅ Consultas otimizadas para leitura
- ✅ Comandos separados para operações de escrita
- ✅ Arquitetura escalável e desacoplada

## 🏗️ Arquitetura

O projeto segue os princípios do CQRS com:

- **Commands**: Operações que alteram o estado do sistema
- **Queries**: Operações que consultam dados sem alterar o estado
- **Handlers**: Processam commands e queries
- **Separate Models**: Modelos otimizados para leitura e escrita

## 🛠️ Tecnologias Utilizadas

- .NET Core
- Entity Framework Core
- MediatR para padrão Mediator
- SQL Server
- Docker (opcional)
- xUnit para testes

## 📦 Como Executar

### Pré-requisitos

- .NET 8.0 SDK
- SQL Server (ou Docker para container)
- Git

### Instalação

1. Clone o repositório:
```bash
git clone https://github.com/thiagssm/libraryCQRS.git
cd libraryCQRS
```

2. Restaure as dependências:
```bash
dotnet restore
```

3. Configure a connection string no `appsettings.json`

4. Execute as migrations:
```bash
dotnet ef database update
```

5. Execute a aplicação:
```bash
dotnet run
```

### Executando com Docker

```bash
docker-compose up -d
```

## 🧪 Testes

Execute os testes unitários com:

```bash
dotnet test
```

## 📚 Estrutura do Projeto

```
LibraryCQRS/
├── src/
│   ├── LibraryCQRS.Core/          # Camada de domínio
│   ├── LibraryCQRS.Infra/         # Infraestrutura e persistência
│   ├── LibraryCQRS.Application/   # Casos de uso (Commands e Queries)
│   └── LibraryCQRS.API/           # API Web
├── tests/
│   ├── LibraryCQRS.UnitTests/     # Testes unitários
│   └── LibraryCQRS.IntegrationTests/ # Testes de integração
└── docker-compose.yml
```

## 🤝 Contribuindo

Contribuições são sempre bem-vindas! Por favor, leia o guia de contribuição antes de enviar um pull request.

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👨‍💻 Autor

Thiago Marcel - [thiagssm](https://github.com/thiagssm)

## 📞 Contato

Para dúvidas ou sugestões, entre em contato através do GitHub Issues.
