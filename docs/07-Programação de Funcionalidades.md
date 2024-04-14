# Programação de Funcionalidades

# Lucas Chagas de Oliveira - Tela de Cadastro.

Visando aprender sobre Asp.Net, uso o segundo exemplo do Professor Kleber para ter uma base fundamental para criar a minha tela de cadastro. Com isso foquei na criação de banco de dados de usuarios, veiculos e consumo.

A base do código é definida principalmente por duas tabelas, veiculos e consumo:

-  ### A PRIMEIRA FEITA É A TABELA DE VEÍCULOS, ONDE A TABELA CONSEGUE MAPEAR ALGUNS DADOS DE VEÍCULO PREENCHIDOS PELO USUÁRIO FINAL.
   ![image](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/160962468/6d2b959d-0945-4477-a171-aeed12f66efd)

![image](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/160962468/ac3c4fae-7bf3-459c-9030-bd7f50e20520)

-  ### A SEGUNDA FEITA É A DE CONSUMOS, ONDE O USUÁRIO CONSEGUE REGISTRAR O CONSUMO DO CARRO.

   ![image](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/160962468/c41d3100-d53f-44ea-b1d4-314906559bea)

   ![image](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/160962468/0a747cbb-c74c-46e8-ae42-3d3c95141249)

-  ### TERCEIRA FEITA É A DE CADASTRO DE USUÁRIOS, ONDE O USUÁRIO CONSEGUE CADASTRAR SEU PERFIL E O BANCO DE DADOS SALVA AS INFORMAÇÕES E CRIPTOGRAFA.
   ![image](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/160962468/79f899fe-907c-40fd-88be-6e81ab0fdff2)

![image](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/160962468/d5222eb0-bf63-4761-b037-59f4e89d48d0)

# Nickolas Ribeiro de Mendonça - Feed do Aluno.

A página de feed tem a função de mostrar ao usuário cartões que incluem detalhes sobre os professores e as matérias que eles oferecem na plataforma. Além disso, exibe o custo por aula e uma descrição breve feita pelo professor, que ajuda o aluno na escolha de sua monitoria. Para disponibilizar essas informações ao usuário após ele entrar na plataforma, foi preciso desenvolver algumas tabelas:

-  Usuarios
-  Disciplinas
-  ProfessorDisciplina
-  AlunoProfessoresDisciplinas

-  ### Imagens aos models utilizados para poder definir as tabelas do banco.

-  #### Usuários

<img src="img/feedAluno1.png">

-  #### Disciplinas

<img src="img/feedAluno2.png">

-  #### ProfessorDisciplinas

<img src="img/feedAluno3.png">

-  #### AlunoProfessoresDisciplinas

<img src="img/feedAluno4.png">

-  ### Após a definição dos modelos de dados, procedeu-se à criação das migrações correspondentes, que foram posteriormente executadas para efetivar a criação das tabelas no banco de dados. Com a estruturação das tabelas completada, em seguida, desenvolveram-se os controladores (controllers) e as visualizações (views). Esse processo marca um ponto crucial, pois é nesse estágio que se torna viável a manipulação de dados por meio de interfaces. Seguem imagens das interfaces geradas

<img src="img/feedAluno5.png">
<img src="img/feedAluno6.png">
<img src="img/feedAluno7.png">
<img src="img/feedAluno8.png">
<img src="img/feedAlunos9.png">
