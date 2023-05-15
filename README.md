
# CARTAPI

## Descrição

CARTAPI é uma API RESTful desenvolvida em .NET 7 que fornece serviços para gerenciamento de carrinhos de compras. Essa API permite que os usuários criem, atualizem, excluam e visualizem seus carrinhos de compras.

## Funcionalidades

- Criação de carrinho de compras
- Adição de itens ao carrinho de compras
- Remoção de itens do carrinho de compras
- Atualização de itens no carrinho de compras
- Recuperar o carrinho
- Gerar totais e subtotais
- Gerar um JSON com o carrinho completo

•	Adicionar um item no carrinho
•	Remover um item do carrinho
•	Atualizar a quantidade de um item no carrinho
•	Limpar o carrinho
•	Adicionar um cupom de desconto ao carrinho
•	Gerar totais e subtotais
•	Recuperar o carrinho
•	Retornar um JSON com o carrinho completo (para ser usado no frontend)


Tecnologias utilizadas
.NET 7
Entity Framework Core
SQL Server
Pré-requisitos
Para executar a API CARTAPI, é necessário ter o seguinte software instalado:

.NET 7 SDK
SQL Server Express ou Superior
Como executar
Clone este repositório em sua máquina:
```
git clone https://github.com/gustavofusco/CartAPI.git
```

Navegue até o diretório do projeto:
```
cd CARTAPI
```

Configure a conexão com o SQL Server no arquivo DataContext.cs:
```csharp
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
     base.OnConfiguring(optionsBuilder);
     optionsBuilder.UseSqlServer("Server=.\\SQLSERVER;Database=cartapidb;Trusted_Connection=true;TrustServerCertificate=true;");
 }
```

## Instalação dos Pacotes NuGet

1. Abra o Package Manager Console no Visual Studio.
2. Execute o seguinte comando para instalar o Entity Framework Core: `Install-Package Microsoft.EntityFrameworkCore`.
3. Execute o seguinte comando para instalar o Entity Framework Core SQL Server: `Install-Package Microsoft.EntityFrameworkCore.SqlServer`.
4. Execute o seguinte comando para instalar o Entity Framework Core Design: `Install-Package Microsoft.EntityFrameworkCore.Design`.
5. Verifique se as dependências foram instaladas corretamente no seu projeto.
6. Utilize o comando ``` dotnet build ```
7. Os arquivos para migração no banco de dados, já estão gerados.
8. Basta utilizar o comando ```dotnet ef database update``` para criar todas tabelas necessárias.

Substitua myServerName, myInstanceName, myDataBase, myUsername e myPassword com as informações de conexão do seu SQL Server.

Execute a API:
```
dotnet run
```

Acesse a API em seu navegador ou ferramenta de teste de API, usando a URL https://localhost:5298 ou pelo próprio Swagger http://localhost:5298/swagger/index.html

## Documentação da API
* [Documentação - CARTAPI](https://github.com/gustavofusco/CartAPI/blob/main/DOC.md)

Como usar
Para usar a API CARTAPI, consulte a documentação da API para obter informações sobre os endpoints disponíveis e como usá-los.

Documentação
Consulte a documentação da API em DOCUMENTAÇÃO.md.

Contribuição
Se você deseja contribuir com a API CARTAPI, por favor, siga estas instruções:

Licença
Nenhuma Licença foi atribuida a este projeto
