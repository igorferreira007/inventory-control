# Inventory Control

Aplicação desktop de estudo desenvolvida em C# e .NET 8 com Windows Forms para cadastro de produtos e controle de saldo de estoque. Os dados são persistidos em PostgreSQL por meio de Npgsql e SQL parametrizado.

## Objetivo

Praticar o desenvolvimento de uma aplicação com responsabilidades separadas entre domínio, aplicação, infraestrutura e apresentação. O projeto utiliza uma **arquitetura em camadas orientada por Clean Architecture e aplica princípios de DDD e SOLID**, dentro do escopo de um sistema simples de produtos e estoque.

## Funcionalidades implementadas

- Cadastro de produtos com nome, preço e descrição opcional.
- Consulta, edição e exclusão de produtos.
- Pesquisa por nome sem diferenciar maiúsculas e minúsculas.
- Listagem paginada, com 50 produtos por página na interface e exibição do total de registros.
- Entrada e saída de estoque, com validação de quantidade e saldo disponível.
- Exibição de código, nome, preço, saldo, descrição e data de criação.
- Controle personalizado para entrada de valores monetários.

As operações de entrada e saída atualizam o saldo do produto. Não há histórico persistido de movimentações.

## Tecnologias

| Tecnologia | Utilização |
| --- | --- |
| C# / .NET 8 | Linguagem e plataforma da aplicação |
| Windows Forms | Interface desktop para Windows |
| PostgreSQL 17 | Banco de dados configurado no Docker Compose |
| Npgsql | Acesso ao PostgreSQL com SQL direto e parametrizado |
| FluentValidation | Validação dos DTOs de entrada |
| Microsoft.Extensions.DependencyInjection | Registro e resolução de dependências |
| Docker Compose | Provisionamento local do PostgreSQL |
| xUnit / Microsoft.NET.Test.Sdk | Declaração e execução dos testes |
| Coverlet Collector | Coletor de cobertura incluído nos projetos de teste |

## Arquitetura e estrutura

| Projeto | Responsabilidade |
| --- | --- |
| `Domain` | Entidade `Product`, comportamento de domínio e exceções |
| `Application` | Casos de uso, DTOs, validadores, resultados e contrato do repositório |
| `Infrastructure` | Repositório PostgreSQL, fábrica de conexões e script SQL |
| `Presentation` | Formulários, controles e composição das dependências |

O domínio não depende das demais camadas. A aplicação depende do domínio e define `IProductRepository`; a infraestrutura implementa esse contrato. A apresentação utiliza os casos de uso e referencia a infraestrutura para montar as dependências em `Program.cs`.

```text
InventoryControl/
├── InventoryControl.slnx
├── docker-compose.yml
├── src/
│   ├── InventoryControl.Domain/
│   │   ├── entities/Product.cs
│   │   └── Exceptions/
│   ├── InventoryControl.Application/
│   │   ├── DTOs/
│   │   ├── Interfaces/
│   │   ├── UseCases/
│   │   ├── Validators/
│   │   ├── DependencyInjection/
│   │   ├── Resources/
│   │   └── Result.cs
│   ├── InventoryControl.Infrastructure/
│   │   ├── Database/
│   │   │   ├── PostgresConnectionFactory.cs
│   │   │   └── Scripts/create-products-table.sql
│   │   ├── DependencyInjection/
│   │   └── Repositories/
│   └── InventoryControl.Presentation/
│       ├── Controls/
│       ├── MainForm.cs
│       ├── ProductForm.cs
│       ├── StockMovementForm.cs
│       └── Program.cs
└── tests/
    ├── InventoryControl.Domain.Tests/
    ├── InventoryControl.Application.Tests/
    └── InventoryControl.Infrastructure.Tests/
```

### Decisões arquiteturais

- **Casos de uso separados:** criar, consultar, listar, atualizar, excluir, aumentar e diminuir o estoque possuem classes próprias.
- **Domínio encapsulado:** `Product` possui setters privados e métodos para alterar seus dados e estoque. `Create` cria produtos e `Restore` reconstitui entidades persistidas.
- **Repository:** os casos de uso dependem de `IProductRepository`, com implementações PostgreSQL e em memória para testes.
- **DTOs e validação:** records transportam as entradas e saídas; FluentValidation verifica as solicitações antes das operações.
- **Resultados explícitos:** `Result` e `Result<T>` representam sucesso e falhas esperadas dos casos de uso. O domínio utiliza `DomainException` para violações de suas regras.
- **Persistência direta:** comandos SQL parametrizados são executados de forma assíncrona com Npgsql, sem ORM.
- **Injeção por construtor:** repositórios e validadores são fornecidos aos casos de uso; os registros ficam nas extensões de dependências de cada camada.

## Regras de domínio e validações

Na entidade `Product`:

- O nome não pode ser vazio ou conter apenas espaços.
- O preço deve ser maior que zero.
- Um produto novo começa com estoque zero e data de criação em UTC.
- Quantidades de entrada e saída devem ser maiores que zero.
- A saída não pode exceder o saldo disponível.
- A restauração de um produto exige ID positivo e saldo não negativo.
- O ID só pode ser atribuído uma vez por `AssignId` e deve ser positivo.

Na aplicação, os validadores exigem nome entre 2 e 100 caracteres e descrição de até 1.000 caracteres. Os casos de uso de criação e atualização verificam nomes duplicados sem diferenciar maiúsculas e minúsculas. Na listagem, página e tamanho devem ser positivos, e o termo de pesquisa pode ter até 100 caracteres.

## Banco de dados

O script [`create-products-table.sql`](src/InventoryControl.Infrastructure/Database/Scripts/create-products-table.sql) define a tabela `products`:

| Campo | Tipo | Definição |
| --- | --- | --- |
| `id` | `BIGSERIAL` | Chave primária |
| `name` | `VARCHAR(100)` | Obrigatório e único |
| `description` | `TEXT` | Opcional |
| `price` | `NUMERIC(10, 2)` | Obrigatório |
| `stock_quantity` | `INTEGER` | Obrigatório |
| `created_at` | `TIMESTAMPTZ` | Obrigatório |

O Compose cria o serviço PostgreSQL e o banco `inventory_control`, com dados mantidos em um volume. **A tabela não é criada automaticamente: o script SQL precisa ser executado manualmente.**

## Configuração e execução

### Pré-requisitos

- Windows para executar a interface WinForms.
- SDK do .NET 8 ou superior com suporte ao destino .NET 8.
- Docker com Docker Compose e suporte a contêineres Linux, para utilizar o banco conforme configurado no repositório.
- Porta local `5432` disponível.

Os comandos abaixo são para PowerShell e devem ser executados na raiz do repositório. Utilizam os arquivos `.csproj` diretamente.

### 1. Iniciar o PostgreSQL

```powershell
docker compose up -d
docker compose logs postgres
```

Aguarde o PostgreSQL indicar que está pronto para aceitar conexões.

### 2. Criar a tabela

```powershell
Get-Content -Raw .\src\InventoryControl.Infrastructure\Database\Scripts\create-products-table.sql | docker compose exec -T postgres psql -U postgres -d inventory_control -v ON_ERROR_STOP=1
```

### 3. Restaurar, compilar e executar

```powershell
dotnet restore .\src\InventoryControl.Presentation\InventoryControl.Presentation.csproj
dotnet build .\src\InventoryControl.Presentation\InventoryControl.Presentation.csproj --no-restore
dotnet run --project .\src\InventoryControl.Presentation\InventoryControl.Presentation.csproj --no-build
```

A conexão está definida diretamente em [`Program.cs`](src/InventoryControl.Presentation/Program.cs), com os valores correspondentes ao Compose:

```text
Host=localhost;Port=5432;Database=inventory_control;Username=postgres;Password=postgres
```

Atualmente, a aplicação não lê essa configuração de `appsettings.json` ou de variáveis de ambiente. Para outro ambiente, é necessário ajustar a conexão no código.

Para interromper o serviço sem remover o volume de dados:

```powershell
docker compose down
```

## Testes

Existem **72 testes declarados** com xUnit:

| Projeto | Quantidade | Escopo |
| --- | ---: | --- |
| `Domain.Tests` | 13 | Regras e comportamento de `Product` |
| `Application.Tests` | 44 | Casos de uso com repositório em memória |
| `Infrastructure.Tests` | 15 | Persistência e consultas em PostgreSQL real |

### Testes de domínio e aplicação

Não dependem do PostgreSQL:

```powershell
dotnet test .\tests\InventoryControl.Domain.Tests\InventoryControl.Domain.Tests.csproj
dotnet test .\tests\InventoryControl.Application.Tests\InventoryControl.Application.Tests.csproj
```

### Testes de infraestrutura

**Atenção: esses testes apagam os registros da tabela `products`.** Antes de cada teste, executam `TRUNCATE TABLE products RESTART IDENTITY`, removendo todos os produtos e reiniciando a sequência de IDs.

A conexão está fixa em [`PostgresProductRepositoryTests.cs`](tests/InventoryControl.Infrastructure.Tests/Repositories/PostgresProductRepositoryTests.cs) e aponta para o mesmo banco `inventory_control` utilizado pela aplicação. Não execute esses testes em um banco com dados que deseja preservar, nem em um ambiente compartilhado.

Utilize um banco descartável. Para apontar para um banco exclusivo de testes, ajuste a constante `ConnectionString` nesse arquivo e execute o script da tabela nesse banco. O isolamento e a criação do esquema ainda não são automáticos.

Com o banco descartável acessível e a tabela criada:

```powershell
dotnet test .\tests\InventoryControl.Infrastructure.Tests\InventoryControl.Infrastructure.Tests.csproj
```

## Status atual

Projeto de estudo funcional com os principais fluxos de cadastro, consulta e movimentação de estoque implementados em WinForms, persistência em PostgreSQL e testes organizados por camada. O projeto continua em evolução, com melhorias arquiteturais e de infraestrutura previstas para as próximas etapas.

## Próximos passos — não implementados

As propostas abaixo são melhorias futuras, sem representar recursos disponíveis ou um cronograma definido:

- Isolar o banco dos testes de integração e automatizar sua preparação.
- Adicionar controle de concorrência nas alterações de estoque.
- Alinhar limites e regras entre domínio, validadores e banco de dados.
- Externalizar a configuração da conexão e versionar a evolução do esquema.
- Estruturar os erros e simplificar a coordenação dos formulários.
- Avaliar o registro de um histórico de movimentações de estoque.

## O que aprendi

Com este projeto, pratiquei C# e a construção de uma aplicação WinForms com arquitetura em camadas. Exercitei princípios de DDD ao concentrar comportamentos e regras na entidade `Product`, e princípios de SOLID ao separar responsabilidades e depender de abstrações na aplicação.

Aprendi a organizar operações em casos de uso, aplicar o padrão Repository, utilizar DTOs e realizar validação com FluentValidation. Também pratiquei injeção de dependências por construtor e a composição dos serviços na inicialização da aplicação.

Na persistência, trabalhei com PostgreSQL, Npgsql, SQL parametrizado e operações assíncronas. Nos testes, exercitei regras de domínio, casos de uso com repositório em memória e integração com o banco real, reconhecendo a importância do isolamento dos dados de teste.
