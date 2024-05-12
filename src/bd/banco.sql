-- mysql banco.disciplina definition
CREATE TABLE `disciplina` (
  `codigo` varchar(100) NOT NULL,
  `nome` varchar(100) NOT NULL,
  PRIMARY KEY (`nome`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



-- banco.horarios definition
CREATE TABLE `horarios` (
  `cpf` varchar(100) DEFAULT NULL,
  `datas` varchar(100) DEFAULT NULL,
  `horarios` varchar(100) NOT NULL,
  PRIMARY KEY (`horarios`),
  KEY `cpf_professor_FK` (`cpf`),
  CONSTRAINT `cpf_professor_FK` FOREIGN KEY (`cpf`) REFERENCES `professor` (`cpf`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



-- banco.professor definition
CREATE TABLE `professor` (
  `cpf` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `senha` varchar(100) NOT NULL,
  `cod_disciplina` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `horarios` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`cpf`),
  UNIQUE KEY `email_professor_unique` (`email`),
  KEY `professor_disciplina_FK` (`cod_disciplina`),
  KEY `professor_horarios_FK` (`horarios`),
  CONSTRAINT `professor_disciplina_FK` FOREIGN KEY (`cod_disciplina`) REFERENCES `disciplina` (`nome`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `professor_horarios_FK` FOREIGN KEY (`horarios`) REFERENCES `horarios` (`horarios`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;




-- banco.marcarAula definition
CREATE TABLE `marcarAula` (
  `idAula` int NOT NULL,
  `cpf` varchar(100) NOT NULL,
  `idAluno` int NOT NULL,
  `horario` varchar(20) NOT NULL,
  `data` varchar(20) NOT NULL,
  `conteudo` varchar(100) NOT NULL,
  KEY `marcarAula_aluno_FK` (`idAluno`),
  KEY `marcarAula_professor_FK` (`cpf`),
  CONSTRAINT `marcarAula_aluno_FK` FOREIGN KEY (`idAluno`) REFERENCES `aluno` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `marcarAula_professor_FK` FOREIGN KEY (`cpf`) REFERENCES `professor` (`cpf`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



-- banco.aluno definition
CREATE TABLE `aluno` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `senha` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;




