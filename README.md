# Gerenciador de Eventos

## Descrição

Este projeto é uma aplicação .NET que gerencia eventos e participantes. Ele usa arquivos JSON como um banco de dados simples para armazenar dados.

## Banco de Dados

A aplicação usa arquivos JSON para armazenar dados. Os arquivos são armazenados no diretório `%temp%` da máquina do usuário, especificamente no subdiretório `Desafio2_JSON_DB`. Isso permite que a aplicação seja executada em qualquer máquina sem a necessidade de configuração adicional de banco de dados.

A estrutura do diretório do banco de dados é a seguinte:

%temp% └── Desafio2_JSON_DB ├── Eventos └── Participantes


O diretório `Eventos` contém arquivos JSON para cada evento, e o diretório `Participantes` contém arquivos JSON para cada participante.

## Configuração

1. Clone o repositório para sua máquina local usando o comando `git clone https://github.com/digo2112/Desafio2.git`.
2. Abra a solução no Visual Studio.
3. Compile e execute a aplicação.

A aplicação criará automaticamente os diretórios e arquivos necessários no diretório `%temp%` se eles não existirem.
