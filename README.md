# Rent Delivery Service

Este é um projeto de serviço de entrega que permite o registro de entregadores.

## Funcionalidades

- Registro de entregadores
- Verificação de CNPJ e CNH únicos
- Upload de imagem da CNH

## Como usar

### Pré-requisitos

- .NET 8.0 ou superior
- Visual Studio 2022 ou superior

### Instalação

0. Instale Erlang e RabbitMQ
1. Clone o repositório
2. Abra o projeto no Visual Studio
3. Restaure os pacotes NuGet
4. Compile e execute o projeto
5. Acesse raiz do projeto pelo terminal PowerShell
   (`dotnet ef migrations add Initial --project Rent.Infra.Data --startup-project Rent.API`)
6. Atualize o banco de dados
   (`dotnet ef database update --project Rent.Infra.Data --startup-project Rent.API`)

## Tecnologias utilizadas

- .NET 8.0
- Entity Framework Core
- SQL Server
- ASP.NET Core Web API
- Clean Architecture
- Solid
- IoC
- Identity
- RabbitMQ
- Serilog

## Contribuição

Contribuições são o que fazem a comunidade open source um lugar incrível para aprender, inspirar e criar. Qualquer contribuição que você fizer será **muito apreciada**.

1. Faça um Fork do projeto
2. Crie a sua Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a Branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## Contato

Natanael - natanaelsantosbr@gmail.com

   
