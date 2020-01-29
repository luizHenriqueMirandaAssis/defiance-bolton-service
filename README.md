# defiance-bolton-service

## Projeto utilizado para o desafio da Arquivei

O projeto foi desenvolvido para realizar a integração com os arquivos de NFe, nesse contexto foi utilizado o Hangfire para realizar a execução da integração em background, desse modo, podemos configurar a execução automaticamente em determinados períodos de tempo.

Também foi disponibilizado uma API REST para consultar os dados das NFe que foram importadas, para simplificar a documentação da API foi utilizado o Swagger. 



## Diagrama da modelagem do projeto

![alt text](https://docs.google.com/uc?id=10Aw_iGk6CCNKszYs63UfyKlA_YnAzp83)

### Frameworks utilizados  
- Swagger
- Hangfire
- Entity Framework Core
- ASP.NET Core 3.1

### Padrões utilizados
- SOLID
- Clean Architecture

### Banco de dados
- SQl Server
