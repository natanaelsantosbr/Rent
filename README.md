# Rent Delivery Service

This is a delivery service project that allows the registration of couriers.

## Features
- Courier registration
- Verification of unique CNPJ and CNH
- CNH image upload

## Prerequisites
- .NET 8.0 or higher
- Visual Studio 2022 or higher

## Installation

- Install Erlang and RabbitMQ
- Clone the repository
- Open the project in Visual Studio
- Restore NuGet packages
- Build and run the project
- Access the project root via the PowerShell terminal
(`dotnet ef migrations add Initial --project Rent.Infra.Data --startup-project Rent.API`)
- Update the database
(`dotnet ef database update --project Rent.Infra.Data --startup-project Rent.API`)

## Technologies Used
- .NET 8.0
- Entity Framework Core
- SQL Server
- ASP.NET Core Web API
- Clean Architecture
- SOLID principles
- IoC (Inversion of Control)
- Identity
- RabbitMQ
- Serilog

## Contributing
Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make will be greatly appreciated.

- Fork the project
- Create your Feature Branch (git checkout -b feature/AmazingFeature)
- Commit your changes (git commit -m 'Add some AmazingFeature')
- Push to the Branch (git push origin feature/AmazingFeature)
- Open a Pull Request

## Contact
- Natanael - natanaelsantosbr@gmail.com

------------------------------------------
Portuguese

# Serviço de entrega de aluguel de motos

Este é um projeto de serviço de entrega que permite o registro de entregadores.

## Funcionalidades

- Registro de entregadores
- Verificação de CNPJ e CNH únicos
- Upload de imagem da CNH

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

   
