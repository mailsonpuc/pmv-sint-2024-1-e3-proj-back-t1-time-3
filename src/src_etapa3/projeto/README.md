# Instruções de utilização

No Visual Studio, tem um botão específico para rodar a aplicação. No terminal você pode rodar o comando:
```sh
$ dotnet run
```
... que irá compilar e rodar a aplicação. Mas não vai ter o hot-reload, então pra esse caso você utiliza o comando:
```sh
$ dotnet watch
```

Em ambos os casos você pode (focado no terminal) apertar CTRL + R para reiniciar a aplicação e dar rebuild nela.


## Tutorial simplificado:
O que é o arquivo `config.sh`? 
É um arquivo bash script do Linux eu coloquei os comandos do dotnet cli dentro, para ele fazer tudo de uma vez para não fica baixando pacotes a cada um tendo que digita o comando repetido.

## Onde está o dbcontext?
Está dentro da pasta Data
Como pode ver pelo comando cli do net 
-dc o contexto de dados
`dotnet aspnet-codegenerator  -dc projeto.Data.projetoContext`

## Qual banco de dados a aplicação está usando?
Está usando SQLite, porem pode usar qualquer outra, basta apenas apagar a pasta migratios e configurar uma string e atualizar o banco.

## Como gerar as paginas para este app pelo cli do dotnet?
```sh
dotnet aspnet-codegenerator controller  \
-name MarcarAulasController             \ # <- NOME_DO_CONTROLADOR
-m MarcarAula                           \ # <- NOME_DO_MODELO
-dc projeto.Data.projetoContext         \ # <- O CONTEXTO DE DADOS
--relativeFolderPath Controllers        \ # <- O caminho da pasta de saída relativa para criar os arquivos.
--useDefaultLayout                      \ # <- O layout padrão deve ser usado para as exibições.
--referenceScriptLibraries              \ # <- Adiciona _ValidationScriptsPartial para Editar e Criar páginas.
--databaseProvider sqlite               \ # <- USAR O BANCO
```

## Como fazer migração pelo dotnet cli?
`dotnet ef migrations add InitialCreate`

## Como atualiza o banco de dados pelo dotnet cli?
`dotnet ef database update`




# Histórico de versões

- (11/04/2024): 0.0.1
    - Adicionado:
        - Estrutura básica do projeto
        - Cadastro de usuários
        - Documentação básica inicial
