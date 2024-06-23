### Testes de Usabilidade - Resultados

#### Descrição:
Realizamos testes de usabilidade para identificar problemas que afetam a experiência do usuário no projeto `Ead Async`.

#### Problemas Identificados:
- **Navegação:** Usuários tiveram dificuldades no redirecionamento quando clicar em `Perfil Professor`,`Feed Aluno`, `Feed Professor` a ação so funciona quado está logado.
- **Layout:** A sobreposição de elemento acessibilidade de mudar a cor na página inicial, quando clicar, muda a cor da página, mas para desfazer, o usuário precisa atualizar a página, o certo de se fazer era: quando clicar de novo, voltar à cor normal..

#### Recomendações de Melhoria:
- **Layout:** Revisar a logica do codigo js de acessibilade em `src/src_etapa3/projeto/wwwroot/js/site.js`.
- Tirar os menus e exibi apenas para quem estiver logado na aplicação.

#### Insights e Observações:
- Os usuários apreciaram a simplicidade do processo de registro, destacando-o como um ponto forte do projeto.
- Melhorar a consistência visual ao longo do fluxo de interação pode aumentar a confiança dos usuários na utilização do sistema.

#### Marcadores:
- `usabilidade`
- `layout`
- `navegação`

#### Milestone:
- Sessão de Testes de Usabilidade - `23/06/2024`
