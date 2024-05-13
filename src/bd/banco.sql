create database EadAsync;
use EadAsync;


-- EadAsync.disciplina definition

CREATE TABLE `disciplina` (
  `codigo` int NOT NULL,
  `nome` varchar(100) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



-- EadAsync.professor definition

CREATE TABLE `professor` (
  `cpf` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `senha` varchar(100) NOT NULL,
  `cod_disciplina` int NOT NULL,
  `horarios` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`cpf`),
  KEY `professor_disciplina_FK` (`cod_disciplina`),
  CONSTRAINT `professor_disciplina_FK` FOREIGN KEY (`cod_disciplina`) REFERENCES `disciplina` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;







-- EadAsync.horarios definition

CREATE TABLE `horarios` (
  `cpf` varchar(100) NOT NULL,
  `datas` date DEFAULT NULL,
  `horarios` time DEFAULT NULL,
  KEY `horarios_professor_FK` (`cpf`),
  CONSTRAINT `horarios_professor_FK` FOREIGN KEY (`cpf`) REFERENCES `professor` (`cpf`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;




-- EadAsync.marcar_aula definition

CREATE TABLE `marcar_aula` (
  `id_aula` int NOT NULL,
  `cpf` varchar(100) NOT NULL,
  `id_aluno` int NOT NULL,
  `horario` time DEFAULT NULL,
  `data` date DEFAULT NULL,
  `conteudo` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_aula`),
  KEY `marcar_aula_professor_FK` (`cpf`),
  KEY `marcar_aula_aluno_FK` (`id_aluno`),
  CONSTRAINT `marcar_aula_aluno_FK` FOREIGN KEY (`id_aluno`) REFERENCES `aluno` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `marcar_aula_professor_FK` FOREIGN KEY (`cpf`) REFERENCES `professor` (`cpf`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;




-- EadAsync.aluno definition

CREATE TABLE `aluno` (
  `id` int NOT NULL,
  `nome` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `senha` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
