# Decompose Number


Projeto .NET Core, baseado em uma implementação simplificada de DDD.


Projeto criado para resolver um desafio cujo a finalidade é decompor um número em todos os seus divisores, enumerando também aqueles que forem primos.
O projeto pode ser executado em Console Application e também ser consumido através de uma API.

Pensando em escabilidade, o mesmo foi criado com .Net Core 3.1, permitindo assim executar a aplicação em um container (Linux/Windows).

Também foi disponibilizado para os consumidores da API, um endpoint exclusivo para saber a vida da aplicação, se está de "pé" ou não.
Para isso basta acessar http://localhost:5000/health sendo que o localhost pode ser um IP exposto em um servidor devidadente com sua respectiva porta.

## IMPORTANTE!
**Usar Visual Studio 2019 ou VSCode como IDE**

## Overview da arquitetura 
A aplicação está separada em faxadas de execução (api e application) e domínio da aplicação

1) A camada API, possui sua controller devidamente configurada para receber um número e servir para aplicações externas consumirem ela e ter o resultado esperado conforme o objetivo do projeto.

A documentação da API está exposta no swagger, permitindo testar e receber os resultados de sucesso e erro (mensagens de erro intuitivas para facilitar troubleshoot).

2) A camada APPLICATION, permite a interação do usuário através do Console Application. O mesmo foi contruído com divisões de responsabilidades pensando na facilidade de manutenção/alteração.

3) A camada CROSSCUTING faz parte da Infrastructure, seu objetivo é conter funcionalidades que possam ser usadas por outros projetos, consumo de API externa (não é nosso caso), etc. Nela está contido a classe Util, que é reponsável por fazer validações dos valores de entrada.

4) A camada DOMAIN possui as interfaces, entidades e DTOs.

5) A camada SERVICE pode ser considerada o core do projeto, visto que nela possui toda a regra de negócio. 

6) A camada TEST é responsável por testes unitários (sucesso/erros). Nela está sendo utilizado o xUnit.

## Tecnologias e arquitetura
Plataforma: .Net Core 3.1

Linguagem: C# 

Design: Simple DDD

Docker

Para configurar o docker, basta ir até a pasta DN.Api e executar os comandos:
> "docker build -t decomposenumberapi-image -f Dockerfile ." SEM AS ASPAS
> "docker run -d -p 5000:80 --name decomposenumberapi-image decomposenumberapi-image" SEM AS ASPAS

## Considerações finais

Não sou desenvolvedor .Net (AINDA rsrs), então possivelmente hajam falhas e codificação à ser melhorada.
Muitos princípios, arquitetura, foram resultado do curso do Marcos Fabricio https://www.udemy.com/course/aspnet-core-22-c-api-com-arquitetura-ddd-na-pratica
Também li o artigo para implementar injeção de dependência do Marcio Nizolla (https://marcionizzola.medium.com/como-fazer-inje%C3%A7%C3%A3o-de-depend%C3%AAncia-em-um-console-application-com-net-core-c5d66f092593), pois confesso que tive dificuldade de fazer no console application...

No mais meu muito obrigado à Framework Digital pelo desafio proposto.
