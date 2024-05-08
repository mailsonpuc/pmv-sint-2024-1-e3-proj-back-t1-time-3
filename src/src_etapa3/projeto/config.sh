clear
figlet projeto

#dotnet add package Microsoft.EntityFrameworkCore.Design              1> /dev/null
#dotnet add package Microsoft.EntityFrameworkCore.SQLite              1> /dev/null
#dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design  1> /dev/null
#dotnet add package Microsoft.EntityFrameworkCore.SqlServer           1> /dev/null
#dotnet add package Microsoft.EntityFrameworkCore.Tools               1> /dev/null
#dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 1> /dev/null
#dotnet add package Pomelo.EntityFrameworkCore.MySql                  1> /dev/null


#dotnet aspnet-codegenerator controller  \
#-name MarcarAulasController             \
#-m MarcarAula                           \
#-dc projeto.Data.projetoContext         \
#--relativeFolderPath Controllers        \
#--useDefaultLayout                      \
#--referenceScriptLibraries              \
#--databaseProvider sqlite               \


#dotnet ef migrations add conectando_no_mysql
#dotnet ef database update
