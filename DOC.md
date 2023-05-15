# Documentação da API
Esta documentação está destinada para entender todos os processos e seus funcionamentos
<br />
<p align="center">
  <h3 align="center">CART API</h3>

  <p align="center">
    Um projeto para exemplo!
    <br />
    <a href="https://github.com/gustavofusco/CartAPI/blob/main/README.md">Ver demo</a>
    ·
    <a href="https://github.com/gustavofusco/acme-inc/issues">Reportar Bug</a>
  </p>
</p>


## Sumário
📌 [Usuários](#usuarios)<br />
📌 [Produtos](#produtos)<br />
📌 [Cupom](#cupom)<br />
📌 [Carrinho](#carrinho) <br />

## Usuário
### Requisições

Método HTTP: GET 📋
Endpoint: `/api/User`
Parâmetros: Nenhum
Resposta: Retorna uma lista de todos os produtos
Exemplo de resposta:

```json
{
  "$id": "1",
  "$values": [
    {
      "$id": "2",
      "id": 1,
      "nome": "Mario",
      "carrinhoId": null,
      "cart": null
    },
    {
      "$id": "3",
      "id": 2,
      "nome": "Vanessa",
      "carrinhoId": null,
      "cart": null
    },
    {
      "$id": "4",
      "id": 3,
      "nome": "Victor",
      "carrinhoId": null,
      "cart": null
    }
  ]
}
```
<br>


## Produtos
Método HTTP: GET 📋
Endpoint: `/api/Product`
Parâmetros: Nenhum
Resposta: Retorna uma lista de todos os produtos, ativos e não ativos
Exemplo de resposta:
```json
{
  "$id": "1",
  "$values": [
    {
      "$id": "2",
      "id": 1,
      "nome": "Geladeira",
      "preco": 5050,
      "descricao": "Geladeira eletro 127v",
      "estoque": 7,
      "ativo": true
    },
    {
      "$id": "3",
      "id": 2,
      "nome": "Fogão",
      "preco": 1200,
      "descricao": "Fogão 5 Bocas",
      "estoque": 3,
      "ativo": true
    },
    {
      "$id": "4",
      "id": 3,
      "nome": "Sofá",
      "preco": 1800,
      "descricao": "Sofá cama com suporte",
      "estoque": 0,
      "ativo": false
    },
    {
      "$id": "5",
      "id": 4,
      "nome": "Mesa Jantar",
      "preco": 780,
      "descricao": "Mesa de jantar com 4 lugares",
      "estoque": 2,
      "ativo": true
    },
    {
      "$id": "6",
      "id": 5,
      "nome": "Guarda-Roupas",
      "preco": 950,
      "descricao": "Guarda-roupas com 3 portas",
      "estoque": 15,
      "ativo": true
    }
  ]
}
```


## Cupom
Método HTTP: GET 📋
Endpoint: `/api/Cupom`
Parâmetros: Nenhum
Resposta: Retorna uma lista de todos os cupons
Exemplo de resposta:
```json
{
  "$id": "1",
  "$values": [
    {
      "$id": "2",
      "id": 1,
      "codigo": "DESCONTAO",
      "desconto": 10
    },
    {
      "$id": "3",
      "id": 2,
      "codigo": "CINQUENTAOFF",
      "desconto": 50
    },
    {
      "$id": "4",
      "id": 3,
      "codigo": "FELIZNATAL",
      "desconto": 25
    }
  ]
}
```

Método HTTP: POST 📥
Endpoint: `/api/Cupom/{codigo}/{idUser}`
Parâmetros: Código Cupom, Id usuário
Resposta: Aplica um cupom para o usuario se o nome do cupom estiver correto e se existir um carrinho para o Usuario.

Exemplo de requisição:
```
POST /api/Cupom/FELIZNATAL/3
```

Exemplo de resposta:
```
Cupom de 25% aplicado com sucesso!
```


## Carrinho
Método HTTP: GET 📋
Endpoint: `/api/Cart/{idUser}`
Parâmetros: Id do usuário
Resposta: Retorna o carrinho completo do usuário caso exista
Exemplo de resposta:
```json
{
  "$id": "1",
  "id": 4,
  "createdAt": "2023-05-15T09:26:56.2802157",
  "userId": 3,
  "usuario": null,
  "itens": {
    "$id": "2",
    "$values": [
      {
        "$id": "3",
        "id": 3,
        "produtoId": 3,
        "produto": {
          "$id": "4",
          "id": 3,
          "nome": "Sofá",
          "preco": 1800,
          "descricao": "Sofá cama com suporte",
          "estoque": 0,
          "ativo": false
        },
        "quantidade": 5,
        "subtotal": 9000
      },
      {
        "$id": "5",
        "id": 4,
        "produtoId": 1,
        "produto": {
          "$id": "6",
          "id": 1,
          "nome": "Geladeira",
          "preco": 5050,
          "descricao": "Geladeira eletro 127v",
          "estoque": 7,
          "ativo": true
        },
        "quantidade": 1,
        "subtotal": 5050
      }
    ]
  },
  "cupomId": 1,
  "cupom": null
}
```

Método HTTP: POST 📥
Endpoint: `/api/Cart/{idUser}/{idProduct}`
Parâmetros: Id do usuário, Id do produto
Resposta: Adiciona uma unidade do produto ao carrinho do usuário

Exemplo de requisição para adicionar a mesa de jantar:
```
POST /api/Cart/3/4
```

Exemplo de resposta:
```
Produto adicionado ao carrinho de Victor
```


Método HTTP: DELETE ❌
Endpoint: `/api/Cart/{idUser}/{idProduct}`
Parâmetros: Id do usuário, Id do produto
Resposta: Remove uma unidade do produto ao carrinho do usuário

Exemplo de requisição para remover a mesa de jantar:
```
POST /api/Cart/3/4
```

Exemplo de resposta:
```
Produto removido do carrinho
```

Método HTTP: PUT ✏️
Endpoint: `/api/Cart/{idUser}/{idProduct}/{Qtd}`
Parâmetros: Id do usuário, Id do produto e a quantidade
Resposta: Altera a quantidade de itens no carrinho do usuário

Exemplo de requisição para remover a mesa de jantar:
```
POST /api/Cart/3/4/2
```

Exemplo de resposta:
```
Quantidade alterada para 2
```

Método HTTP: DELETE ❌
Endpoint: `/api/Cart/drop/{idUser}`
Parâmetros: Id do usuário
Resposta: Deleta o carrinho vinculado ao usuário

Exemplo de requisição para remover a mesa de jantar:
```
POST /api/Cart/drop/3
```

Exemplo de resposta:
```
Excluido com sucesso!
```

Método HTTP: GET 📋
Endpoint: `/api/Cart/finish/{idUser}`
Parâmetros: Id do usuário
Resposta: Retorna o carrinho completo do usuário ja com cupom de desconto aplicado e o JSON para utilizar no front-end
Exemplo de resposta:
```json
{
  "$id": "1",
  "total": 12645,
  "id": 4,
  "createdAt": "2023-05-15T09:26:56.2802157",
  "userId": 3,
  "usuario": {
    "$id": "2",
    "id": 3,
    "nome": "Victor",
    "carrinhoId": 4,
    "cart": null
  },
  "itens": {
    "$id": "3",
    "$values": [
      {
        "$id": "4",
        "id": 3,
        "produtoId": 3,
        "produto": {
          "$id": "5",
          "id": 3,
          "nome": "Sofá",
          "preco": 1800,
          "descricao": "Sofá cama com suporte",
          "estoque": -5,
          "ativo": false
        },
        "quantidade": 5,
        "subtotal": 9000
      },
      {
        "$id": "6",
        "id": 4,
        "produtoId": 1,
        "produto": {
          "$id": "7",
          "id": 1,
          "nome": "Geladeira",
          "preco": 5050,
          "descricao": "Geladeira eletro 127v",
          "estoque": 6,
          "ativo": true
        },
        "quantidade": 1,
        "subtotal": 5050
      }
    ]
  },
  "cupomId": 1,
  "cupom": {
    "$id": "8",
    "id": 1,
    "codigo": "DESCONTAO",
    "desconto": 10
  }
}
```

Essa é uma documentação básica para as requisições relacionadas a produtos na API
