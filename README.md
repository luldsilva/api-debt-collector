# api-debt-collector
# Projeto de API para Gerenciamento de Títulos em Atraso

Este projeto é uma API desenvolvida para a inclusão e visualização de títulos em atraso. A API permite adicionar um título que está em atraso e consultar informações sobre esses títulos.
Link para o projeto do front-end: https://github.com/luldsilva/front-api-debt-collector
![2024-08-29-17-31-43](https://github.com/user-attachments/assets/1c56fe00-b492-4a70-b03c-db7a5c34342e)

## Funcionalidades

- **Inclusão de Título em Atraso:** Permite adicionar um novo título que está em atraso.
- **Visualização de Títulos em Atraso:** Permite consultar e visualizar os títulos que estão em atraso.

## Tecnologias Utilizadas

- ASP.NET Core, Entity Framework, Angular, MySQL.

## Endpoints

### Adicionar Título em Atraso

- **Método:** POST
- **Endpoint:** `/api/Debit/create-debit`
- **Descrição:** Cria um novo título em atraso.
- **Corpo da Requisição:**
  ```json
  {
    "nomeCliente": "Lucas silva teste mais um",
    "cpfCliente": "013874673712",
    "percentualJuros": 3,
    "percentualMulta": 2,
    "numeroDeParcelas": 2,
    "valorOriginal": 400,
    "modeloDeParcelamento": [
    {
      "numeroParcela": 1,
      "valorParcela": 100,
      "dataVencimentoParcela": "2024-06-29T12:50:38.826Z"
    },
    {
			"id":0,
      "numeroParcela": 2,
      "valorParcela": 100,
      "dataVencimentoParcela": "2024-07-29T12:50:38.826Z"
    }
  ]
  }

- **Método:** GET
- **Endpoint:** `/api/Debit/get-all-debit`
- **Descrição:** Lista todos os títulos em atraso.
- **Corpo da Requisição:**
  ```json
  {
    {
      "numeroDoTitulo": 3,
      "nomeDoCliente": "Lucas Silva",
      "quantidadeDeParcelas": 2,
      "valorOriginal": 1000,
      "diasEmAtraso": 23,
      "valorAtualizado": 1250,
      "juros": 2
    },
    {
      "numeroDoTitulo": 4,
      "nomeDoCliente": "Lucas teste",
      "quantidadeDeParcelas": 2,
      "valorOriginal": 500,
      "diasEmAtraso": 9,
      "valorAtualizado": 527.5,
      "juros": 1
    }
  }
