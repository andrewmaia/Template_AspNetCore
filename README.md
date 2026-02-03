# Template_AspNetCore

Template base para iniciar projetos em **ASP.NET Core**, focado em padronização e rapidez no start de novas aplicações.

## Sobre
Este repositório fornece uma estrutura inicial em **C# / ASP.NET Core**, servindo como ponto de partida para novos projetos, já com a organização básica da solução pronta para evoluir.

## Tecnologias
- ASP.NET Core  
- C#  
- .NET  
- PostgreSQL

## Pré-requisitos
- .NET SDK instalado
- Um banco **PostgreSQL** disponível (local ou remoto)

## Configuração do banco
1. Crie (ou escolha) um database no PostgreSQL
2. Configure a **connection string** do projeto para apontar para esse banco  
   (ex.: em `appsettings.json`, `appsettings.Development.json` ou via variável de ambiente)

## Rodando migrations
Após configurar a connection string, aplique as migrations para criar/atualizar o schema do banco:

```bash
dotnet ef database update
