# ResultFlow – Clean Error Handling in .NET Layers

## 📌 Overview

**ResultFlow** é um padrão arquitetural que organiza o tratamento de erros em aplicações .NET usando os princípios:

- Separação clara de responsabilidades
- Evitar exceções para fluxo normal
- Retornar objetos de resultado (`Result<T>`) nas regras de negócio
- Um *Middleware Global* captura exceções inesperadas
- Controllers traduzem *Result* para códigos HTTP corretos
- Repositórios não aplicam regra de negócio
