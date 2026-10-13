# Minimal API — Cadastro de Veículos

API REST em **C# / .NET 9** para cadastro de veículos, com login de administradores, autenticação por **JWT** e controle de acesso por perfil. Projeto de estudo desenvolvido em agosto de 2025, com banco **MySQL**, documentação **Swagger** e projeto de testes **MSTest**.

## Funcionalidades

- Login de administradores com emissão de token JWT.
- Cadastro, listagem paginada, consulta, atualização e exclusão de **veículos**.
- Cadastro, listagem e consulta de **administradores**.
- Controle de acesso por perfil: `Adm` e `Editor`.
- Validação de dados de entrada, com mensagens de erro em JSON.
- Documentação interativa da API (Swagger), publicada na rota `/swagger`.
- Migrações do Entity Framework Core, incluindo a criação de um administrador inicial.

## Endpoints

| Método | Rota | Acesso | Descrição |
| --- | --- | --- | --- |
| GET | `/` | Público | Mensagem de boas-vindas e link para o Swagger |
| POST | `/administradores/login` | Público | Autentica e retorna o token JWT |
| GET | `/administradores` | `Adm` | Lista administradores (parâmetro `pagina`) |
| GET | `/administradores{id}/` | `Adm` | Consulta um administrador |
| POST | `/administradores` | `Adm` | Cria um administrador |
| POST | `/veiculos` | `Adm`, `Editor` | Cria um veículo |
| GET | `/veiculos` | `Adm`, `Editor` | Lista veículos (10 por página; parâmetro `pagina`) |
| GET | `/veiculos{id}/` | `Adm`, `Editor` | Consulta um veículo |
| PUT | `/veiculos{id}/` | `Adm` | Atualiza um veículo |
| DELETE | `/veiculos{id}/` | `Adm` | Remove um veículo |

As rotas com id estão definidas no código exatamente como `/veiculos{id}/` e `/administradores{id}/`. Consulte o Swagger para ver o formato aceito.

### Regras de validação
- **Veículo:** nome e marca obrigatórios; ano deve ser superior a 1950.
- **Administrador:** e-mail, senha e perfil obrigatórios.

## Arquitetura

```text
.
├── ProjetoAPI/
│   ├── Dominio/
│   │   ├── Entidades/        # Administrador, Veiculo
│   │   ├── DTOs/             # LoginDTO, AdministradorDTO, VeiculoDTO
│   │   ├── Enuns/            # Perfil (Adm, Editor)
│   │   ├── Interfaces/       # contratos dos serviços
│   │   ├── Serviços/         # regras de acesso a dados
│   │   └── ModelViews/       # modelos de resposta
│   ├── Infraestrutura/DB/    # DbContexto (EF Core)
│   ├── Migrations/           # migrações do banco
│   ├── Startup.cs            # configuração, autenticação e rotas
│   └── Program.cs
├── Teste/                    # projeto MSTest
└── DesafioProjetoAPI.sln
```

## Tecnologias

.NET 9 · ASP.NET Core Minimal API · Entity Framework Core 9 · MySQL (Pomelo) · JWT Bearer · Swagger (Swashbuckle) · MSTest

## Como executar

### Pré-requisitos
- [.NET SDK 9](https://dotnet.microsoft.com/download)
- Servidor MySQL em execução
- Ferramenta `dotnet-ef` (`dotnet tool install --global dotnet-ef`)

### Configuração
Em `ProjetoAPI/appsettings.json`, defina:

- `ConnectionStrings:MySql` — string de conexão com o seu MySQL;
- `Jwt` — chave usada na assinatura do token.

Use valores próprios do seu ambiente; não publique credenciais reais.

### Banco de dados e execução

```bash
cd ProjetoAPI
dotnet ef database update     # aplica as migrações, incluindo o administrador inicial
dotnet run
```

A API fica disponível em `http://localhost:5278` (ou `https://localhost:7148`), e o Swagger em `/swagger`. O administrador inicial é criado pela migração `SeedAdministrador`; suas credenciais estão definidas no código da migração.

### Testes

```bash
dotnet test Teste
```

O projeto `Teste` contém testes de entidades, de serviço e de requisição HTTP (com serviço simulado). O teste de serviço usa o banco configurado em `Teste/appsettings.json`; o repositório inclui scripts SQL de apoio (`Teste/veiculos_teste_utf8.sql`).

## Limitações

- Projeto de estudo: as senhas dos administradores são armazenadas e comparadas **em texto simples**, sem hash.
- A cobertura de testes é parcial: entidades, login de administrador e serviço de administrador.
- Não há Docker, pipeline de integração contínua nem licença definida.

## Autor

Willian Gomes — https://github.com/wiUl
