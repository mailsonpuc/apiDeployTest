clear

# dotnet add package Microsoft.EntityFrameworkCore.InMemory
# dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
# dotnet add package Microsoft.EntityFrameworkCore.Design
# dotnet add package Microsoft.EntityFrameworkCore.SqlServer
# dotnet add package Microsoft.EntityFrameworkCore.Tools

# dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
# dotnet add package Microsoft.IdentityModel.Tokens
# dotnet add package System.IdentityModel.Tokens.Jwt
# dotnet add  package Swashbuckle.AspNetCore


dotnet aspnet-codegenerator controller \
-name CursoController                  \
-async                                 \
-api                                   \
-m CursoItem                           \
-dc CursoDbContext                     \
-outDir Controllers