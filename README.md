# XPay-Back-End

Descrição

O XPay-Back-End é um projeto que simula transferências bancárias, utilizando o RabbitMQ para melhorar a escalabilidade e desempenho do sistema. O projeto também tem como objetivo aprimorar conhecimentos sobre arquiteturas baseadas em mensageria e sua aplicação em cenários reais.

Tecnologias Utilizadas

.NET 8: Framework para desenvolvimento da aplicação.

RabbitMQ: Sistema de mensageria para garantir a comunicação assíncrona e escalabilidade.

Entity Framework Core: ORM para gerenciar e persistir dados.

SQL Server: Banco de dados utilizado no projeto.

Docker: Contêinerização para facilitar a implantação e execução do RabbitMQ e outros serviços.

# Funcionalidades

Simulação de transferências bancárias entre contas.

Integração assíncrona utilizando RabbitMQ para publicação e consumo de mensagens.

Persistência de dados das transferências no banco de dados.

Sistema modular para futuras integrações.

Cadastro de usuários


# Fluxo de Mensageria

O cliente realiza uma solicitação de transferência bancária via API.

A solicitação é publicada como mensagem em uma fila do RabbitMQ.

Um consumidor processa a mensagem e realiza a transferência no banco de dados.

O status da operação é retornado ao banco de dados como finalizada.

# Futuras Melhorias

Implementar autenticação e autorização.

Adicionar testes unitários e de integração.

Melhorar a observação do sistema com logs estruturados e métricas.


Em construção
