dotnet new sln --name Globomantics
dotnet new razor --name WebApp
dotnet sln add .\WebApp\
dotnet new webapi --name Weather
dotnet sln add .\Weather\
dotnet sln list
cd .\WebApp
dotnet add package Microsoft.Tye.Extensions.Configuration --version "0.10.0-alpha.21420.1"
cd..
dotnet new xunit --name Testing
dotnet sln add .\Testing\Testing.csproj


