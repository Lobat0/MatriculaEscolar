# Matrícula estudantil

Aplicativo web de matrícula de estudantes, criado na plataforma .NET Framework, com banco de dados Microsoft SQL, linguagem C#.

## Instruções
### Rodar o projeto

1. Baixar o projeto.
2. Abrir no Microsoft Studio e dar play.

### Git
Sempre que for começar a usar o projeto:
```shell
git pull
```

Sempre que terminar alguma alteração:
```shell
git add .
git commit -m "mensagem"
git push origin main
```

Se o projeto implicar com o pacote roslyn:
- Ferramentas >> Gerenciador de Pacotes do NuGet >> Console do Gerenciador de Pacotes
```shell
Install-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform
```

### Fazer
#### Funcionalidades
- Exibir informações de outras tabelas nas listas e modal de detalhes (ex: O Curso em que o Aluno é cadastrado, as Disciplinas que um Professor ministra).
- Só fazer a checagem de admin na controller de usuários.
- Tirar Curso-Disciplina e Professor-disciplina da navbar e adicionar nas páginas Curso e Professor.
- Exibir o nome do curso nos detalhes das tabelas intermediarias, não id.

#### Erros
- Fazer tratamento de erro de matrícula
- Editar a página de erro???
- Deixar todos campos de input como required, limitar o numero de caracteres dos inputs de texto.
- Arrumar o required dos campos input cpf e telefone
- Verificar campos replicados no cadastro e editar em todos controllers

#### Estética
- Deixar os modais de detalhes menos feio
- Deletar views e métodos inúteis
