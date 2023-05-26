# APICatalogo
CRUD usando Controllers e integração com Swagger

## Ferramentas
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/community/)
- [MySQL](https://www.mysql.com/products/community/)
- EF Core Tools (dotnet tool install --global dotnet -ef)

## Tecnologias
- .NET6

## Como rodar
1. selecione o local para clonar o projeto, dê preferência para o disco local (C:)</br>
```git clone https://github.com/AnnaBia/APICatalogo.git```
2. abra a pasta *APICatalogo/*
3. abra a solução *APICatalogo.sln* no Visual Studio
4. com a _Solution Explorer_ (barra de menu) aberta, localize o arquivo _appsettings.json_ e ajuste a _ConnectionString_ com o acesso da sua base de dados
> caso o Solution Explorer não abra automaticamente na IDE Visual Studio, pode-se pesquisar a ferramenta no próprio ambiente 
5. gere o banco e as tabelas populadas através de migrations:
 - abra o console nugget da aplicação em
```Tools >> NuGet Package Manager >> Package Manager Console```
 - no console, acesse a pasta da aplicação com
```cd .\APICatalogo```
 - na sequência, rode o comando para criar
```dotnet ef database update```
6. abra o MySQL e veja o banco *catalogodb* criado, e as tabelas _categorias_ e _produtos_ populadas
7. volte para a IDE e rode a aplicação (F5)
8. o swagger esta configurado para abrir na porta https://localhost:7279/swagger/index.html
