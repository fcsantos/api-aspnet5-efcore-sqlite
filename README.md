# api-aspnet5-efcore-sqlite

## criar a app com o powershell e utilizando o VS code ou o Jetbrains Rider

```dotnet new web -o NomedoProjeto -f net5.0```

## add packages, vai para a pasta raiz do seu projeto

```dotnet add package Microsoft.EntityFrameworkCore.Sqlite```
```dotnet add package Microsoft.EntityFrameworkCore.Design```

## após o desevolvimento

## para fazer o clean
```dotnet clean```

## para fazer o build (para validar se o projeto tem algum erro)
```dotnet build```

## Live coding
https://dotnetcoretutorials.com/2020/01/01/live-coding-net-core-using-dotnet-watch/
```dotnet watch run```

- OBS11: instalar o dotnet tool
```dotnet tool install --global dotnet-ef --version 5.0.0```

## alguns comandos para o migration
https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx

## add migration and update database
https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

- OBS2: para a injeçao de dependencia foi usado o [FromServices] no parametro das actions, no caso para o context
https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.fromservicesattribute?view=aspnetcore-5.0

- OBS3: como teste dos endpoints da API, foi usado o Postman