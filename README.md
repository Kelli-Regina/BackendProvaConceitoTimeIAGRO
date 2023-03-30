# BackendProvaConceitoTimeIAGRO

Um cliente tem necessidade de buscar livros em um catálogo. Esse cliente quer ler e buscar esse catálogo de umarquivo JSON, e esse arquivo não pode ser modificado. Então com essa informação, é preciso desenvolver:

- Criar uma API para buscar produtos no arquivo JSON disponibilizado.
- Que seja possível buscar livros por suas especificações(autor, nome do livro ou outro atributo)
- É preciso que o resultado possa ser ordenado pelo preço.(asc e desc)
- Disponibilizar um método que calcule o valor do frete em 20% o valor do livro.

Será avaliado no desafio:

- Organização de código;
- Manutenibilidade;
- Princípios de orientação à objetos;
- Padrões de projeto;
- Teste unitário

Para nos enviar o código, crie um fork desse repositório e quando finalizar, mande um pull-request para nós.

O projeto deve ser desenvolvido em C#, utilizando o .NET Core 3.1 ou superior.

Gostaríamos que fosse evitado a utilização de frameworks, e que tivesse uma explicação do que é necessário para funcionar o projeto e os testes.

- O projeto é uma API Rest que contempla as funcionalidades do escopo acima.

## Pré-requisitos

- Clone o projeto do repositório;
- Certifique-se de ter o sdk .Net core 6 instalado;
- Recomendado a utilização do Visual Studio para execução do projeto;

## Executando o projeto

- Abra a solução BackendProvaConceitoTimeIAGRO no Visual Studio; 
- Defina o projeto TimeIAGRO.API como projeto de inicialização;
- Execute o projeto.
 
## Funcionalidades

Estão disponíveis dois endPoints o BuscarLivros e CalcularFrete.

| Método HTTP | Endpoint                             | Descrição                 |
| ----------- | -------------------- | ----------------------------------------- |
| GET         | /Livro/BuscarLivros  | Busca o livro de acordo com os parâmetros informados, possuindo dois parametros adicionais o ehOrdenacaoDescendente responsável pela ordenação ascendente os decentes pelo preço e o ehConsultaParcial responsável por realizar buscas exatas nos campos do tipo string ou buscas parciais nos campos do tipo string   |
| GET         | /Livro/CalcularFrete/{idLivro} | Retorna o valor do frete do livro informado utilizando o ID do livro |


## Executando os testes

- Abra a solução BackendProvaConceitoTimeIAGRO no Visual Studio; 
- Realize o Build do projeto TimeIAGRO.TEST;
- Execute os testes unitários.