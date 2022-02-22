# CodacyProject

Pre-conditions:

- Install https://dotnet.microsoft.com/en-us/download/dotnet/3.1/runtime?utm_source=getdotnetcore&utm_medium=referral (if not installed)
- Install https://dotnet.microsoft.com/en-us/download/dotnet/3.1 - Section ASP.NET Core Runtime (if not installed)
- Clone repository from https://github.com/migmarques/CodacyProject



How to run:

- Exercise 1: Open cmd.exe on folder BusinessSolution\RunCodacyProject and run CodacyProject.Main.exe
- Exercise 2.1/3: Open cmd.exe on folder WebAPI and run CodacyProject.Services.exe
- The API has the following services:
  - GetCommitListByCommandLine
    - Parameters:
    - repositoryURL
    - pageSize (optional)
    - pageNumber (optional)
  - GetCommitList
    - Parameters:
    - repositoryURL
    - pageSize (optional)
    - pageNumber (optional)