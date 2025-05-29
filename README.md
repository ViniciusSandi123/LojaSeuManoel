## Como Executar o Projeto

1. Navegue até a pasta do projeto:

   em  ...\LojaSeuManoel\Loja

2. Suba os containers com Docker Compose do arquivo docker-compose.yml

3. Com os containers no ar, aplique a migration para criar o banco e as tabelas. No Visual Studio, execute:

   Update-Database

   A migration `20250529223043_initial-containers` já está configurada.

4. Acesse a aplicação via Swagger:

   http://localhost:5141/swagger/index.html

## Conexão com o banco criado

   Server=localhost,1433
   Database=Loja
   User Id=sa
   Password=Loja123!