-- escrever dml aqui
show tables;

describe aluno;
describe disciplina;
describe horarios;
describe marcar_aula;
describe professor;

insert into aluno (id, nome, email, senha) values
(100, "leandro silva", "l@mail.com", "12345");
SELECT * from aluno;


insert into disciplina (codigo, nome) values
(100, "filosofia");
SELECT * from disciplina;


insert into professor (cpf,email,senha,cod_disciplina,horarios) values
("005.686.080-38", "pf@mail.com","123456", 100, "13:57:26");
SELECT * from professor;


insert into horarios (cpf, datas, horarios) values
("005.686.080-38", "2024-05-13", "13:57:26");
SELECT * from horarios;


insert into marcar_aula (id_aula,cpf,id_aluno,horario, `data`, conteudo) values
(100, "005.686.080-38", 100, "13:57:26","2024-05-13", "filosofia");
SELECT * from marcar_aula;


SELECT 'aluno' AS TABELA, nome FROM aluno            UNION ALL
SELECT 'disciplina' AS TABELA, nome FROM disciplina  UNION ALL
SELECT 'professor' AS TABELA, cpf FROM professor     UNION ALL
SELECT 'horarios' AS TABELA, horarios FROM horarios  UNION ALL
SELECT 'marcar_aula' AS TABELA, `data` from marcar_aula;

