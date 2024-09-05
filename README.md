# Carro API

Este é um projeto ASP.NET Core Web API para gerenciar informações sobre carros. O projeto implementa os padrões de design **Repository** e **Unit of Work** para separação de responsabilidades e utiliza **Dapper** como ORM para acesso ao banco de dados. O sistema também possui um mecanismo de **logging** utilizando **Serilog** para registrar cada passo de acesso ao banco de dados em um arquivo de texto, facilitando o rastreamento das operações realizadas.

## Tecnologias Utilizadas

- **ASP.NET Core Web API**: Para construir a API.
- **Dapper**: Para acesso eficiente ao banco de dados.
- **Repository Pattern**: Para abstrair o acesso ao banco de dados.
- **Unit of Work Pattern**: Para gerenciar transações e operações.
- **Serilog**: Sistema de logging que grava em um arquivo TXT cada interação com o banco de dados.
- **SQL Server**: Banco de dados relacional utilizado no projeto.

## Funcionalidades

- **CRUD de Carros**: O projeto possui endpoints para criar, ler, atualizar e deletar registros de carros.
- **Logs detalhados**: Cada operação realizada no banco de dados gera logs detalhados gravados em um arquivo de texto.

## Instalação de Pacotes

Para que o projeto funcione corretamente, os seguintes pacotes foram instalados:

1. **Dapper**:
   - ORM leve para realizar operações de banco de dados diretamente via SQL.
   ```bash
   dotnet add package Dapper
   ```

2. **Microsoft.Data.SqlClient**:
   - Pacote para conexão com o banco de dados SQL Server.
   ```bash
   dotnet add package Microsoft.Data.SqlClient
   ```

3. **Serilog.AspNetCore**:
   - Pacote para integrar o Serilog ao ASP.NET Core.
   ```bash
   dotnet add package Serilog.AspNetCore
   ```

4. **Microsoft.Extensions.Configuration**:
   - Pacote para gerenciar configurações do projeto, como strings de conexão.
   ```bash
   dotnet add package Microsoft.Extensions.Configuration
   ```

## Endpoints

A API possui os seguintes endpoints:

| Método | Endpoint         | Descrição                    |
|--------|------------------|------------------------------|
| GET    | /api/carro        | Retorna todos os carros      |
| GET    | /api/carro/{id}   | Retorna um carro pelo ID     |
| POST   | /api/carro        | Cria um novo carro           |
| PUT    | /api/carro/{id}   | Atualiza um carro existente  |
| DELETE | /api/carro/{id}   | Deleta um carro pelo ID      |

## Executando o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/CarroApi.git
   ```

2. Navegue até a pasta do projeto:
   ```bash
   cd CarroApi
   ```

3. Restaure as dependências do projeto:
   ```bash
   dotnet restore
   ```

4. Execute a aplicação:
   ```bash
   dotnet run
   ```

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir um pull request ou enviar sugestões via issues.

