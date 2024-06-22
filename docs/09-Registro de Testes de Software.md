# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Relatório com as evidências dos testes de software realizados no sistema pela equipe, baseado em um plano de testes pré-definido.

## Login

### Imagem 1
As informações de email e senha são inseridos
![image](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/88893508/9ef4d1bb-93c2-4aad-94af-4fdf36f76e77)

### Imagem 2
Login inválido
![image](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/88893508/bbc8149b-64e6-4cb7-b896-d97575d464dc)

### Imagem 3
Login bem-sucedido
![image](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/88893508/1acc08a8-1b1c-4483-b99e-770a0d8d388b)

## Cadastro - Aluno

Nesta primeira etapa, exibimos o frontend da aplicação na página de cadastro de aluno, exibindo os campos de formulários: nome completo, e-amil e a senha, em que todos são do tipo string com a senha sendo DataType.Password para a ocultação dos caracteres digitados pelo usuário, ainda com o botão com ícone de "olho" para visualizar a senha digitada nos caracteres reais.

![116bf93f-3b26-42a7-a34d-d9c7ef2fed17](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/88893508/3b40aa0e-89de-4cac-b944-340ef6f5ea0c)

Após a criação do usuário, ele é salvo no banco de dados e as informações são recíprocas com as digitadas no campo de formulário e salvas no banco de dados.

![852a135a-f69b-4cf9-a74d-8ca20ed8d0be](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/88893508/aea9113e-cfc9-4f3d-8e75-b9b22e86f38f)

## Cadastro - Professor

Seguindo a mesma linha de etapas dos alunos, os professores também mantém-se a consistência, agora com novos dados como CPF e matérias das quais o professor cadastrado lecionará. Todos também sendo do tipo string, exceto o CPF que é int.

O select contém opções das mais variadas matérias da grade escolar, podendo selecionar apenas uma aqui.

![etapa_1_professor](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/88893508/e99414cc-bf48-4f7b-8e56-dd479f43c59e)

Seguindo as etapas, aqui também é exibido corretamente as informações do professor cadastrado e a criptografia devida da senha salva.

![etapa_2_professor](https://github.com/ICEI-PUC-Minas-PMV-SInt/pmv-sint-2024-1-e3-proj-back-t1-time-3/assets/88893508/9b5d7dea-dfed-4e3a-b4bd-651faed88d1c)

> **Links Úteis**:
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
