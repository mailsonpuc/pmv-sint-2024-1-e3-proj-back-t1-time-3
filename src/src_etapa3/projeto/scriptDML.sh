clear

figlet SCRIPT-DML

#INSERT INTO Aluno (Name, Email, Senha) VALUES ("Edna", "dn@mail.com", "666"), ("Camilly SIlva", "cn@mail.com", "4666")

nome(){
  cat /dev/urandom | tr -dc 'a-zA-Z0-9' | head -c 7
}


sobrenome(){
  cat /dev/urandom | tr -dc 'a-zA-Z0-9' | head -c 4
}


generate_string(){
   cat /dev/urandom | tr -dc 'a-zA-Z0-9' | head -c 20
 }


 for ((i = 10; i <=1000; i++ )); do
   random_string=$(generate_string)
   NOME=$(nome)
   SOBRENOME=$(sobrenome)
   echo "('$NOME $SOBRENOME','$i@mail.com','$random_string'),"

 done





