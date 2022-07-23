# RestaurantApi
Api para buscar restaurantes abertos na hora informada
## Resumo
 - Apresentação da api
 - Mostrar funcionalidade
 - Mensagens de erros da aplicação
 - Motivo das minhas escolhas

## ApiRestaurant
 - Api com objetivo de retornar todos restaurantes abertos de um arquivo CSV de acordo com a hora determinada pelo usuário.
## Passos para funcionar
 - EndPoint : Restaurant
 - Metodo: OpenRestaurant
 - Parâmetro: hora (string)
 - Formato que o parâmetro deve ser entregue: MM:HH
 - Regras para o parâmetro: HH entre 1 e 24 e MM entre 00 e 60
 - Status de retorno: 200 sucesso, 500 ocorreu algum erro
 - Retorno metodo: Um array de json com os nomes dos restaurantes abertos
Exemplo de requisição: https://localhost:44371/v1/Restaurant/OpenRestaurants?hora=15:20
Exemplo de retorno: [ {"name": "Kushi Tsuru" }, {"name": "Alioto" }]

## Mensagens de erros (códigos e descrições):

1. BuscarRestaurantes_00001 =	Hora não informada para buscar restaurantes abertos 
2. BuscarRestaurantes_00002 =	Arquivo não encontrado na pasta base ;
3. BuscarRestaurantes_00003 =	A hora precisa ser no formato HH:MM, sendo HH entre 1 e 24 e MM entre 00 e 60

## Motivos de minhas escolhas:
 - Formato de pastas: MVC + gosto pessoal
 - Escolhi o parametro como tipo string porque tenho um facilidade em manipular os 
  dados para validação.
 - Peguei as informações do CSV e armazenei em um array utilizando a classe
  TextFieldParser da biblioteca Microsoft.VisualBasic.FileIO.
 - Fiz o processo de armazenamento de erros possivel de ser utilizado em qualquer
  Classe que herda da classe BaseServices onde tem o gerenciamento
Utilizei para fazer o processo de teste unitário a aplicação  Xunit
