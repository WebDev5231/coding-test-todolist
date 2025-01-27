# To-Do List API - ASP.NET MVC

## Descrição

Este projeto é uma **API de Lista de Tarefas** desenvolvida utilizando **ASP.NET MVC**. Ele permite aos usuários gerenciar suas tarefas de forma simples, com funcionalidades de criar, listar e excluir tarefas. A interface web consome a API para exibir e gerenciar as tarefas armazenadas no banco de dados SQL Server. O sistema utiliza **LocalStorage** no frontend para otimizar a performance e diminuir a dependência de chamadas à API.

## Funcionalidades

- **Listar Tarefas**: Exibir todas as tarefas cadastradas.
- **Adicionar Tarefa**: Criar uma nova tarefa com título, descrição e data de término.
- **Deletar Tarefa**: Remover uma tarefa existente.

## Tecnologias Utilizadas

- **ASP.NET MVC**: Framework para desenvolvimento da aplicação web.
- **SQL Server**: Banco de dados utilizado para persistência das tarefas.
- **JavaScript** (Axios, LocalStorage): Comunicação com a API e manipulação dos dados na interface.
- **Bootstrap**: Framework CSS utilizado para estilizar a interface de usuário.

## Como Rodar o Projeto

### Requisitos

- **.NET SDK** (recomendado versão 6 ou superior)
- **SQL Server** (pode ser o SQL Server Express ou qualquer outra versão)
- **Node.js** (caso deseje rodar uma versão frontend separada)

### Passo 1: Clonar o Repositório

Clone o repositório para a sua máquina local.

```bash
git clone https://github.com/WebDev5231/coding-test-todolist
cd repositorio-todolist
