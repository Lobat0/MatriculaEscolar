# Matrícula estudantil

Aplicativo web de matrícula de estudantes, criado na plataforma .NET Framework, com banco de dados Microsoft SQL.

## Instruções
### Rodar o projeto

1. Dá teu jeito.

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
- Fazer as modais das tabelas intermediárias
- Exibir informações de outras tabelas nas listas e modal de detalhes (ex: O Curso em que o Aluno é cadastrado, as Disciplinas que um Professor ministra).

#### Erros
- Fazer tratamento de erro de todos controllers
- Adicionar try e catch nos possíveis erros dos controllers
- Exibir mensagens de erro caso ... de erro no post
- Exibir mensagens de sucesso caso ... sucesso no post
- Editar a página de erro???
- Deixar todos campos de input como required
- Arrumar o required dos campos input cpf e telefone
- Verificar campos replicados no cadastro e editar em todos controllers

#### Estética
- Deixar o modal de detalhes menos feio
