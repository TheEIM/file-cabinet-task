# File Cabinet

## Шаг 1 - Создание консольного приложения FileCabinetApp

Цель: создание консольного приложение .NET Core, которое умеет реагировать на команды пользователя и выполнять две команды - _exit_ и _help_.

Все изменения (commits) должны храниться в ветке _step1-add-file-cabinet-app_, а после окончания работы должны быть слиты в ветку _main_.

Перед выполнением задания проверьте, что Вы:
* Умеете создавать консольные приложения .NET Core.
* Умеете работать к консольным приложением _dotnet_.
* Понимаете назначение файлов csproj и sln.
* Знаете основы работы с _git_ и умеете работать с командной строкой (команды status, add, checkout, merge).
* Знаете, для чего нужен статический анализатор кода.

Проработайте дополнительные материалы, чтобы получить недостающие знания и умения.

**Внимание!** Использование внешних пакетов nuget допускается только в случае, если это предусмотрено руководством, или по согласованию с тренером или ментором.

Перед началом выполнения проверьте, что установлен .NET 6 SDK.

```sh
$ dotnet --list-sdks
6.0.100 [C:\Program Files\dotnet\sdk]
```


### Выполнение

1. [Создайте](https://github.com/new) новый **private** репозиторий и клонируйте его на локальный диск. Настройка .gitignore - VisualStudio.
2. Создайте в клонированном репозитории новую ветку _step1-add-file-cabinet-app_ и переключитесь на нее.

```sh
$ git checkout -B step1-add-file-cabinet-app
Switched to a new branch 'step1-add-file-cabinet-app'
```

3. Создайте в каталоге клонированного репозитория новый проект .NET Core FileCabinetApp.

```sh
$ dotnet new console --name FileCabinetApp
The template "Console App" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj...
  Determining projects to restore...
  Restored D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj (in 80 ms).
Restore succeeded.
```

4. Создайте новый solution FileCabinet и добавьте в него проект FileCabinetApp.

```sh
$ dotnet new sln --name FileCabinet
The template "Solution File" was created successfully.

$ dotnet sln FileCabinet.sln add FileCabinetApp\FileCabinetApp.csproj
Project `FileCabinetApp\FileCabinetApp.csproj` added to the solution.
```

*Внимание!* Системы Windows используют "backslash" в файловых путях, а системы Linux и Mac - "slash". Поэтому для корректной работы командной строки в cmd.exe нужно использовать backslash. Однако, при работе в Windows через [Bash Shell (mingw64)](https://www.logicbig.com/tutorials/misc/git/git-bash-shell.html) нужно использовать "slash".

5. Соберите проект.

```sh
$ cd FileCabinetApp\
$ dotnet build
Microsoft (R) Build Engine version 17.0.0+c9eb9dd64 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  All projects are up-to-date for restore.
  FileCabinetApp -> D:\file-cabinet-task\FileCabinetApp\bin\Debug\net6.0\FileCabinetApp.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:02.31
```

6. Прочтите [руководство по установке StyleCop](https://carlos.mendible.com/2017/08/24/net-core-code-analysis-and-stylecop/) ([копия страницы](https://web.archive.org/web/20190110011601/https://carlos.mendible.com/2017/08/24/net-core-code-analysis-and-stylecop/)). Добавьте пакет StyleCop.Analyzers в проект FileCabinetApp.

```sh
$ dotnet add package StyleCop.Analyzers
  Writing C:\Users\Aliaksandr_Rykau\AppData\Local\Temp\tmp8C24.tmp
info : Adding PackageReference for package 'StyleCop.Analyzers' into project 'D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj'.
info : Restoring packages for D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/stylecop.analyzers/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/stylecop.analyzers/index.json 469ms
info : Package 'StyleCop.Analyzers' is compatible with all the specified frameworks in project 'D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj'.
info : PackageReference for package 'StyleCop.Analyzers' version '1.1.118' added to file 'D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj'.
info : Committing restore...
info : Generating MSBuild file D:\file-cabinet-task\FileCabinetApp\obj\FileCabinetApp.csproj.nuget.g.props.
info : Writing assets file to disk. Path: D:\file-cabinet-task\FileCabinetApp\obj\project.assets.json
log  : Restore completed in 1.03 sec for D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj.


  Determining projects to restore...
  Writing C:\Users\Aliaksandr_Rykau\AppData\Local\Temp\tmpE94B.tmp
info : Adding PackageReference for package 'StyleCop.Analyzers' into project 'D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/stylecop.analyzers/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/stylecop.analyzers/index.json 1389ms
info : Restoring packages for D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj...
info : Package 'StyleCop.Analyzers' is compatible with all the specified frameworks in project 'D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj'.
info : PackageReference for package 'StyleCop.Analyzers' version '1.1.118' added to file 'D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj'.
info : Committing restore...
info : Generating MSBuild file D:\file-cabinet-task\FileCabinetApp\obj\FileCabinetApp.csproj.nuget.g.props.
info : Writing assets file to disk. Path: D:\file-cabinet-task\FileCabinetApp\obj\project.assets.json
log  : Restored D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj (in 70 ms).
```
*Внимание!* В руководстве (см. выше) также используется пакет FxCopAnalyzers, однако в .NET есть встроенные анализаторы кода, поэтому необходимости в установке пакета FxCopAnalyzers нет.


7. Снова соберите проект.

```sh
Microsoft (R) Build Engine version 17.0.0+c9eb9dd64 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  Restored D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj (in 204 ms).
D:\file-cabinet-task\FileCabinetApp\Program.cs(1,1): warning SA1633: The file header XML is invalid. [D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj]
CSC : warning SA0001: XML comment analysis is disabled due to project configuration [D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj]
  FileCabinetApp -> D:\file-cabinet-task\FileCabinetApp\bin\Debug\net6.0\FileCabinetApp.dll

Build succeeded.

D:\file-cabinet-task\FileCabinetApp\Program.cs(1,1): warning SA1633: The file header XML is invalid. [D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj]
CSC : warning SA0001: XML comment analysis is disabled due to project configuration [D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj]
    2 Warning(s)
    0 Error(s)

Time Elapsed 00:00:01.42
```

Обратите внимание, что компилятор при сборке стал выдавать больше предупреждений. Эти предупреждения - результат работы StyleCop.

8. Скопируйте файл [code-analysis.ruleset](https://github.com/epam-dotnet-lab/file-cabinet-task-example-net6/blob/main/FileCabinetApp/code-analysis.ruleset) в каталог проекта FileCabinetApp.
9. Отредактируйте файл проекта FileCabinetApp.csproj и добавьте у него настройки для StyleCop.

```csproj
<CodeAnalysisRuleSet>code-analysis.ruleset</CodeAnalysisRuleSet>
```

Файл проекта должен выглядеть следующим образом (примерно):

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <CodeAnalysisRuleSet>code-analysis.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>
</Project>
```

10. Добавьте дополнительные настройки.

```csproj
<DocumentationFile>$(OutputPath)$(AssemblyName).xml</DocumentationFile>
<NoWarn>$(NoWarn),1573,1591,1712</NoWarn>
```

Файл проекта должен выглядеть следующим образом (примерно):

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <CodeAnalysisRuleSet>code-analysis.ruleset</CodeAnalysisRuleSet>
    <DocumentationFile>$(OutputPath)$(AssemblyName).xml</DocumentationFile>
    <NoWarn>$(NoWarn),1573,1591,1712</NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>
</Project>
```

11. Снова соберите проект.

```sh
Microsoft (R) Build Engine version 17.0.0+c9eb9dd64 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  Restored D:\file-cabinet-task\FileCabinetApp\FileCabinetApp\FileCabinetApp.csproj (in 166 ms).
  FileCabinetApp -> D:\file-cabinet-task\FileCabinetApp\FileCabinetApp\bin\Debug\net6.0\FileCabinetApp.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:01.17
```

Обратите внимание, что пред упреждения, которые компилятор выводил на экран в прошлый раз, исчезли.Это произошло из-за того, что вы изменили настройки StyleCop через файл code-analysis.ruleset.

12. Включите настройки встроенного анализатора кода .NET 6:

```csproj
<EnableNETAnalyzers>true</EnableNETAnalyzers>
<AnalysisMode>AllEnabledByDefault</AnalysisMode>
<CodeAnalysisTreatWarningsAsErrors>false</CodeAnalysisTreatWarningsAsErrors>
```

Файл проекта должен выглядеть следующим образом (примерно) - [FileCabinetApp.csproj](https://github.com/epam-dotnet-lab/file-cabinet-task-example-net6/blob/main/FileCabinetApp/FileCabinetApp.csproj)

13. Снова соберите проект.
14. Проверьте список измененных файлов в репозитории и просмотрите изменения.

```sh
$ cd ..
$ git status
On branch step1-add-file-cabinet-app
Untracked files:
  (use "git add <file>..." to include in what will be committed)

        FileCabinet.sln
        FileCabinetApp/

$ git diff
...
```

15. Добавьте изменения в файлах в stage.

```sh
$ git add *.cs *.csproj *.sln *.xml *.ruleset

$ git status
On branch step1-add-file-cabinet-app
Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

        new file:   FileCabinet.sln
        new file:   FileCabinetApp/FileCabinetApp.csproj
        new file:   FileCabinetApp/FileCabinetApp.xml
        new file:   FileCabinetApp/Program.cs
        new file:   FileCabinetApp/code-analysis.ruleset
```

16. Просмотрите изменения в stage - *всегда просматривайте ваши изменения перед тем как сделать commit*. 

```sh
$ git diff --staged
```

17. Сделайте commit.

```sh
$ git commit -m "Add initial version of FileCabinetApp."
```

18. Замените файл Program.cs в каталоге приложения на [Program.cs](https://github.com/epam-dotnet-lab/file-cabinet-task-example-net6/blob/main/FileCabinetApp/Program.cs).
19. Соберите проект.

```sh
$ dotnet build
Microsoft (R) Build Engine version 16.2.32702+c4012a063 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 32.04 ms for D:\file-cabinet-task\FileCabinetApp\FileCabinetApp.csproj.
  FileCabinetApp -> D:\file-cabinet-task\FileCabinetApp\bin\Debug\netcoreapp2.2\FileCabinetApp.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:02.20
```

Ошибок при сборке быть не должно.

20. Проверьте список измененных файлов в репозитории и добавьте их в stage. Сделайте commit.

```sh
$ git status
$ git add *.cs
$ git diff --staged
$ git commit -m "Add FileCabinetApp skeleton."
```

21. В Program.cs исправьте значение DeveloperName - поставьте Ваше имя и фамилию.

```cs
private const string DeveloperName = "Vasili Vasilyev";
```

22. Сделайте commit.

```sh
$ git status
$ git add *.cs
$ git commit -m "Change DeveloperName to Vasili Vasilyev."
```

23. Сделайте push локальной ветки в удаленную ветку.

```sh
$ git push --set-upstream origin step1-add-file-cabinet-app
```

24. Переключитесь на ветку main и сделайте [fast-forward merge](http://zencoder.ru/git/fast-forward-git/) изменений из ветки _step1-add-file-cabinet-app_.

```sh
$ git checkout main
$ git merge step1-add-file-cabinet-app --ff
```

25. Сделайте push изменений из локальной ветки main в удаленную ветку.

```sh
$ git push
```


### Проверка

* Проверьте работоспособность приложения.

```
$ cd FileCabinetApp
$ dotnet run
File Cabinet Application, developed by Vasili Vasilyev
Enter your command, or enter 'help' to get help.

> help
Available commands:
        help    - prints the help screen
        exit    - exits the application

> exit
Exiting an application...
```

* История репозитория должна выглядеть следующим образом:

```sh
$ git log --oneline
5e24f45 (HEAD -> main, origin/step1-add-file-cabinet-app, origin/main, origin/HEAD, step1-add-file-cabinet-app) Change DeveloperName to Vasil Vasilyev.
93f9f64 Add FileCabinetApp skeleton.
97e9145 Add initial version of FileCabinetApp.
227f3b7 Initial commit
```

* Репозиторий должен выглядеть как образец - [file-cabinet-task-example](https://github.com/epam-dotnet-lab/file-cabinet-task-example-net6).


### Дополнительные материалы

* [Начало работы с .NET Core в Windows, Linux и Mac OS с помощью командной строки](https://docs.microsoft.com/ru-ru/dotnet/core/tutorials/using-with-xplat-cli)
* [Get started with C# and Visual Studio Code](https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code)
* [Git за полчаса: руководство для начинающих](https://proglib.io/p/git-for-half-an-hour/)
* [Статический анализ кода](https://www.viva64.com/ru/t/0046/)
* [StyleCop: A Detailed Guide to Starting and Using It](https://blog.submain.com/stylecop-detailed-guide/)
