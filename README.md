# AppleStore - API CRUD - Dominio Rico

Api de estudos, CRUD um pouco fora do basico, aplicados padraoes e tecnologias, abaixo:

- EF 7 - Configurado para trabalhar no modo mais rapido possível em consultas ao MySQL
- Arquitetura em camadas
- A camada de API somente tem acesso a CrossCutting, todos acessos necessários sao feitos por injecao de dependencia
- Inversao de Controle
- UnitOfWork Pattern aplicado
- DTOS crados e mapedados sem uso de AutoMapper, buscando melhor perfomance
- Repository Pattern aplicado
- Testes Unitários aplicado
- 
